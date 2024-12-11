using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Web.Controllers
{
    public class ClasesController : Controller
    {
        public ClasesController()
        {

        }

        // GET: Clases
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Clases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        // GET: Clases/Create
        public IActionResult Create()
        {
            return View();
        }

       // GET: Clases/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["ClaseId"] = id;
            return View();
        }

        
    }
}
