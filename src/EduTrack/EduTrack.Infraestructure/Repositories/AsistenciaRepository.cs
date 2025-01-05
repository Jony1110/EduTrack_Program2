using EduTrack.API.Dtos;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;
using EduTrack.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Infraestructure.Repositories
{
    public class AsistenciaRepository
    {
        private readonly EduTrackDbContext _context;

        public AsistenciaRepository(EduTrackDbContext context)
        {
            this._context = context;
        }

        public async Task<List<AsistenciaDto>> GetAllAsistencias()
        {
            var asistenciasFromDb = await _context.Asistencias
                .Include(a => a.Estudiante) // Relación con Estudiante
                .Include(a => a.Clase)     // Relación con Clase
                .ToListAsync();

            if (!asistenciasFromDb.Any())
                throw new Exception("No Data Found");

            var asistencias = asistenciasFromDb.Select(a => new AsistenciaDto
            {
                id_asistencia = a.Id_Asistencia,
                id_clase = a.Id_Clase,
                id_estudiante = a.Id_Estudiante,
                NombreEstudiante = a.Estudiante != null ? $"{a.Estudiante.Name} {a.Estudiante.Lastname}" : "",
                ClaseNombre = a.Clase != null ? a.Clase.NameClass : "Clase no encontrada", // Usar NameClass aquí
                fecha = a.Fecha,
                estado = a.Estado,
                nota = a.Nota
            }).ToList();

            return asistencias;
        }

        // Obtener todas las asistencias de una clase en una fecha
        public async Task<List<AsistenciaDto>> GetAll(int idClase, string fecha)
        {
            var asistenciasFromDb = await _context.Asistencias
                .Include(a => a.Estudiante)
                .Where(a => a.Id_Clase == idClase && a.Fecha == fecha)
                .ToListAsync();

            if (!asistenciasFromDb.Any())
                throw new Exception("No Data Found");

            var asistencias = asistenciasFromDb.Select(a => new AsistenciaDto
            {
                id_asistencia = a.Id_Asistencia,
                id_clase = a.Id_Clase,
                id_estudiante = a.Id_Estudiante,
                NombreEstudiante = a.Estudiante != null ? $"{a.Estudiante.Name} {a.Estudiante.Lastname}" : "",
                fecha = a.Fecha,
                estado = a.Estado,
                nota = a.Nota
            }).ToList();

            return asistencias;
        }

        // Obtener una asistencia por ID
        public async Task<AsistenciaDto> Get(int id)
        {
            var asistenciaDb = await _context.Asistencias
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(a => a.Id_Asistencia == id);

            if (asistenciaDb == null)
                throw new Exception("No Data Found");

            return new AsistenciaDto
            {
                id_asistencia = asistenciaDb.Id_Asistencia,
                id_clase = asistenciaDb.Id_Clase,
                id_estudiante = asistenciaDb.Id_Estudiante,
                NombreEstudiante = asistenciaDb.Estudiante != null ? $"{asistenciaDb.Estudiante.Name} {asistenciaDb.Estudiante.Lastname}" : "",
                fecha = asistenciaDb.Fecha,
                estado = asistenciaDb.Estado,
                nota = asistenciaDb.Nota
            };
        }

        // Agregar o actualizar asistencias
        public async Task AddOrUpdate(List<CreateAsistenciaRequest> request)
        {
            foreach (var asistencia in request)
            {
                // Buscar asistencia existente por ID (en lugar de clase, estudiante y fecha)
                var asistenciaDb = await _context.Asistencias
                    .FirstOrDefaultAsync(a => a.Id_Asistencia == asistencia.id_asistencia);

                if (asistenciaDb == null)
                {
                    // Crear nueva asistencia
                    var nuevaAsistencia = new Asistencia
                    {
                        Id_Clase = asistencia.id_clase,
                        Id_Estudiante = asistencia.id_estudiante,
                        Fecha = asistencia.fecha,
                        Estado = asistencia.estado,
                        Nota = asistencia.nota
                    };

                    _context.Asistencias.Add(nuevaAsistencia);
                }
                else
                {
                    // Actualizar asistencia existente
                    asistenciaDb.Id_Clase = asistencia.id_clase;            // Modificar clase
                    asistenciaDb.Id_Estudiante = asistencia.id_estudiante;  // Modificar estudiante
                    asistenciaDb.Fecha = asistencia.fecha;                  // Modificar fecha
                    asistenciaDb.Estado = asistencia.estado;                // Modificar estado
                    asistenciaDb.Nota = asistencia.nota;                    // Modificar nota
                }
            }

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }


        // Eliminar asistencias de una clase en una fecha
        public async Task Delete(int idAsistencia, string fecha)
        {
            // Busca la asistencia específica por id_asistencia y fecha
            var asistencia = await _context.Asistencias
                .FirstOrDefaultAsync(a => a.Id_Asistencia == idAsistencia && a.Fecha == fecha);

            if (asistencia == null)
            {
                throw new Exception("La asistencia no existe.");
            }

            // Elimina la asistencia
            _context.Asistencias.Remove(asistencia);
            await _context.SaveChangesAsync();
        }

        public async Task<AsistenciaDto> Update(int id, CreateAsistenciaRequest request)
        {
            // Buscar la asistencia en la base de datos
            var asistenciaDb = await _context.Asistencias.FindAsync(id);

            // Verificar si existe
            if (asistenciaDb == null)
                throw new Exception("No se encontró la asistencia.");

            // Actualizar los campos
            asistenciaDb.Id_Clase = request.id_clase;
            asistenciaDb.Id_Estudiante = request.id_estudiante;
            asistenciaDb.Fecha = request.fecha;
            asistenciaDb.Estado = request.estado;
            asistenciaDb.Nota = request.nota;

            // Guardar los cambios
            await _context.SaveChangesAsync();

            // Devolver el objeto actualizado como DTO
            return new AsistenciaDto
            {
                id_asistencia = asistenciaDb.Id_Asistencia,
                id_clase = asistenciaDb.Id_Clase,
                id_estudiante = asistenciaDb.Id_Estudiante,
                fecha = asistenciaDb.Fecha,
                estado = asistenciaDb.Estado,
                nota = asistenciaDb.Nota
            };
        }


    }
}
