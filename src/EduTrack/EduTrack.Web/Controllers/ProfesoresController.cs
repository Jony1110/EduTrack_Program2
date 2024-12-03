using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Web.Controllers
{
    public class ProfesoresController : Controller
    {
        public ProfesoresController()
        {

        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            return View();
        }

       // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            return View();
        }

        
    }
}
