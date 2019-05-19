using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsStore.Common.EmailSender.Interface;
using ProductsStore.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProductsStore.Controllers
{
    public class HomeController : Controller
    {
        private const string AppMainEmailAddress = "mytestedauctionsystem@gmail.com";
        private readonly IEmailSender emailSender;

        public HomeController(IEmailSender emailSender)
        {

            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
           

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
