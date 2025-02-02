using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {

        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["UsuarioId"] = id; // ID del usuario
            return View();
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["UsuarioId"] = id; // ID del usuario
            return View();
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["UsuarioId"] = id; // ID del usuario
            return View();
        }
    }
}
