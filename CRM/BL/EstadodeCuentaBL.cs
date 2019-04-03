using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using CRM.DAL;

namespace BL
{
  public  class EstadodeCuentaBL
    {
        private EstadodeCuentaDAL estadoDAL = new EstadodeCuentaDAL();

        public List<EstadodeCuenta> Listar()
        {
            return estadoDAL.Listar();
        }

        public EstadodeCuenta Obtener(int id)
        {
            return estadoDAL.Obtener(id);
        }

        public bool Actualizar(EstadodeCuenta estado)
        {
            return estadoDAL.Actualizar(estado);
        }

        public bool Registrar(EstadodeCuenta estado)
        {
            return estadoDAL.Registrar(estado);
        }
    }
}
