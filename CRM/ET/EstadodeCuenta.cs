using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
  public  class EstadodeCuenta
    {
       
        public int Id_Estado { get; set; }
        public int Id_Credito_Disponible { get; set; }
        public int Empresa { get; set; }


        public EstadodeCuenta(int idEstado, int id_Credito_Disponible, int empresa)
        {
            Id_Estado = idEstado;
            Id_Credito_Disponible = id_Credito_Disponible;
            Empresa = empresa;
        }

        public EstadodeCuenta()
        {
        }
    }

}
