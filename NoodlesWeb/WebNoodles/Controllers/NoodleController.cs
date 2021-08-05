using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNoodles.Controllers
{
    public class NoodleController : Controller
    {
        public IList<string> Index()
        {
            return new List<string>() { "牛肉面", "鸡蛋面"};
        }
    }
}
