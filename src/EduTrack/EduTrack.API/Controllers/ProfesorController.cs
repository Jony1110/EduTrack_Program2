using EduTrack.API.Dtos;
using EduTrack.Domain;
using EduTrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly EduTrackDbContext _context;

        public ProfesorController(EduTrackDbContext context)
        {
            _context = context;
        }

        [HttpGet(nameof(GetProfesores))]
        public async Task<ActionResult<List<Profesor>>> GetProfesores()
        {
            var profesores = await _context.Profesores.ToListAsync();

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
            return new CreateProfesorResponse { Id = dbProfesor.Id};
        }
    }
}
