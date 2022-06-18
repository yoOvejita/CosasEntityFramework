using System;
using System.Collections.Generic;
using System.Text;

namespace CosasEntityFramework.Modelos
{
    public class Telefono
    {
        public int idTelefono { get; set; }
        public int codigoEst { get; set; }
        public int numero { get; set; }
        public virtual Estudiante estudiante { get; set; }
    }
}
