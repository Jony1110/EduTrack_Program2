using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduTrack.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; } // ID autoincremental

        [StringLength(20)]
        public string? Matricula { get; set; } // Matrícula (NULL para Admins)

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } // Nombre único

        [Required]
        [StringLength(100)]
        public string Correo { get; set; } // Correo único

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; } // Contraseña cifrada

        [Required]
        [StringLength(50)]
        public string Rol { get; set; } // Rol (Root, AdminEscuela, Maestro, Estudiante)

        [Required]
        [StringLength(50)]
        public string FechaRegistro { get; set; } // Fecha de registro como string

        public bool Activo { get; set; } = true; // Estado activo/inactivo
    }
}
