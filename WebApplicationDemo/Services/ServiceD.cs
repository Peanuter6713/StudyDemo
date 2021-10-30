using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;

namespace WebApplicationDemo.Services
{
    public class ServiceD : IServiceD
    {
        public IServiceA _ServiceA { get; set; }
        public IServiceB _ServiceB { get; set; }
        public IServiceC _ServiceC { get; set; } 


        public ServiceD()
        {
            Console.WriteLine("Service D constructor");
        }

        public void Show()
        {
            Console.WriteLine("this is from ServiceD");
        }
    }
}
