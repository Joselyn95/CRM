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
    public class RecordatorioDAL
    {
        public List<Recordatorio> Listar()
        {
            var recordatorios = new List<Recordatorio>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Recordatorio", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var recordatorio = new Recordatorio
                            {
                                Id_Recordatorio = Convert.ToInt32(dr["Id_Recordatorio"]),
                                Tipo = dr["Tipo"].ToString(),
                                Id_Empresa = Convert.ToInt32(dr["Empresa"]),
                                Fecha = dr["Fecha"].ToString(),
                                Hora = Convert.ToInt32(dr["Hora"]),
                                Minutos = Convert.ToInt32(dr["Minutos"]),
                                Abreviatura = dr["Abreviatura"].ToString(),
                                Detalle = dr["Detalle"].ToString(),
                            };

                            // Agregamos el usuario a la lista genreica
                            recordatorios.Add(recordatorio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return recordatorios;
        }

        public Recordatorio Obtener(int id)
        {
            var recordatorio = new Recordatorio();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From Recordatorio where Id_Recordatorio = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            recordatorio.Id_Recordatorio = Convert.ToInt32(dr["Id_Recordatorio"]);
                            recordatorio.Tipo = dr["Tipo"].ToString();
                            recordatorio.Fecha = dr["Fecha"].ToString();
                            recordatorio.Hora = Convert.ToInt32(dr["Hora"]);
                            recordatorio.Minutos = Convert.ToInt32(dr["Minutos"]);
                            recordatorio.Abreviatura= dr["Abreviatura"].ToString();
                            recordatorio.Detalle = dr["Detalle"].ToString();
                            recordatorio.Id_Empresa = Convert.ToInt32(dr["Empresa"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return recordatorio;
        }

        public bool Actualizar(Recordatorio recordatorio)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    string sql = "UPDATE Recordatorio SET Tipo= @p0, Fecha = @p1,  Hora= @p3, Minutos= @p4, Abreviatura = @p5, Detalle = @p6, Empresa = @p7 where Id_Recordatorio = @p8";
                    var query = new SqlCommand(sql, con);

                    query.Parameters.AddWithValue("@p0", recordatorio.Tipo);
                    query.Parameters.AddWithValue("@p1", recordatorio.Fecha);
                    query.Parameters.AddWithValue("@p3", recordatorio.Hora);
                    query.Parameters.AddWithValue("@p4", recordatorio.Minutos);
                    query.Parameters.AddWithValue("@p5", recordatorio.Abreviatura);
                    query.Parameters.AddWithValue("@p6", recordatorio.Detalle);
                    query.Parameters.AddWithValue("@p7", recordatorio.Id_Empresa);
                    query.Parameters.AddWithValue("@p8", recordatorio.Id_Recordatorio);
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

        public bool Registrar(Recordatorio recordatorio)
        {
            bool respuesta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    string sql = "INSERT INTO Recordatorio(Tipo, Fecha,Hora, Minutos, Abreviatura, Detalle,Empresa) values (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";
                    var query = new SqlCommand(sql, con);

                    query.Parameters.AddWithValue("@p0", recordatorio.Tipo);
                    query.Parameters.AddWithValue("@p1", recordatorio.Fecha);
                    query.Parameters.AddWithValue("@p2", recordatorio.Hora);
                    query.Parameters.AddWithValue("@p3", recordatorio.Minutos);
                    query.Parameters.AddWithValue("@p4", recordatorio.Abreviatura);
                    query.Parameters.AddWithValue("@p5", recordatorio.Detalle);
                    query.Parameters.AddWithValue("@p6", recordatorio.Id_Empresa);
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
