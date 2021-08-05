using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNoodles.Controllers
{
    [Route("admin/[controller]/[action]")]
    public class AdminUserController : Controller
    {
        public List<string> Index()
        {
            return new List<string>() { "WDS"};
        }
    }
}
