using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using CRM.DAL;

namespace BL
{
    public class EmpresaBL
    {
        private EmpresaDAL empresaDAL = new EmpresaDAL();

        public List<Empresa> Listar()
        {
            return empresaDAL.Listar();
        }

        public Empresa Obtener(int Id_Empresa)
        {
            return empresaDAL.Obtener(Id_Empresa);
        }

        public bool Actualizar(Empresa empresa)
        {
            return empresaDAL.Actualizar(empresa);
        }

        public bool Registrar(Empresa empresa)
        {
            return empresaDAL.Registrar(empresa);
        }
    }
}
