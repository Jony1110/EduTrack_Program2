using EduTrack.API.Dtos;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;
using EduTrack.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Infraestructure.Repositories
{
    public class ProfesorRepository
    {
        private readonly EduTrackDbContext _context;

        public ProfesorRepository(EduTrackDbContext context)
        {
            this._context = context;
        }

        public async Task<List<ProfesorDto>> GetAll()
        {
            var profesoresFromDb = await _context.Profesores.ToListAsync();
            var profesores = new List<ProfesorDto>();

            if (!profesoresFromDb.Any())
                throw new Exception("No Data Found");

            foreach (var profesorDb in profesoresFromDb)
            {
                profesores.Add(new ProfesorDto
                {
                    Id = profesorDb.Id,
                    Gender = profesorDb.Gender,
                    Email = profesorDb.Email,
                    IsActive = profesorDb.IsActive,
                    Lastname = profesorDb.Lastname,
                    Name = profesorDb.Name,
                    Phone = profesorDb.Phone

                });
            }
            return profesores;
        }
        public async Task<ProfesorDto> Get(int id)
        {
            var profesorDb = await _context.Profesores.FindAsync(id);
            //var profesores = new ProfesorDto();

            if (profesorDb == null)
                throw new Exception("No Data Found");

            return new ProfesorDto
            {
                Id = profesorDb.Id,
                Gender = profesorDb.Gender,
                Email = profesorDb.Email,
                IsActive = profesorDb.IsActive,
                Lastname = profesorDb.Lastname,
                Name = profesorDb.Name,
                Phone = profesorDb.Phone

            };

        }

        public async Task<CreateProfesorResponse> Add(CreateProfesorRequest request)
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
