using EduTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Persistence
{
    public class EduTrackDbContext : DbContext
    {
        public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options) : base(options)
        {

        }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<ClaseDetalle> ClaseDetalles { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
