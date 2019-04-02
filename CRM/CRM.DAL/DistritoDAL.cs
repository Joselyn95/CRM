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
    public class DistritoDAL
    {
        public List<Distrito> Listar()
        {
            var distritos = new List<Distrito>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRM"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM distrito", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var distrito = new Distrito
                            {
                                Id_Distrito = Convert.ToInt32(dr["Id_Distrito"]),
                                Nombre = dr["Nombre"].ToString()
                            };

                            // Agregamos el usuario a la lista genreica
                            distritos.Add(distrito);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return distritos
                ;
        }
    }
}
