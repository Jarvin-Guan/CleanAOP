using Castle.DynamicProxy;
using CleanAOP.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanAOP.Intercepts
{
    [AttributeUsage(AttributeTargets.Class)]
    /// <summary>
    /// AOP拦截器
    /// </summary>
    public class AopIntercept : Attribute,IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var Attributes = invocation.MethodInvocationTarget.GetCustomAttributes(true);

            foreach(var attribute in Attributes)
            {
                if(attribute is CleanAopAttribute)
                {
                    if((attribute as CleanAopAttribute).Location==InvokeLocation.Before
                        || (attribute as CleanAopAttribute).Location == InvokeLocation.Both )
                    {
                        (attribute as CleanAopAttribute).Before();
                    }
                }
            }

            if (Regex.IsMatch(invocation.Method.Name, @"[gs]et_") || Attributes.Count(p =>
            { return (p is CleanAopAttribute && (p as CleanAopAttribute).IsInnerInvoke == true); }) <= 0)
            {
                invocation.Proceed();
            }

            foreach (var attribute in Attributes)
            {
                if (attribute is CleanAopAttribute)
                {
                    (attribute as CleanAopAttribute).Middle(invocation);
                }
            }
            

            if (invocation.ReturnValue is Task)
            {
                (invocation.ReturnValue as Task).ContinueWith(delegate(Task t) {
                    AfterInvoke(Attributes,invocation,t.Exception);
                });
            }
            else
            {
                AfterInvoke(Attributes, invocation,null);
            }
        }
        private void AfterInvoke(object[] Attributes,IInvocation invocation, Exception exp)
        {
            foreach (var attribute in Attributes)
            {
                if (attribute is CleanAopAttribute)
                {
                    if ((attribute as CleanAopAttribute).Location == InvokeLocation.After
                        || (attribute as CleanAopAttribute).Location == InvokeLocation.Both)
                    {
                        (attribute as CleanAopAttribute).After(invocation,exp);
                    }
                }
            }
        }
    }
}
