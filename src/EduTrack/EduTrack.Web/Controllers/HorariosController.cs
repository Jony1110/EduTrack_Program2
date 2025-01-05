using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Web.Controllers
{
    public class HorariosController : Controller
    {
        // Acción para la vista de horarios
        public IActionResult Index()
        {
            return View();
        }
    }
}
