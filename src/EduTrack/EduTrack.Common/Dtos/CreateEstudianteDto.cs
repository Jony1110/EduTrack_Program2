using EduTrack.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EduTrack.API.Dtos
{
    public class CreateEstudianteDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public string Birthdate { get; set; }
        public bool IsActive { get; set; }
    }
}
