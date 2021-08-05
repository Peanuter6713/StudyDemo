using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNoodles.Models;

namespace WebNoodles.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private IFeedbackRepository feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                this.feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }

            return View();
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
