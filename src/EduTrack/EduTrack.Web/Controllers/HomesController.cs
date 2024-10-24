using EduTrack.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EduTrack.Web.Controllers
{
    public class HomeController : Controller
    {
       public HomeController()
        {
        }

        public IActionResult Maestro()
        {
            return View();
        }

        public IActionResult Index()
        {
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
