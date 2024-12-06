using EduTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Persistence
{
    public class EduTrackDbContext : DbContext
    {
        public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options) : base(options)
        {
        }

        // Definición de DbSets
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<ClaseDetalle> ClaseDetalles { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        // Configuración de relaciones y reglas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clase>()
            .HasOne(c => c.Profesor)
            .WithMany(p => p.Clases)
            .HasForeignKey(c => c.ProfesorId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
