using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public String Nombre { get; set; }
        public String Apellido1 { get; set; }
        public String Apellido2 { get; set; }
        public String Correo { get; set; }
        public String Clave { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int Rol_id{ get; set; }

        public Rol Rol { get; set; }

        public Usuario()
        {
            Rol = new Rol();
        }
    }
}
