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
    public class CantonDAL
    {
        public List<Canton> Listar()
        {
            var cantones = new List<Canton>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRM"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM canton", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var canton = new Canton
                            {
                                Id_Canton = Convert.ToInt32(dr["Id_Canton"]),
                                Nombre = dr["Nombre"].ToString()
                            };

                            // Agregamos el usuario a la lista genreica
                            cantones.Add(canton);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return cantones;
        }
    }
}
