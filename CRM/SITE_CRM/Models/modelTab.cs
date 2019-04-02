using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL;
using ET;
namespace SITE_CRM.Models
{
    public class modelTab
    {
        public List<Contacto> contacto { get; set; }
        public List<ServicioEmpresa> servicioEmp { get; set; }
        public ServicioEmpresa servicioEmpresaET { get; set; }
    }
}