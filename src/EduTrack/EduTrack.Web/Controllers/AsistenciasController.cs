using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Web.Controllers
{
    public class AsistenciasController : Controller
    {
        public AsistenciasController()
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

        // GET: Asistencias/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["AsistenciaId"] = id; // ID de la asistencia
            return View();
        }

    }
}
