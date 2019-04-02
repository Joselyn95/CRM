using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Empresa
    {
        public int Id_Empresa { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Cedula { get; set; }

        public string Pais { get; set; }

        public int? Id_Provincia { get; set; }

        public int? Id_Canton { get; set; }

        public int? Id_Distrito { get; set; }

        public string Otras_Señas { get; set; }

        public int Codigo_Postal { get; set; }
        public Provincia Provincia { get; set; }
        public Canton Canton { get; set; }
        public Distrito Distrito { get; set; }
        public Empresa()
        {
            Provincia = new Provincia();
            Canton = new Canton();
            Distrito = new Distrito();
        }

    }
}
