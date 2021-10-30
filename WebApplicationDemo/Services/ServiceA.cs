﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;

namespace WebApplicationDemo.Services
{
    public class ServiceA : IServiceA
    {
        public ServiceA()
        {
            Console.WriteLine("Service A constructor");
        }

        public void Show()
        {
            Console.WriteLine("Show from A...");
        }
    }
}
