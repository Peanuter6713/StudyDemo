using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;
using WebApplicationDemo.Utils.AutofacExtension;

namespace WebApplicationDemo.Controllers
{
    public class SixController : Controller
    {
        [CustomPropertyAttribute]
        private IServiceA serviceA { get; set; }
        private IServiceB serviceB { get; set; }
        private IServiceC serviceC { get; set; }
        private IServiceD serviceD { get; set; }

        private readonly IServiceA _serviceA;
        private readonly IServiceB _serviceB;
        private readonly IServiceC _serviceC;
        private readonly IServiceD _serviceD;

        public SixController(IServiceA serviceA, IServiceB serviceB, IServiceC serviceC, IServiceD serviceD)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
            _serviceC = serviceC;
            _serviceD = serviceD;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
