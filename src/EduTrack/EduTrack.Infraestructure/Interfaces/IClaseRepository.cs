using EduTrack.API.Dtos;
using EduTrack.Domain.ViewModels;

namespace EduTrack.Infrastructure.Repositories
{
    public interface IClaseRepository
    {
        Task<List<ClaseDto>> GetAll();
        Task<ClaseDto> Get(int id);
        Task<CreateClaseResponse> Add(CreateClaseRequest request);
    }
}
