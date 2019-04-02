using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using CRM.DAL;

namespace BL
{
    public class ProvinciaBL
    {
        private ProvinciaDAL provinciaDAL = new ProvinciaDAL();
        public List<Provincia> Listar()
        {
            return provinciaDAL.Listar();
        }

    }
}
