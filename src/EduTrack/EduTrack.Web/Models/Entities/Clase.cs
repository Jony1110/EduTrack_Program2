using System.ComponentModel.DataAnnotations;

namespace EduTrack.Web.Models.Entities
{
    public class Clase
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NameClass { get; set; }
        public int ProfesorId { get; set; } 
        public Profesor Profesor {  get; set; }
        [StringLength(100)]
        public string Schedule { get; set; }
       
    }
}
