using EduTrack.API.Dtos;
using EduTrack.Domain;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;
using EduTrack.Infraestructure.Repositories;
using EduTrack.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly ProfesorRepository _repo;

        public ProfesorController(ProfesorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetProfesor/{id}")]
        public async Task<ActionResult<ProfesorDto>> GetProfesor(int id)
        {
            var profesorDb = await _context.Profesores.FindAsync(id);
            if (profesorDb == null)
            {
                return NotFound();
            }

            var response = new ProfesorDto
            {
                Id = profesorDb.Id,
                Gender = profesorDb.Gender,
                Email = profesorDb.Email,
                IsActive = profesorDb.IsActive,
                Lastname = profesorDb.Lastname,
                Name = profesorDb.Name,
                Phone = profesorDb.Phone
            };


            //return profesorDb;
            return response;

        }

        [HttpGet(nameof(GetProfesores))]
        public async Task<ActionResult<List<ProfesorDto>>> GetProfesores()
        {
            var profesores = await _repo.GetAll();

            return profesores;
        }

        [HttpPost(nameof(AddProfesor))]
        public async Task<ActionResult<CreateProfesorResponse>> AddProfesor(CreateProfesorRequest request)
        {
            var dbProfesor = new Profesor();

            //dbProfesor.Id = vm.Id;
            dbProfesor.Name = request.Name;
            dbProfesor.Lastname = request.Lastname;
            dbProfesor.Email = request.Email;
            dbProfesor.Phone = request.Phone;
            dbProfesor.Gender = request.Gender;
            dbProfesor.Birthdate = request.Birthdate;
            dbProfesor.IsActive = request.IsActive;

            _context.Profesores.Add(dbProfesor);
            await _context.SaveChangesAsync();
            return new CreateProfesorResponse { Id = dbProfesor.Id };
        }


    }
}
