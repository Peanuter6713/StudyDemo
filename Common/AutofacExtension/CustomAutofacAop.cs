using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AutofacExtension
{
    public class CustomAutofacAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            {
                Console.WriteLine("Before method running...");
            }

            invocation.Proceed();

            {
                Console.WriteLine("After method running...");
            }
        }
    }
}
