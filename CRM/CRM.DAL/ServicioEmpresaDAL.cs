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
    public class ServicioEmpresaDAL
    {
        public List<ServicioEmpresa> Listar()
        {
            var servicios = new List<ServicioEmpresa>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))

                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM ServicioEmpresa", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var servicioemp = new ServicioEmpresa
                            {

                                Id_ServicioEmpresa = Convert.ToInt32(dr["Id_Servicio_Empresa"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Tipo_Servicio = dr["Tipo_Servicio"].ToString(),
                                Cantidad_Inventario = Convert.ToInt32(dr["Cantidad_Inventario"]),
                                Precio = Convert.ToDouble(dr["Precio"]),
                                Id_Empresa = Convert.ToInt32(dr["Empresa"]),

                            };

                            // Agregamos el usuario a la lista generica
                            servicios.Add(servicioemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return servicios;
        }

        public ServicioEmpresa Obtener(int id)
        {
            var servicio = new ServicioEmpresa();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From ServicioEmpresa where Id_Servicio_Empresa= @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            servicio.Id_ServicioEmpresa = Convert.ToInt32(dr["Id_Servicio_Empresa"]);
                            servicio.Nombre = dr["Nombre"].ToString();
                            servicio.Descripcion = dr["Descripcion"].ToString();
                            servicio.Tipo_Servicio = dr["Tipo_Servicio"].ToString();
                            servicio.Cantidad_Inventario = Convert.ToInt32(dr["Cantidad_Inventario"]);
                            servicio.Precio = Convert.ToDouble(dr["Precio"]);
                            servicio.Id_Empresa = Convert.ToInt32(dr["Empresa"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return servicio;
        }

        public bool Actualizar(ServicioEmpresa servicio)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    string sql = "UPDATE ServicioEmpresa SET Nombre = @p0,Descripcion = @p1, Cantidad_Inventario= @p2, Tipo_Servicio = @p3, Precio = @p4 where Id_Servicio_Empresa = @p5 ";
                    var query = new SqlCommand(sql, con);

                    query.Parameters.AddWithValue("@p0", servicio.Nombre);
                    query.Parameters.AddWithValue("@p1", servicio.Descripcion);
                    query.Parameters.AddWithValue("@p2", servicio.Cantidad_Inventario);
                    query.Parameters.AddWithValue("@p3", servicio.Tipo_Servicio);
                    query.Parameters.AddWithValue("@p4", servicio.Precio);
                    query.Parameters.AddWithValue("@p5", servicio.Id_ServicioEmpresa);

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

        public bool Registrar(ServicioEmpresa servicio)
        {
            bool respuesta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    string sql = "INSERT INTO ServicioEmpresa (Nombre, Descripcion, Tipo_Servicio, Cantidad_Inventario, Precio, Empresa) VALUES (@p0, @p1, @p2,@p3,@p4, @p5)";
                    var query = new SqlCommand(sql, con);

                    query.Parameters.AddWithValue("@p0", servicio.Nombre);
                    query.Parameters.AddWithValue("@p1", servicio.Descripcion);
                    query.Parameters.AddWithValue("@p2", servicio.Tipo_Servicio);
                    query.Parameters.AddWithValue("@p3", servicio.Cantidad_Inventario);
                    query.Parameters.AddWithValue("@p4", servicio.Precio);
                    query.Parameters.AddWithValue("@p5", servicio.Id_Empresa);

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
