using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class ClaseDto
    {
        public int Id { get; set; }
        public string NameClass { get; set; }
        public string Schedule { get; set; }
        public int? ProfesorId { get; set; }
        public string ProfesorName { get; set; } // Nombre completo del profesor
        //public bool ProfesorIsActive { get; set; } // Indica si el profesor está activo
        //public bool SinMaestro => ProfesorId == null || !ProfesorIsActive; // Calculado
    }

}
