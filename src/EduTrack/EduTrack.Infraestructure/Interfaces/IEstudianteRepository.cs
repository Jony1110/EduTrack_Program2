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
    public interface IEstudianteRepository
    {
        //Firma

        Task<List<ProfesorDto>> GetAll();
        Task<ProfesorDto> Get(int id);
        Task<CreateProfesorResponse> Add(CreateProfesorRequest request);
        
    }
}
