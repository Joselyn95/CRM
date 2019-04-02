using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL;
using ET;
namespace BL
{
    public class DistritoBL
    {

        private DistritoDAL distritoDAL = new DistritoDAL();
        public List<Distrito> Listar()
        {
            return distritoDAL.Listar();
        }
    }
}
