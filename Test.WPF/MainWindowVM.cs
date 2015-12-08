using CleanAOP;
using CleanAOP.AOP.AOPAttrubutes;
using CleanAOP.Intercepts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.WPF
{
    [AopIntercept]
    [PropertyNotifyIntercept]
    public class MainWindowVM:Notice
    {
        private MainWindowVM()
        {

        }

        public MainWindowVM(string a,string b)
        {

        }

        public virtual string Name
        {
            set; get;
        }

        
        [TryCatchAttrubute]
        [LogAopAttrubute]
        [TimeAop]
        public virtual async Task DoWord()
        {
            await GetValueAsync(1234.5123, 1.01);
            //throw new Exception("没有await");
            Debug.WriteLine("123");
            Debug.WriteLine("123");
        }


        public Task<double> GetValueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    num1 = num1 / num2;
                }
                return num1;
            });
        }
    }
}
