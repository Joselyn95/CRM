using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using ET;

namespace CRM.DAL
{
   public class EstadodeCuentaDAL
    {
        public List<EstadodeCuenta> Listar()
        {
            var estadosdeCuentas = new List<EstadodeCuenta>();

            try
            {
                //"SITE_CRM.Properties.Settings.CRMdb"
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRMdb"].ToString()))

                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM EstadodeCuenta", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            
                            var estadodeCuenta = new EstadodeCuenta
                            {
                                Id_Estado = Convert.ToInt32(dr["Id_Estado"]),
                                Id_Credito_Disponible = Convert.ToInt32(dr["Id_Credito_Disponible"]),
                                Empresa = Convert.ToInt32(dr["Empresa"]),

                            };

                            
                            estadosdeCuentas.Add(estadodeCuenta);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return estadosdeCuentas;
        }
        public EstadodeCuenta Obtener(int id)
        {
            var estado = new EstadodeCuenta();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRMdb"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From Contacto where Id_Contacto = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            estado.Id_Estado = Convert.ToInt32(dr["Id_Estado"]);
                            estado.Id_Credito_Disponible = Convert.ToInt32(dr["Id_Credito_Disponible"]);
                            estado.Empresa = Convert.ToInt32(dr["Empresa"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return estado;
        }
        public bool Actualizar(EstadodeCuenta estado)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRMdb"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Contacto SET Id_Estado = @p0, Id_Credito_Disponible = @p1, Empresa = @p2 WHERE Id_Estado = @p0", con);

                    query.Parameters.AddWithValue("@p0", estado.Id_Estado);
                    query.Parameters.AddWithValue("@p1", estado.Id_Credito_Disponible);
                    query.Parameters.AddWithValue("@p2", estado.Empresa);
                 

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }
        public bool Registrar(EstadodeCuenta estado)
        {
            bool respuesta = false;
            //string c = contacto.Apellido1.ToLower() + contacto.Nombre.ToLower();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRMdb"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO EstadodeCuenta(Id_Estado, Id_Credito_Disponible,Empresa) VALUES (@p0, @p1, @p2)", con);

                    query.Parameters.AddWithValue("@p0", estado.Id_Estado);
                    query.Parameters.AddWithValue("@p1", estado.Id_Credito_Disponible);
                    query.Parameters.AddWithValue("@p2", estado.Empresa);
                    
                    //query.Parameters.AddWithValue("@p4", c);
                    
                    //query.Parameters.AddWithValue("@p6", usuario.Rol_id);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }
    }
}
