using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class AsistenciaViewModel
    {
        public int Id_Asistencia { get; set; }
        public int Id_Clase { get; set; }
        public int Id_Estudiante { get; set; }
        public string ClaseNombre { get; set; } // Nombre de la clase asociado
        public string NombreEstudiante { get; set; } // Nombre completo del estudiante
        public string Fecha { get; set; } // Fecha en formato string (puedes cambiar a DateTime si prefieres)
        public string Estado { get; set; } // Presente, Ausente, Tarde, etc.
        public string Nota { get; set; } // Nota opcional
    }
}
