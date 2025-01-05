using EduTrack.API.Dtos;
using EduTrack.Domain.Entities;
using EduTrack.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infraestructure.Repositories
{
    public interface IAsistenciaRepository
    {
        //Firma

        Task<List<AsistenciaDto>> GetAll();
        Task<AsistenciaDto> Get(int id);
        Task<CreateAsistenciaResponse> Add(CreateAsistenciaRequest request);

    }
}
