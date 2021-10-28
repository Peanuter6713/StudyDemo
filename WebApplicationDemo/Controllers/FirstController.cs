using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;

namespace WebApplicationDemo.Controllers
{
    public class FirstController : Controller
    {
        private readonly IServiceA _serviceA = null;
        private readonly IServiceProvider _serviceProvider = null;
        private readonly IServiceB _serviceB = null;

        public FirstController(IServiceA serviceA, IServiceProvider serviceProvider, IServiceB serviceB)
        {
            _serviceA = serviceA;
            _serviceProvider = serviceProvider;
            _serviceB = serviceB;
        }

        public IActionResult Index()
        {

            IServiceA serviceA = (IServiceA)_serviceProvider.GetService(typeof(IServiceA));
            serviceA.Show();

            return View();
        }
    }
}
