using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAOP.Intercepts
{
    [AttributeUsage(AttributeTargets.Class)]
    /// <summary>
    /// 属性更新拦截器，用于MVVM
    /// </summary>
    public class PropertyNotifyIntercept : Attribute,IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            var methodName = invocation.Method.Name;
            if (methodName.StartsWith("set_"))
            {
                var Target = invocation.InvocationTarget as Notice;
                Target.OnPropertyChanged(invocation.Method.Name.Substring(4));
            }
        }
    }
}
