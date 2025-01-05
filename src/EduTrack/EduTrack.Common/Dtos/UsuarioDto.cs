using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }

        [MaxLength(20)]
        public string Matricula { get; set; } // Puede ser null para admins

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } // Rol del usuario (Root, AdminEscuela, Profesor, Estudiante)

        [Required]
        [MaxLength(50)]
        public string FechaRegistro { get; set; } // Fecha de registro como string

        public bool Activo { get; set; } // Estado activo o inactivo
    }

}
