using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Recordatorio
    {
        public int Id_Recordatorio { get; set; }
        public String Tipo { get; set; }
        public String Fecha { get; set; }
        public int Hora { get; set; }
        public int Minutos { get; set; }
        public String Abreviatura { get; set; }
        public String Detalle { get; set; }
        public int Id_Empresa { get; set; }
    }
}
