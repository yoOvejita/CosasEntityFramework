using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosasEntityFramework.Modelos
{
    [Table("materia_cursada", Schema = "desarrollo")]
    public class MateriaCursada
    {
        [Key]
        public int id_m_c { get; set; }
        public int idEst { get; set; }
        public string idMat { get; set; }
        public decimal calificacion { get; set; }
        public virtual Estudiante estudiante { get; set; }
        public virtual Materia materia { get; set; }
    }
}
