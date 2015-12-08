using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAOP.AOP.AOPAttrubutes
{
    public class LogAopAttrubute : CleanAopAttribute
    {
        public override void After(IInvocation invocation,Exception exp)
        {
            Debug.WriteLine("执行结束,"+invocation.Method.ToString()+"方法");
        }
       
        public override void Before()
        {
            Debug.WriteLine("开始执行");
        }

        public override void Middle(IInvocation invocation)
        {
            Debug.WriteLine("执行中");
        }
    }
}
