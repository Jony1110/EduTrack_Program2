using EduTrack.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EduTrack.API.Dtos
{
    public class CreateClaseRequest
    {
        public string NameClass { get; set; }
        public string Schedule { get; set; }
        public int ProfesorId { get; set; }
    }

}
