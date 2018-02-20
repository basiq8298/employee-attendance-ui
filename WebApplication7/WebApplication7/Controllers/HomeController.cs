using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.ViewModel;
using WebApplication7.Sevices;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [HttpGet]
        public IActionResult Prediction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Prediction(PredictionViewModel data)
        {
            var input = new PredictionViewModel
            {
                Dept = data.Dept,
                StaffID = data.StaffID,
                Date = data.Date,
                Day = data.Day,
                Event = data.Event,
                Session = data.Session,
                Weather = data.Weather,
                PotentialDay = data.PotentialDay,
                jobSatisfaction = data.jobSatisfaction,
            };
            PredictionServices ps = new PredictionServices();
            TempData["result"] = ps.ServiceCall(input);
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            ViewData["result"] = TempData["result"].ToString();
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
