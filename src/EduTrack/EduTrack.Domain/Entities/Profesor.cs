using EduTrack.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace EduTrack.Domain.Entities
{
    public class Profesor: BaseEntity
    {
        //[Key]
        //public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        public char Gender { get; set; }
        [StringLength(15)]
        
        public string Birthdate { get; set; }
        public bool IsActive { get; set; } 
        public List<Clase> Clases { get; set; }


    }
}
