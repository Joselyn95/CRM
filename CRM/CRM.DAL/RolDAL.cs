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
    public class RolDAL
    {
        public List<Rol> Listar()
        {
            var roles = new List<Rol>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM rol", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var rol= new Rol
                            {
                                Id_Rol = Convert.ToInt32(dr["Id_Rol"]),
                                Nombre = dr["Nombre"].ToString()
                            };

                            // Agregamos el usuario a la lista genreica
                            roles.Add(rol);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return roles;
        }

    }
}
