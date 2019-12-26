using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interceptor
{
    public class MyInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            MyInterceptAttribute attr = null;
            attr = invocation.TargetType?
              .GetCustomAttributes(typeof(MyInterceptAttribute), true).FirstOrDefault()
              as MyInterceptAttribute;

            if (attr == null)
            {
                var methodInfo = invocation.MethodInvocationTarget;
                if (methodInfo == null)
                {
                    methodInfo = invocation.Method;
                }

                attr = methodInfo
                   .GetCustomAttributes(typeof(MyInterceptAttribute), true).FirstOrDefault()
                   as MyInterceptAttribute;
            }

            if (attr != null)
            {
                Console.WriteLine("操作开始了");
            }

            invocation.Proceed();

            if (attr != null)
            {
                Console.WriteLine("操作结束了");
            }
        }
    }
}
