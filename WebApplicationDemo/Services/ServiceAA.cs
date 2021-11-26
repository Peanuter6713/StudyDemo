using Autofac.Extras.DynamicProxy;
using Common.AutofacExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;

namespace WebApplicationDemo.Services
{
    [Intercept(typeof(CustomAutofacAop))]
    public class ServiceAA : IServiceA
    {
        public ServiceAA()
        {
        }

        public virtual void Show()
        {
            Console.WriteLine("ServiceAA");
        }
    }
}
