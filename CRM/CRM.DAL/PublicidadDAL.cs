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
    public class PublicidadDAL
    {
        public List<Publicidad> Listar()
        {
            var publicidades = new List<Publicidad>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Publicidad", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var publicidad = new Publicidad
                            {
                                Id_Publicidad = Convert.ToInt32(dr["Id_Publicidad"]),
                                Medio = dr["Medio"].ToString(),
                                Id_Empresa = Convert.ToInt32(dr["Empresa"]),
                                FechaInicio = dr["Fecha_Inicio"].ToString(),
                                FechaCaducidad = dr["Fecha_Caducidad"].ToString(),
                                Costo = Convert.ToInt32(dr["Costo"]),
                            };

                            // Agregamos el usuario a la lista genreica
                            publicidades.Add(publicidad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return publicidades;
        }

        public Publicidad Obtener(int id)
        {
            var publicidad = new Publicidad();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From Publicidad where Id_Publicidad = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            publicidad.Id_Publicidad = Convert.ToInt32(dr["Id_Publicidad"]);
                            publicidad.Medio = dr["Medio"].ToString();
                            publicidad.Id_Empresa = Convert.ToInt32(dr["Empresa"]);
                            publicidad.FechaInicio = dr["Fecha_Inicio"].ToString();
                            publicidad.FechaCaducidad = dr["Fecha_Caducidad"].ToString();
                            publicidad.Costo = Convert.ToInt32(dr["Costo"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return publicidad ;
        }

        public bool Actualizar(Publicidad publicidad)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    string sql = "UPDATE Publicidad SET Medio= @p0, Empresa = @p1,  Fecha_Inicio= @p3, Fecha_Caducidad= @p4, Costo = @p5 where Id_Publicidad = @p6";
                    var query = new SqlCommand(sql, con);

                    query.Parameters.AddWithValue("@p0", publicidad.Medio);
                    query.Parameters.AddWithValue("@p1", publicidad.Id_Empresa);
                    query.Parameters.AddWithValue("@p3", publicidad.FechaInicio);
                    query.Parameters.AddWithValue("@p4", publicidad.FechaCaducidad);
                    query.Parameters.AddWithValue("@p5", publicidad.Costo);
                    query.Parameters.AddWithValue("@p6", publicidad.Id_Publicidad);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ;
            }

            return respuesta;
        }

        public bool Registrar(Publicidad publicidad)
        {
            bool respuesta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    string sql = "INSERT INTO Publicidad(Medio, Empresa, Fecha_Inicio, Fecha_Caducidad, Costo) values (@p0,@p1,@p2,@p3,@p4)";  
                    var query = new SqlCommand(sql, con);

                    query.Parameters.AddWithValue("@p0", publicidad.Medio);
                    query.Parameters.AddWithValue("@p1", publicidad.Id_Empresa);
                    query.Parameters.AddWithValue("@p2", publicidad.FechaInicio);
                    query.Parameters.AddWithValue("@p3", publicidad.FechaCaducidad);
                    query.Parameters.AddWithValue("@p4", publicidad.Costo);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ;
            }

            return respuesta;
        }

    }
}
