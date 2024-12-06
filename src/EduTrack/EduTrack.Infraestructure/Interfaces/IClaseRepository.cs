using EduTrack.API.Dtos;
using EduTrack.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastructure.Repositories
{
    public interface IClaseRepository
    {
        Task<List<ClaseDto>> GetAll();
        Task<ClaseDto> Get(int id);
        Task<CreateClaseResponse> Add(CreateClaseRequest request);
    }
}
