using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduTrack.Web.Data;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;

namespace EduTrack.Web.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly EduTrackDbContext _context;

        public ProfesoresController(EduTrackDbContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesores.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProfesorViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dbProfesor = new Profesor();

                //dbProfesor.Id = vm.Id;
                dbProfesor.Name = vm.Name;
                dbProfesor.Lastname = vm.Lastname;
                dbProfesor.Email = vm.Email;
                dbProfesor.Phone = vm.Phone;
                dbProfesor.Gender = vm.Gender;
                dbProfesor.Birthdate = vm.Birthdate;
                dbProfesor.IsActive = vm.IsActive;

                _context.Profesores.Add(dbProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           
            var profesorDb = await _context.Profesores.FindAsync(id);

            if (profesorDb == null)
            {
                return NotFound();
            }

            var vm = new EditProfesorViewModel();

            vm.Id = profesorDb.Id;
            vm.Name = profesorDb.Name;
            vm.Lastname = profesorDb.Lastname;
            vm.Email = profesorDb.Email;
            vm.Phone = profesorDb.Phone;
            vm.Gender = profesorDb.Gender;
            vm.Birthdate = profesorDb.Birthdate;
            vm.IsActive = profesorDb.IsActive;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProfesorViewModel vm)
        {

            var dbProfesor = await _context.Profesores.FindAsync(id);

            //if (id != vm.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {


                //var dbProfesor = new EditProfesorViewModel();
                
                dbProfesor.Name = vm.Name;
                dbProfesor.Lastname = vm.Lastname;
                dbProfesor.Email = vm.Email;
                dbProfesor.Phone = vm.Phone;
                dbProfesor.Gender = vm.Gender;
                dbProfesor.Birthdate = vm.Birthdate;
                dbProfesor.IsActive = vm.IsActive;

                _context.Profesores.Update(dbProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var profesorDb = await _context.Profesores.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }

            //var profesor = await _context.Profesores
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (profesor == null)
            //{
            //    return NotFound();
            //}

            var vm = new DeleteProfesorViewModel();
            {
                vm.Id = profesorDb.Id;
                vm.Name = profesorDb.Name;
                vm.Lastname = profesorDb.Lastname;
                vm.Email = profesorDb.Email;
                vm.Phone = profesorDb.Phone;
                vm.Gender = profesorDb.Gender;
                vm.Birthdate = profesorDb.Birthdate;
                vm.IsActive = profesorDb.IsActive;
            }

            return View(vm);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, DeleteProfesorViewModel vm)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }
    }
}
