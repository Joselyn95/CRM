using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ServicioEmpresa
    {
        public int Id_ServicioEmpresa { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Tipo_Servicio { get; set; }
        public int Cantidad_Inventario { get; set; }
        public double Precio { get; set; }
        public int Id_Empresa { get; set; }

        public ServicioEmpresa(){
        }
    }
}
