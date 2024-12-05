using EduTrack.API.Dtos;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;
using EduTrack.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Infraestructure.Repositories
{
    public class EstudianteRepository
    {
        private readonly EduTrackDbContext _context;

        public EstudianteRepository(EduTrackDbContext context)
        {
            this._context = context;
        }

        // Obtener todos los estudiantes
        public async Task<List<EstudianteDto>> GetAll()
        {
            var estudiantesFromDb = await _context.Estudiantes.ToListAsync();
            var estudiantes = new List<EstudianteDto>();

            if (!estudiantesFromDb.Any())
                throw new Exception("No Data Found");

            foreach (var estudianteDb in estudiantesFromDb)
            {
                estudiantes.Add(new EstudianteDto
                {
                    Id = estudianteDb.Id,
                    Gender = estudianteDb.Gender,
                    Email = estudianteDb.Email,
                    IsActive = estudianteDb.IsActive,
                    Lastname = estudianteDb.Lastname,
                    Name = estudianteDb.Name,
                    Phone = estudianteDb.Phone,
                    Birthdate = estudianteDb.Birthdate
                });
            }
            return estudiantes;
        }

        // Obtener un estudiantes por su ID
        public async Task<EstudianteDto> Get(int id)
        {
            var estudianteDb = await _context.Estudiantes.FindAsync(id);

            if (estudianteDb == null)
                throw new Exception("No Data Found");

            return new EstudianteDto
            {
                Id = estudianteDb.Id,
                Gender = estudianteDb.Gender,
                Email = estudianteDb.Email,
                IsActive = estudianteDb.IsActive,
                Lastname = estudianteDb.Lastname,
                Name = estudianteDb.Name,
                Phone = estudianteDb.Phone,
                Birthdate = estudianteDb.Birthdate
            };
        }

        // Agregar un nuevo estudiantes
        public async Task<CreateEstudianteResponse> Add(CreateEstudianteRequest request)
        {
            var dbEstudiante = new Estudiante
            {
                Name = request.Name,
                Lastname = request.Lastname,
                Email = request.Email,
                Phone = request.Phone,
                Gender = request.Gender,
                Birthdate = request.Birthdate,
                IsActive = request.IsActive
            };

            _context.Estudiantes.Add(dbEstudiante);
            await _context.SaveChangesAsync();

            return new CreateEstudianteResponse { Id = dbEstudiante.Id };
        }

        // Actualizar un estudiantes existente
        public async Task<EstudianteDto> Update(int id, CreateEstudianteRequest request)
        {
            var estudianteDb = await _context.Estudiantes.FindAsync(id);

            if (estudianteDb == null)
                throw new Exception("Estudiante not found");

            // Actualizar las propiedades del estudiantes
            estudianteDb.Name = request.Name;
            estudianteDb.Lastname = request.Lastname;
            estudianteDb.Email = request.Email;
            estudianteDb.Phone = request.Phone;
            estudianteDb.Gender = request.Gender;
            estudianteDb.Birthdate = request.Birthdate;
            estudianteDb.IsActive = request.IsActive;

            // Guardar los cambios
            await _context.SaveChangesAsync();

            return new EstudianteDto
            {
                Id = estudianteDb.Id,
                Gender = estudianteDb.Gender,
                Email = estudianteDb.Email,
                IsActive = estudianteDb.IsActive,
                Lastname = estudianteDb.Lastname,
                Name = estudianteDb.Name,
                Phone = estudianteDb.Phone,
                Birthdate = estudianteDb.Birthdate
            };
        }

        // Eliminar un estudiantes
        public async Task Delete(int id)
        {
            var estudianteDb = await _context.Estudiantes.FindAsync(id);

            if (estudianteDb == null)
                throw new Exception("Estudiante not found");

            // Eliminar el estudiantes de la base de datos
            _context.Estudiantes.Remove(estudianteDb);
            await _context.SaveChangesAsync();
        }
    }
}
