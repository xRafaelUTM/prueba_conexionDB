// ConexionBD.cs
using System;
using System.Data.SqlClient;

namespace prueba_conexionDB
{
    public class ConexionBD
    {
        string connectionString = "Server=DESKTOP-KEI8B51;Database=prueba;Integrated Security=True;";

        public SqlConnection connection;
        
        public ConexionBD()
        {
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection? AbrirConexion()
        {
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                return null;
            }
        }

        public void CerrarConexion()
        {
            connection.Close();
        }
    }
}
