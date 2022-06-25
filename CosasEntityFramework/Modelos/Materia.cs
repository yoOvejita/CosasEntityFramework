using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosasEntityFramework.Modelos
{
    [Table("Materia", Schema = "desarrollo")]
    public class Materia
    {
        [Key]
        public string sigla { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<MateriaCursada> materiasCursadas { get; set; }
        public Materia() {
            materiasCursadas = new HashSet<MateriaCursada>();
        }
    }
}
