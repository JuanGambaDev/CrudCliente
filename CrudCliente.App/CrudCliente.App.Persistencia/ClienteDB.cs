using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CrudCliente.App.Entidades;

namespace CrudCliente.App.Presentacion
{
    public class ClienteDB
    {
        private string ConnectionString = "Data Source=JUANSEBASTI2B36\\SQLEXPRESS;Initial Catalog=ClienteData;Integrated Security=True";

        public bool Ok()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                Connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Cliente> Get() 
        {
            List<Cliente> Clientes = new List<Cliente>();

            String query = "select id, Nombres, Apellidos, Direccion from ClienteTabla";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand(query, Connection);

                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        Cliente oCliente = new Cliente();
                        oCliente.Id = Reader.GetInt32(0);
                        oCliente.Nombres = Reader.GetString(1);
                        oCliente.Apellidos = Reader.GetString(2);
                        oCliente.Direccion = Reader.GetString(3);
                        Clientes.Add(oCliente);
                    }
                    Reader.Close();
                    Connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en el query. " + ex.Message);
                }
                return Clientes;
            }

        }

        public Cliente Get(int Id)
        {
            String query = "select * from ClienteTabla where Id=@id";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@id",Id);

                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    Reader.Read();

                    Cliente oCliente = new Cliente();
                    oCliente.Id = Reader.GetInt32(0);
                    oCliente.Nombres = Reader.GetString(1);
                    oCliente.Apellidos = Reader.GetString(2);
                    oCliente.Direccion = Reader.GetString(3);
                    
                    Reader.Close();
                    Connection.Close();
                    return oCliente;

                }
                catch (Exception ex)		

                {
                    throw new Exception("Hay un error en el query. " + ex.Message);
                }
            }
        }

        public void Add(string Nombres,String Apellidos,String Direccion) 
        {
            string query = "Insert into ClienteTabla(Nombres, Apellidos, Direccion) values(@nombres,@apellidos,@direccion)";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@nombres", Nombres);
                Command.Parameters.AddWithValue("@apellidos", Apellidos);
                Command.Parameters.AddWithValue("@direccion", Direccion);

                try
                {
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en el query. " + ex.Message);
                }
            }
        }

        public void Update(string Nombres, String Apellidos, String Direccion, int Id)
        {
            string query = "update ClienteTabla set Nombres=@nombres, Apellidos=@apellidos, Direccion=@direccion where Id=@id";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@nombres", Nombres);
                Command.Parameters.AddWithValue("@apellidos", Apellidos);
                Command.Parameters.AddWithValue("@direccion", Direccion);
                Command.Parameters.AddWithValue("@id", Id);


                try
                {
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en el query. " + ex.Message);
                }
            }
        }

        public void Delete(int Id)
        {
            string query = "delete from ClienteTabla where Id=@id";

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@id", Id);

                try
                {
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    Connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en el query. " + ex.Message);
                }
            }
        }
    }
}
