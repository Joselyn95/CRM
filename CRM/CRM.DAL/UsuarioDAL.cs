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
    public class UsuarioDAL
    {
        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM usuario", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var usuario = new Usuario
                            {
                                Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido1 = dr["Apellido1"].ToString(),
                                Apellido2 = dr["Apellido2"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Rol_id = Convert.ToInt32(dr["Rol"]),
                            };

                            // Agregamos el usuario a la lista genreica
                            usuarios.Add(usuario);
                        }
                    }

                    //// Agregamos el ROL
                    foreach (var u in usuarios)
                    {
                        query = new SqlCommand("SELECT * FROM rol WHERE Id_Rol = @id", con);
                        query.Parameters.AddWithValue("@id", u.Rol_id);

                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                u.Rol.Id_Rol = Convert.ToInt32(dr["Id_Rol"]);
                                u.Rol.Nombre = dr["Nombre"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return usuarios;
        }

        public Usuario Obtener (int id)
        {
            var usuario = new Usuario();

            try
            {
                using (var con= new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From Usuario where Id_Usuario = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using(var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            usuario.Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]);
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido1 = dr["Apellido1"].ToString();
                            usuario.Apellido2 = dr["Apellido2"].ToString();
                            usuario.Correo = dr["Correo"].ToString();
                            usuario.Contraseña = dr["Contraseña"].ToString();
                            usuario.Fecha_Creacion = Convert.ToDateTime(dr["Fecha_Creacion"]);
                            usuario.Rol_id = Convert.ToInt32(dr["Rol"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return usuario;
        }

        public bool Actualizar(Usuario usuario)
        {
            bool respuesta = false;
            
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Usuario SET Nombre = @p0, Apellido1 = @p1, Apellido2 = @p2, Correo = @p3,  Rol = @p4 WHERE Id_Usuario = @p5", con);

                    query.Parameters.AddWithValue("@p0", usuario.Nombre);
                    query.Parameters.AddWithValue("@p1", usuario.Apellido1);
                    query.Parameters.AddWithValue("@p2", usuario.Apellido2);
                    query.Parameters.AddWithValue("@p3", usuario.Correo);
                    query.Parameters.AddWithValue("@p4", usuario.Rol_id);
                    query.Parameters.AddWithValue("@p5", usuario.Id_Usuario);

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

        public bool Registrar(Usuario usuario)
        {
            bool respuesta = false;
            string c = usuario.Apellido1.ToLower() + usuario.Nombre.ToLower();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO Usuario(Nombre, Apellido1,Apellido2,Correo,Contraseña,Fecha_Creacion, Rol) VALUES (@p0, @p1, @p2,@p3,@p4,@p5,@p6)", con);

                    query.Parameters.AddWithValue("@p0", usuario.Nombre);
                    query.Parameters.AddWithValue("@p1", usuario.Apellido1);
                    query.Parameters.AddWithValue("@p2", usuario.Apellido2);
                    query.Parameters.AddWithValue("@p3", usuario.Correo);
                    query.Parameters.AddWithValue("@p4", c);
                    query.Parameters.AddWithValue("@p5", DateTime.Today);
                    query.Parameters.AddWithValue("@p6", usuario.Rol_id);

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

        public Usuario Login(string correo, string contraseña)
        {
            var usuario = new Usuario();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From Usuario where Correo = @correo and Contraseña = @contraseña", con);
                    query.Parameters.AddWithValue("@Correo", correo);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            usuario.Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]);
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido1 = dr["Apellido1"].ToString();
                            usuario.Apellido2 = dr["Apellido2"].ToString();
                            usuario.Correo = dr["Correo"].ToString();
                            usuario.Contraseña = dr["Contraseña"].ToString();
                            usuario.Fecha_Creacion = Convert.ToDateTime(dr["Fecha_Creacion"]);
                            usuario.Rol_id = Convert.ToInt32(dr["Rol"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return usuario;
        }

    }
}
