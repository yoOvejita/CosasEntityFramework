using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosasEntityFramework.Modelos
{
    [Table("Telefono")]
    public class Telefono
    {
        [Key]
        public int idTelefono { get; set; }
        public int codigoEst { get; set; }
        public int numero { get; set; }
        public virtual Estudiante estudiante { get; set; }
    }
}
