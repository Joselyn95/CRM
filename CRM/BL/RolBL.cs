using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL;
using ET;

namespace BL
{
    public class RolBL
    {
        private RolDAL rolDAL = new RolDAL();
        public List<Rol> Listar()
        {
            return rolDAL.Listar();
        }
    }
}
