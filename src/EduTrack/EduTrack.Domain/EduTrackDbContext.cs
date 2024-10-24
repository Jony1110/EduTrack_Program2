﻿using EduTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Domain
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
