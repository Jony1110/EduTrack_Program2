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

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CreateProfesorViewModel vm)
        //{

        //    return View();
        //}

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id)
        //{

        //    //var dbProfesor = await _context.Profesores.FindAsync(id);

        //    ////if (id != vm.Id)
        //    ////{
        //    ////    return NotFound();
        //    ////}

        //    //if (ModelState.IsValid)
        //    //{


        //    //    //var dbProfesor = new EditProfesorViewModel();

        //    //    dbProfesor.Name = vm.Name;
        //    //    dbProfesor.Lastname = vm.Lastname;
        //    //    dbProfesor.Email = vm.Email;
        //    //    dbProfesor.Phone = vm.Phone;
        //    //    dbProfesor.Gender = vm.Gender;
        //    //    dbProfesor.Birthdate = vm.Birthdate;
        //    //    dbProfesor.IsActive = vm.IsActive;

        //    //    _context.Profesores.Update(dbProfesor);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    return View();
        //}

        // GET: Profesores/Delete/5
        //public async Task<IActionResult> Delete(int id)
        //{
        //    //var profesorDb = await _context.Profesores.FindAsync(id);

        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var profesor = await _context.Profesores
        //    //    .FirstOrDefaultAsync(m => m.Id == id);
        //    //if (profesor == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var vm = new DeleteProfesorViewModel();
        //    //{
        //    //    vm.Id = profesorDb.Id;
        //    //    vm.Name = profesorDb.Name;
        //    //    vm.Lastname = profesorDb.Lastname;
        //    //    vm.Email = profesorDb.Email;
        //    //    vm.Phone = profesorDb.Phone;
        //    //    vm.Gender = profesorDb.Gender;
        //    //    vm.Birthdate = profesorDb.Birthdate;
        //    //    vm.IsActive = profesorDb.IsActive;
        //    //}

        //    return View();
        //}

        // POST: Profesores/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id, DeleteProfesorViewModel vm)
        //{
        //    var profesor = await _context.Profesores.FindAsync(id);
        //    if (profesor != null)
        //    {
        //        _context.Profesores.Remove(profesor);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProfesorExists(int id)
        //{
        //    return _context.Profesores.Any(e => e.Id == id);
        //}
    }
}
