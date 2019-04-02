using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using CRM.DAL;

namespace BL
{
    public class CantonBL
    {
        private CantonDAL cantonDAL = new CantonDAL();
        public List<Canton> Listar()
        {
            return cantonDAL.Listar();
        }

    }
}
