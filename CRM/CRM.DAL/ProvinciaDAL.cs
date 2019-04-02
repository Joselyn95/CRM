using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;

namespace CRM.DAL
{
    public class ProvinciaDAL
    {
        public List<Provincia> Listar()
        {
            var provincias = new List<Provincia>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRM"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM provincia", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var provincia = new Provincia
                            {
                                Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]),
                                Nombre = dr["Nombre"].ToString()
                            };

                            // Agregamos el usuario a la lista genreica
                            provincias.Add(provincia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return provincias;
        }
    }
}
