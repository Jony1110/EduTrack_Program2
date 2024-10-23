using EduTrack.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Web.Data
{
    public class EduTrackDbContext: DbContext
    {
        public EduTrackDbContext(DbContextOptions < EduTrackDbContext> options): base (options) 
        {
          
        }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<ClaseDetalle> ClaseDetalles { get; set; }
    }
}
