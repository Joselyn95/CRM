using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
  public  class Contacto
    {
        public int Id_Contacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Puesto { get; set; }
        public int Empresa { get; set; }

        public Contacto()
        {

        }

        public Contacto(int id_Contacto, string nombre, string apellido1, string apellido2, string puesto, int empresa)
        {
            Id_Contacto = id_Contacto;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Puesto = puesto;
            Empresa = empresa;
        }
    }
}
