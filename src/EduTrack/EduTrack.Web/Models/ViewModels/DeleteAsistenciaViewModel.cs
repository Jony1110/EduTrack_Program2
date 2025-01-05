using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class DeleteAsistenciaViewModel
    {
        [Required]
        public int Id_Asistencia { get; set; }

        public string ClaseNombre { get; set; } // Nombre de la clase asociado

        public string NombreEstudiante { get; set; } // Nombre completo del estudiante

        public string Fecha { get; set; } // Fecha en formato varchar

        public string Estado { get; set; } // Estado de la asistencia
    }
}
