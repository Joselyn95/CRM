using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL;
using ET;

namespace BL
{
    public class RecordatorioBL
    {
        private RecordatorioDAL recordatorioDAL = new RecordatorioDAL();

        public List<Recordatorio> Listar()
        {
            return recordatorioDAL.Listar();
        }

        public Recordatorio Obtener(int id)
        {
            return recordatorioDAL.Obtener(id);
        }

        public bool Actualizar(Recordatorio recor)
        {
            return recordatorioDAL.Actualizar(recor);
        }

        public bool Registrar(Recordatorio recor)
        {
            return recordatorioDAL.Registrar(recor);
        }
    }
}
