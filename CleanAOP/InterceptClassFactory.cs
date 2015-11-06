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
        /// <summary>
        /// 获取方法拦截代理类实例
        /// </summary>
        /// <typeparam name="T">被代理类</typeparam>
        /// <param name="interceptors">拦截器列表</param>
        /// <returns></returns>
        public static T GetInterceptClass<T>(params object[] args) where T : class
        {
            ProxyGenerator generator = new ProxyGenerator();//实例化【代理类生成器】

            T result = generator.CreateClassProxy(typeof(T), args, 
                typeof(T).GetCustomAttributes(typeof(IInterceptor), true).Cast<IInterceptor>().ToArray()) as T;//创建方法拦截代理类实例。
            return result;
        }
    }
}
