using EduTrack.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EduTrack.API.Dtos
{
    public class CreateUsuarioResponse
    {
        public int Id { get; set; } // ID del usuario creado

        public string Nombre { get; set; } // Nombre del usuario

        public string Correo { get; set; } // Correo electrónico

        public string Rol { get; set; } // Rol asignado

        public bool Activo { get; set; } // Estado del usuario
    }

}
