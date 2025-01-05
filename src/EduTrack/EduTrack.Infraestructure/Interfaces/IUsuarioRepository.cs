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
    public interface IUsuarioRepository
    {
        //Firma

        Task<List<UsuarioDto>> GetAll();
        Task<UsuarioDto> Get(int id);
        Task<CreateUsuarioResponse> Add(CreateUsuarioRequest request);
        
    }
}
