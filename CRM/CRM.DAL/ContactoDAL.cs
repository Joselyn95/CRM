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
   public class ContactoDAL
    {

        public List<Contacto> Listar()
        {
            var contactos = new List<Contacto>();

            try
            {
                //"SITE_CRM.Properties.Settings.CRMdb"
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                 
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Contacto", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Contacto
                            var contacto = new Contacto
                            {
                                Id_Contacto = Convert.ToInt32(dr["Id_Contacto"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido1 = dr["Apellido1"].ToString(),
                                Apellido2 = dr["Apellido2"].ToString(),
                                Puesto = dr["Puesto"].ToString(),
                                Empresa = Convert.ToInt32(dr["Empresa"]),

                        };

                            // Agregamos el usuario a la lista genreica
                            contactos.Add(contacto);
                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return contactos;
        }
        public Contacto Obtener(int id)
        {
            var contacto = new Contacto();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * From Contacto where Id_Contacto = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            contacto.Id_Contacto = Convert.ToInt32(dr["Id_Contacto"]);
                            contacto.Nombre = dr["Nombre"].ToString();
                            contacto.Apellido1 = dr["Apellido1"].ToString();
                            contacto.Apellido2 = dr["Apellido2"].ToString();
                            contacto.Puesto = dr["Puesto"].ToString();
                            contacto.Empresa = Convert.ToInt32(dr["Empresa"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return contacto;
        }
        public bool Actualizar(Contacto contacto)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Contacto SET Nombre = @p0, Apellido1 = @p1, Apellido2 = @p2, Puesto = @p3,  Empresa = @p4 WHERE Id_Contacto = @p5", con);

                    query.Parameters.AddWithValue("@p0", contacto.Nombre);
                    query.Parameters.AddWithValue("@p1", contacto.Apellido1);
                    query.Parameters.AddWithValue("@p2", contacto.Apellido2);
                    query.Parameters.AddWithValue("@p3", contacto.Puesto);
                    query.Parameters.AddWithValue("@p4", contacto.Empresa);
                    query.Parameters.AddWithValue("@p5", contacto.Id_Contacto);

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
        public bool Registrar(Contacto contacto)
        {
            bool respuesta = false;
            //string c = contacto.Apellido1.ToLower() + contacto.Nombre.ToLower();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO Contacto(Nombre, Apellido1,Apellido2,Puesto,Empresa) VALUES (@p0, @p1, @p2,@p3,@p4)", con);

                    query.Parameters.AddWithValue("@p0", contacto.Nombre);
                    query.Parameters.AddWithValue("@p1", contacto.Apellido1);
                    query.Parameters.AddWithValue("@p2", contacto.Apellido2);
                    query.Parameters.AddWithValue("@p3", contacto.Puesto);
                    //query.Parameters.AddWithValue("@p4", c);
                    query.Parameters.AddWithValue("@p4", contacto.Empresa);
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
