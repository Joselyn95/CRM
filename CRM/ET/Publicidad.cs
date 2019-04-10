using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Publicidad
    {
        public int Id_Publicidad { get; set; }
        public String Medio { get; set; }
        public int Id_Empresa { get; set; }
        public String FechaInicio { get; set; }
        public String FechaCaducidad { get; set; }
        public int Costo { get; set; }

        public Publicidad()
        {

        }
    }
}
