using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using CRM.DAL;

namespace BL
{
    public class ServicioEmpresaBL
    {
        private ServicioEmpresaDAL servicioEmpDAL= new ServicioEmpresaDAL();

        public List<ServicioEmpresa> Listar()
        {
            return servicioEmpDAL.Listar();
        }

        public ServicioEmpresa Obtener(int id)
        {
            return servicioEmpDAL.Obtener(id);
        }

        public bool Actualizar(ServicioEmpresa servicio)
        {
            return servicioEmpDAL.Actualizar(servicio);
        }

        public bool Registrar(ServicioEmpresa servicio)
        {
            return servicioEmpDAL.Registrar(servicio);
        }
    }
}
