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
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } // <-- Añadir aquí



        //Configuración de relaciones y reglas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clase>()
                .HasOne(c => c.Profesor)
                .WithMany(p => p.Clases)
                .HasForeignKey(c => c.ProfesorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación entre Asistencia y Clase (Muchos a Uno)
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Clase)
                .WithMany(c => c.Asistencias)
                .HasForeignKey(a => a.Id_Clase)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación entre Asistencia y Estudiante (Muchos a Uno)
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Estudiante)
                .WithMany(e => e.Asistencias)
                .HasForeignKey(a => a.Id_Estudiante)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para la tabla Usuarios
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Correo) // Correo único
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Nombre) // Nombre único
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Matricula) // Matrícula única solo si no es NULL
                .IsUnique();
        }

    }
}
