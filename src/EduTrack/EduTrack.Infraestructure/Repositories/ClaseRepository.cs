using EduTrack.API.Dtos;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;
using EduTrack.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Infraestructure.Repositories
{
    public class ClaseRepository
    {
        private readonly EduTrackDbContext _context;

        public ClaseRepository(EduTrackDbContext context)
        {
            this._context = context;
        }

        // Obtener todas las clases
        public async Task<List<ClaseDto>> GetAll()
        {
            var clasesFromDb = await _context.Clases.Include(c => c.Profesor).ToListAsync();
            var clases = new List<ClaseDto>();

            if (!clasesFromDb.Any())
                throw new Exception("No Data Found");

            foreach (var claseDb in clasesFromDb)
            {
                Console.WriteLine($"Clase: {claseDb.NameClass}, Profesor: {claseDb.Profesor?.Name ?? "No asignado"}");

                clases.Add(new ClaseDto
                {
                    Id = claseDb.Id,
                    NameClass = claseDb.NameClass,
                    Schedule = claseDb.Schedule,
                    ProfesorId = claseDb.ProfesorId,
                    ProfesorName = claseDb.Profesor != null
                    ? $"{claseDb.Profesor.Name} {claseDb.Profesor.Lastname}"
                    : "No asignado",
                    ProfesorInactivo = claseDb.Profesor != null && !claseDb.Profesor.IsActive // Verificar si el profesor está inactivo


                });
            }
            return clases;
        }

        // Obtener una clase por su ID
        public async Task<ClaseDto> Get(int id)
        {
            var claseDb = await _context.Clases
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (claseDb == null)
                throw new Exception("No Data Found");

            return new ClaseDto
            {
                Id = claseDb.Id,
                NameClass = claseDb.NameClass,
                Schedule = claseDb.Schedule,
                ProfesorId = claseDb.ProfesorId,
                ProfesorName = claseDb.Profesor != null
                ? $"{claseDb.Profesor.Name} {claseDb.Profesor.Lastname}"
                : "No asignado"

            };
        }

        // Agregar una nueva clase
        public async Task<CreateClaseResponse> Add(CreateClaseRequest request)
        {
            var dbClase = new Clase
            {
                NameClass = request.NameClass,
                Schedule = request.Schedule,
                //ProfesorId = request.ProfesorId
            };

            _context.Clases.Add(dbClase);
            await _context.SaveChangesAsync();

            return new CreateClaseResponse { Id = dbClase.Id };
        }

        // Actualizar una clase existente
        public async Task<ClaseDto> Update(int id, CreateClaseRequest request)
        {
            var claseDb = await _context.Clases.FindAsync(id);

            if (claseDb == null)
                throw new Exception("Clase not found");

            // Actualizar las propiedades de la clase
            claseDb.NameClass = request.NameClass;
            claseDb.Schedule = request.Schedule;
            claseDb.ProfesorId = request.ProfesorId;

            // Guardar los cambios
            await _context.SaveChangesAsync();

            return new ClaseDto
            {
                Id = claseDb.Id,
                NameClass = claseDb.NameClass,
                Schedule = claseDb.Schedule,
                ProfesorId = claseDb.ProfesorId
            };
        }

        // Eliminar una clase
        public async Task Delete(int id)
        {
            var claseDb = await _context.Clases.FindAsync(id);

            if (claseDb == null)
                throw new Exception("Clase not found");

            _context.Clases.Remove(claseDb);
            await _context.SaveChangesAsync();
        }

        // Asignar profesor a clase
        public async Task AsignarProfesorAClase(int claseId, int profesorId)
        {
            var claseDb = await _context.Clases.FindAsync(claseId);
            var profesorDb = await _context.Profesores.FindAsync(profesorId);

            if (claseDb == null)
                throw new Exception("Clase not found");

            if (profesorDb == null)
                throw new Exception("Profesor not found");

            if (!profesorDb.IsActive)
                throw new Exception("El profesor está inactivo y no puede ser asignado.");

            claseDb.ProfesorId = profesorId;
            await _context.SaveChangesAsync();
        }


        // Asignar estudiante a clase
        //public async Task AsignarEstudianteAClase(int claseId, int estudianteId)
        //{
        //    var asistencia = new Asistencia
        //    {
        //        ClaseId = claseId,
        //        EstudianteId = estudianteId,
        //        Fecha = DateTime.Now,
        //        Estado = "Presente"
        //    };

        //    _context.Asistencias.Add(asistencia);
        //    await _context.SaveChangesAsync();
        //}
    }
}
