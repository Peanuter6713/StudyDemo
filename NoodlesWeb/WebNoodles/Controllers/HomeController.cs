using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNoodles.Models;
using WebNoodles.ViewModels;

namespace WebNoodles.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private INoodleRepository noodleRepository;
        private IFeedbackRepository feedbackRepository;

        public HomeController(INoodleRepository noodleRepository, IFeedbackRepository feedbackRepository)
        {
            this.noodleRepository = noodleRepository;
            this.feedbackRepository = feedbackRepository;  
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel()
            {
                Noodles = this.noodleRepository.GetAllNoodles().ToList(),
                Feedbacks = this.feedbackRepository.GetAllFeedbacks().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            return View(noodleRepository.GetNoodleById(id));
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
