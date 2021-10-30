using System;
using WebApplicationDemo.Interface;

namespace WebApplicationDemo.Services
{
    public class ServiceB : IServiceB
    {
        IServiceA _serviceA = null;

        public ServiceB(IServiceA serviceA)
        {
            _serviceA = serviceA;
        }

        // 方法注入
        public void SetService(IServiceA serviceA)
        {
            _serviceA = serviceA;
        }

        public void Show()
        {
            Console.WriteLine("Service B");
        }
    }
}
