using EduTrack.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EduTrack.API.Dtos
{
    public class CreateAsistenciaRequest
    {
        public int id_asistencia { get; set; }
        public int id_clase { get; set; }
        public int id_estudiante { get; set; }
        public string fecha { get; set; }
        public string estado { get; set; } // Estado de la asistencia
        public string nota { get; set; } // Descripcion de la asistencia
    }

}
