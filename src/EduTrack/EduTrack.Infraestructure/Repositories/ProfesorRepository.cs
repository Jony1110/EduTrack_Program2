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

        public async Task<List<ProfesorDto>> GetAll()
        {
            var profesoresFromDb = await _context.Profesores.ToListAsync();
            var profesores = new List<ProfesorDto>();

            if (!profesoresFromDb.Any())
                throw new Exception("No Data Found");

            foreach (var item in profesoresFromDb)
            {
                profesores.Add(new ProfesorDto
                {
                    Id = item.Id,
                    Gender = item.Gender,
                    Email = item.Email,
                    IsActive = item.IsActive,
                    Lastname = item.Lastname,
                    Name = item.Name,
                    Phone = item.Phone

                });
            }
            return profesores;
        }
        public async Task<List<ProfesorDto>> Get(int id)
        {
            var profesoreFromDb = await _context.Profesores.ToListAsync();
            var profesores = new List<ProfesorDto>();

            if (!profesoreFromDb.Any())
                throw new Exception("No Data Found");

            foreach (var item in profesoreFromDb)
            {
                profesores.Add(new ProfesorDto
                {
                    Id = item.Id,
                    Gender = item.Gender,
                    Email = item.Email,
                    IsActive = item.IsActive,
                    Lastname = item.Lastname,
                    Name = item.Name,
                    Phone = item.Phone

                });
            }
            return profesores;
        }
    }
}
