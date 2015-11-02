using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAOP.AOP
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class  CleanAopAttribute:Attribute
    {
        public  bool IsInnerInvoke { set; get; }
        public  InvokeLocation Location { set; get; }
        public abstract void After(IInvocation invocation,Exception exp);

        public abstract void Middle(IInvocation invocation);
        public abstract void Before();

        
    }
}
