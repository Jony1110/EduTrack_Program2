using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class EditAsistenciaViewModel
    {
        public int Id_Asistencia { get; set; }

        [Required]
        public int Id_Clase { get; set; }

        [Required]
        public int Id_Estudiante { get; set; }

        [Required]
        public string Fecha { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }

        [StringLength(255)]
        public string Nota { get; set; }
    }

}
