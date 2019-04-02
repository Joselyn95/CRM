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
    public class EmpresaDAL
    {
        public List<Empresa> Listar()
        {
            var empresas = new List<Empresa>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRM"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Empresa", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var empresa = new Empresa
                            {
                                Id_Empresa = Convert.ToInt32(dr["Id_Empresa"]),
                                Nombre = dr["Nombre"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Cedula = dr["Cedula"].ToString(),
                                Pais = dr["Pais"].ToString(),
                                Id_Provincia = Convert.ToInt32(dr["Provincia"]),
                                Id_Canton = Convert.ToInt32(dr["Canton"]),
                                Id_Distrito = Convert.ToInt32(dr["Distrito"]),
                                Otras_Señas = dr["Otras_Señas"].ToString(),
                                Codigo_Postal = Convert.ToInt32(dr["Codigo_Postal"]),
                            };

                            // Agregamos el usuario a la lista genreica
                            empresas.Add(empresa);
                        }
                    }

                    //// Agregamos el ROL
                    foreach (var u in empresas)
                    {
                        query = new SqlCommand("SELECT * FROM Provincia WHERE Id_Provincia = @id", con);
                        query.Parameters.AddWithValue("@id", u.Id_Provincia);

                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                u.Provincia.Id_Provincia = Convert.ToInt32(dr["Id_Provincia"]);
                                u.Provincia.Nombre = dr["Nombre"].ToString();
                            }
                        }
                    }

                    foreach (var u in empresas)
                    {
                        query = new SqlCommand("SELECT * FROM Provincia WHERE Id_Canton = @id", con);
                        query.Parameters.AddWithValue("@id", u.Id_Canton);

                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                u.Canton.Id_Canton = Convert.ToInt32(dr["Id_Canton"]);
                                u.Canton.Nombre = dr["Nombre"].ToString();
                            }
                        }
                    }


                    foreach (var u in empresas)
                    {
                        query = new SqlCommand("SELECT * FROM Provincia WHERE Id_Distrito = @id", con);
                        query.Parameters.AddWithValue("@id", u.Id_Distrito);

                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                u.Distrito.Id_Distrito = Convert.ToInt32(dr["Id_Distrito"]);
                                u.Distrito.Nombre = dr["Nombre"].ToString();
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
              
            }

            return empresas;
        }

        public Empresa Obtener(int id)
        {
            var empresa = new Empresa();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRM"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From Empresa where Id_Empresa = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            empresa.Id_Empresa = Convert.ToInt32(dr["Id_Empresa"]);
                            empresa.Nombre = dr["Nombre"].ToString();
                            empresa.Correo = dr["Correo"].ToString();
                            empresa.Cedula = dr["Cedula"].ToString();
                            empresa.Pais = dr["Pais"].ToString();
                            empresa.Id_Provincia = Convert.ToInt32(dr["Provincia"]);
                            empresa.Id_Canton = Convert.ToInt32(dr["Canton"]);
                            empresa.Id_Distrito = Convert.ToInt32(dr["Distrito"]);
                            empresa.Otras_Señas = dr["Otras_Señas"].ToString();
                            empresa.Codigo_Postal = Convert.ToInt32(dr["Codigo_Postal"]);
                            ;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return empresa;
        }

        public bool Actualizar(Empresa empresa)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRM"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Empresa SET Nombre = @p0, Correo = @p1, Cedula = @p2, Pais = @p3,  Provincia = @p4 WHERE Id_Empresa = @p5, Canton = @p6 WHERE Id_Empresa = @p5, Distrito = @p7 WHERE Id_Empresa = @p5,  Otras_Señas = @p8,  Codigo_Postal = @p9", con);

                    query.Parameters.AddWithValue("@p0", empresa.Nombre);
                    query.Parameters.AddWithValue("@p1", empresa.Correo);
                    query.Parameters.AddWithValue("@p2", empresa.Cedula);
                    query.Parameters.AddWithValue("@p3", empresa.Pais);
                    query.Parameters.AddWithValue("@p4", empresa.Id_Provincia);
                    query.Parameters.AddWithValue("@p5", empresa.Id_Empresa);
                    query.Parameters.AddWithValue("@p6", empresa.Id_Canton);
                    query.Parameters.AddWithValue("@p7", empresa.Id_Canton);
                    query.Parameters.AddWithValue("@p8", empresa.Otras_Señas);
                    query.Parameters.AddWithValue("@p9", empresa.Codigo_Postal);

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

        public bool Registrar(Empresa empresa)
        {
            bool respuesta = false;
            //string c = empresa.Pais.ToLower() + empresa.Nombre.ToLower();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SITE_CRM.Properties.Settings.CRM"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO Empresa(Nombre,Correo,Cedula,Pais,Provincia,Canton,Distrito,Otras_Señas, Codigo_Postal) VALUES (@p0, @p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8)", con);

                    query.Parameters.AddWithValue("@p0", empresa.Nombre);
                    query.Parameters.AddWithValue("@p1", empresa.Correo);
                    query.Parameters.AddWithValue("@p2", empresa.Cedula);
                    query.Parameters.AddWithValue("@p3", empresa.Pais);
                    //query.Parameters.AddWithValue("@p4", c);
                    query.Parameters.AddWithValue("@p4", empresa.Id_Provincia);
                    query.Parameters.AddWithValue("@p5", empresa.Id_Canton);
                    query.Parameters.AddWithValue("@p6", empresa.Id_Distrito);
                    query.Parameters.AddWithValue("@p7", empresa.Otras_Señas);
                    query.Parameters.AddWithValue("@p8", empresa.Codigo_Postal);

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
