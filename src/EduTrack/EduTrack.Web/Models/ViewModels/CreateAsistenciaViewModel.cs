using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class CreateAsistenciaViewModel
    {
        [Required]
        public int Id_Clase { get; set; }

        [Required]
        public int Id_Estudiante { get; set; }

        [Required]
        public string Fecha { get; set; } // Fecha en formato varchar

        [Required]
        [StringLength(50)]
        public string Estado { get; set; } // Presente, Ausente, Tarde

        [StringLength(255)]
        public string Nota { get; set; } // Nota opcional
    }
}
