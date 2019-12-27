using Castle.DynamicProxy;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interceptor
{
    public class MyDbConnInterceptor : IInterceptor
    {

        IServiceProvider s;
        public MyDbConnInterceptor(IServiceProvider s) 
        {
            this.s = s;
        }
        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            if (invocation.Method.Name == "Open") 
            {
                Console.WriteLine("开始链接");
            }
            if (invocation.Method.Name == "Dispose")
            {
                Console.WriteLine("开始断开链接");
            }
           
            invocation.Proceed();
            if (invocation.Method.Name == "Open")
            {
                Console.WriteLine("已链接,耗时:" +stopwatch.ElapsedMilliseconds + " ms");
            }
            if (invocation.Method.Name == "Dispose")
            {
                Console.WriteLine("已断开");
            }
        }
    }
}
