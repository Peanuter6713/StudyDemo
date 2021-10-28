using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        private readonly IServiceA _serviceA = null;
        private readonly IServiceB _serviceB = null;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IServiceA serviceA, IServiceB serviceB)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceA = serviceA;
            _serviceB = serviceB;

            _logger.LogWarning("HomeController Constructor ...");
        }

        public IActionResult Index()
        {
            _logger.LogInformation("This is from HomeController.");

            return View();
        }

        public IActionResult Privacy()
        {

            _serviceA.Show();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
