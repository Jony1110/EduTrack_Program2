using EduTrack.Domain.ViewModels;
using EduTrack.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infraestructure.Repositories
{
    public class ProfesorRepository
    {
        private readonly EduTrackDbContext _context;

        public ProfesorRepository(EduTrackDbContext context) 
        {
            this._context = context;
        }

        public async Task <List<ProfesorDto>> GetAll()
        {
            var profesoresFromDb = await _context.Profesores.ToListAsync();
            var profesores = new List<ProfesorDto>();

            if (!profesoresFromDb.Any())
                throw new Exception("No Data Found");
            
            foreach (var item in profesoresFromDb)
            {
                profesores.Add(new ProfesorDto 
                {
                
                });
            }
        }
    }
}
