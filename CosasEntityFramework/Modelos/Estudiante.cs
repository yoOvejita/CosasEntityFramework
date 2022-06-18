using System;
using System.Collections.Generic;
using System.Text;

namespace CosasEntityFramework.Modelos
{
    public class Estudiante
    {
        public int ci { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nac { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public virtual ICollection<Telefono> telefono { get; set; }
    }
}
