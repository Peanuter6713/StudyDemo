using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;

namespace WebApplicationDemo.Services
{
    public class ServiceC : IServiceC
    {
        public void Show()
        {
            Console.WriteLine("this is from ServiceC");
        }
    }
}
