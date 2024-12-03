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

        // Obtener todos los profesores
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

        // Obtener un profesor por su ID
        public async Task<ProfesorDto> Get(int id)
        {
            var profesorDb = await _context.Profesores.FindAsync(id);

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

        // Agregar un nuevo profesor
        public async Task<CreateProfesorResponse> Add(CreateProfesorRequest request)
        {
            var dbProfesor = new Profesor
            {
                Name = request.Name,
                Lastname = request.Lastname,
                Email = request.Email,
                Phone = request.Phone,
                Gender = request.Gender,
                Birthdate = request.Birthdate,
                IsActive = request.IsActive
            };

            _context.Profesores.Add(dbProfesor);
            await _context.SaveChangesAsync();

            return new CreateProfesorResponse { Id = dbProfesor.Id };
        }

        // Actualizar un profesor existente
        public async Task<ProfesorDto> Update(int id, CreateProfesorRequest request)
        {
            var profesorDb = await _context.Profesores.FindAsync(id);

            if (profesorDb == null)
                throw new Exception("Profesor not found");

            // Actualizar las propiedades del profesor
            profesorDb.Name = request.Name;
            profesorDb.Lastname = request.Lastname;
            profesorDb.Email = request.Email;
            profesorDb.Phone = request.Phone;
            profesorDb.Gender = request.Gender;
            profesorDb.Birthdate = request.Birthdate;
            profesorDb.IsActive = request.IsActive;

            // Guardar los cambios
            await _context.SaveChangesAsync();

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

        // Eliminar un profesor
        public async Task Delete(int id)
        {
            var profesorDb = await _context.Profesores.FindAsync(id);

            if (profesorDb == null)
                throw new Exception("Profesor not found");

            // Eliminar el profesor de la base de datos
            _context.Profesores.Remove(profesorDb);
            await _context.SaveChangesAsync();
        }
    }
}
