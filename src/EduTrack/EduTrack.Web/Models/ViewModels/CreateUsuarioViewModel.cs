using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class CreateUsuarioViewModel
    {
        public int Id { get; set; } // Identificador del usuario

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } // Nombre del usuario

        [MaxLength(20)]
        public string Matricula { get; set; } // Matrícula, opcional para algunos roles

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; } // Correo electrónico

        [MaxLength(20)]
        public string Phone { get; set; } // Teléfono

        [Required]
        [MaxLength(1)]
        public string Gender { get; set; } // Género

        [MaxLength(15)]
        public string Birthdate { get; set; } // Fecha de nacimiento

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } // Rol del usuario

        [MaxLength(50)]
        public string FechaRegistro { get; set; } // Fecha de registro

        public bool IsActive { get; set; } // Estado activo o inactivo
    }
}
