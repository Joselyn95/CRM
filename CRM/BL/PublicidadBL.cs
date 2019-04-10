using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL;
using ET;

namespace BL
{
    public class PublicidadBL
    {
        private PublicidadDAL publicidadDAL = new PublicidadDAL();

        public List<Publicidad> Listar()
        {
            return publicidadDAL.Listar();
        }

        public Publicidad Obtener(int id)
        {
            return publicidadDAL.Obtener(id);
        }

        public bool Actualizar(Publicidad publi)
        {
            return publicidadDAL.Actualizar(publi);
        }

        public bool Registrar(Publicidad publi)
        {
            return publicidadDAL.Registrar(publi);
        }
    }
}
