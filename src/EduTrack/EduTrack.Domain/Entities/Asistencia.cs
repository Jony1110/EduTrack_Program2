using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduTrack.Domain.Entities
{
    public class Asistencia
    {
        [Key]
        [Column("id_asistencia")]
        public int Id_Asistencia { get; set; } // Equivale a id_asistencia en la tabla SQL

        [Required]
        [Column("id_clase")]
        public int Id_Clase { get; set; } // Equivale a id_clase en la tabla SQL
                
        [Required]
        [Column("id_estudiante")]
        public int Id_Estudiante { get; set; } // Equivale a id_estudiante en la tabla SQL

        [Required]
        [Column("fecha")]
        public string Fecha { get; set; } // Equivale a fecha en la tabla SQL

        [Required]
        [StringLength(50)]
        [Column("estado")]
        public string Estado { get; set; } // Equivale a estado en la tabla SQL

        [StringLength(255)]
        [Column("nota")]
        public string Nota { get; set; } // Equivale a nota en la tabla SQL


        [ForeignKey("Id_Estudiante")]
        public Estudiante Estudiante { get; set; } // Relación con la entidad Estudiante

        [ForeignKey("Id_Clase")]
        public Clase Clase { get; set; } // Relación con la entidad Clase
    }
}
