using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAOP.AOP.AOPAttrubutes
{
    public class TimeAopAttribute : CleanAopAttribute
    {
        public override void After(IInvocation invocation, Exception exp)
        {
            Debug.WriteLine(DateTime.Now.ToString());
        }

        public override void Before()
        {
            Debug.WriteLine(DateTime.Now.ToString());
        }

        public override void Middle(IInvocation invocation)
        {
            
        }
    }
}
