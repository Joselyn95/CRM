using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using CRM.DAL;
namespace BL
{
   public class ContactoBL
    {
        private ContactoDAL contactoDAL = new ContactoDAL();

        public List<Contacto> Listar()
        {
            return contactoDAL.Listar();
        }

        public Contacto Obtener(int id)
        {
            return contactoDAL.Obtener(id);
        }

        public bool Actualizar(Contacto contacto)
        {
            return contactoDAL.Actualizar(contacto);
        }

        public bool Registrar(Contacto contacto)
        {
            return contactoDAL.Registrar(contacto);
        }
    }
}
