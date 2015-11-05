using Castle.DynamicProxy;
using CleanAOP.Intercepts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAOP
{
    /// <summary>
    /// 拦截代理类生成工厂
    /// </summary>
    public class InterceptClassFactory
    {
        private static Dictionary<IntercetEnum, IInterceptor> intercepDic = new Dictionary<IntercetEnum, IInterceptor>();
        static InterceptClassFactory()
        {
            intercepDic.Add(IntercetEnum.PropertyNotify, new PropertyNotifyIntercept());
            intercepDic.Add(IntercetEnum.Aop, new AopIntercept());
        }
        /// <summary>
        /// 获取方法拦截代理类实例
        /// </summary>
        /// <typeparam name="T">被代理类</typeparam>
        /// <param name="interceptors">拦截器列表</param>
        /// <returns></returns>
        public static T GetInterceptClass<T>(object[] args,params IntercetEnum[] interceptEnums) where T : class
        {
            ProxyGenerator generator = new ProxyGenerator();//实例化【代理类生成器】

            List<IInterceptor> intercepts = new List<IInterceptor>();
            foreach(var interceptenum in interceptEnums)
            {
                intercepts.Add(intercepDic[interceptenum]);
            };

            T result = generator.CreateClassProxy(typeof(T), args, intercepts.ToArray()) as T;//创建方法拦截代理类实例。
            return result;
        }
    }
}
