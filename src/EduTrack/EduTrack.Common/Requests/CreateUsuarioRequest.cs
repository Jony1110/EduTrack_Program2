using EduTrack.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EduTrack.API.Dtos
{
    public class CreateUsuarioRequest
    {
        public int Id { get; set; } // <-- Se añadió este campo

        [MaxLength(20)]
        public string Matricula { get; set; } // Opcional para roles específicos

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Contraseña { get; set; }

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } // Rol del usuario

        [MaxLength(50)]
        public string FechaRegistro { get; set; } // Fecha de registro

        public bool Activo { get; set; } = true; // Por defecto activo
    }

}
