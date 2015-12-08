using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAOP.AOP.AOPAttrubutes
{
    public class TryCatchAttrubute : CleanAopAttribute
    {
        public TryCatchAttrubute()
        {
            this.IsInnerInvoke = true;
        }
        
        public override void After(IInvocation invocation, Exception exp)
        {
            if(exp!=null)
            {
                Debug.WriteLine("处理错误,错误信息为：" + exp.InnerException.Message??exp.Message);
            }
        }

        public override void Before()
        {
            Debug.WriteLine("开始捕捉异常");
        }

        public override void Middle(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exp)
            {
                Debug.WriteLine(string.IsNullOrEmpty(exp.Message) ? exp.InnerException.Message : exp.Message);
            }
        }
    }
}
