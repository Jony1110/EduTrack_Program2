using EduTrack.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EduTrack.API.Dtos
{
    public class AsignarProfesorRequest
    {
        public int ClaseId { get; set; }
        public int ProfesorId { get; set; }
    }


}
