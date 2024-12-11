using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.ViewModels
{
    public class DeleteClaseDto
    {
        [Required(ErrorMessage = "El nombre de la clase es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la clase no puede exceder los 100 caracteres.")]
        public string NameClass { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio.")]
        [StringLength(100, ErrorMessage = "El horario no puede exceder los 100 caracteres.")]
        public string Schedule { get; set; }

        [Required(ErrorMessage = "Debe especificar el ID del profesor.")]
        public int ProfesorId { get; set; }
    }
}
