// Program.cs
using System;
using System.Data.SqlClient;

namespace prueba_conexionDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var conexionBD = new ConexionBD();

            // Hacer insercion de datos INSERT
            try
            {
                string Query = "INSERT INTO dbo.productos (nombre) VALUES ('Television')";
                var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());
                cmd.ExecuteNonQuery();
                Console.WriteLine("Se ingresó un nuevo dato.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            

            // Actualizar un dato UPDATE
            try
            {
                string Query2 = "UPDATE dbo.productos SET nombre = 'PC' WHERE id = 6"; 
                var cmd2 = new SqlCommand(Query2, conexionBD.AbrirConexion());
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Se actualizó un dato.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            

           
            // Inserción de datos con retorno de valor
            try
            {
                string Query3 = "INSERT INTO dbo.productos (nombre) OUTPUT INSERTED.id VALUES ('Casco') ";
                var cmd3 = new SqlCommand(Query3, conexionBD.AbrirConexion());
                string? id = cmd3.ExecuteScalar().ToString();
                Console.WriteLine($"El id del usuario insertado es {id}"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            
            
            
            // Borrar datos DELETE
            try
            {
                string Query4 = "DELETE FROM dbo.productos WHERE nombre = 'Casco'";
                var cmd4 = new SqlCommand(Query4, conexionBD.AbrirConexion());
                cmd4.ExecuteNonQuery();
                Console.WriteLine($"Se eliminó el usuario");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            

            // Selección de datos SELECT
            try
            {
                string Query5 = "SELECT * FROM productos";
                var cmd5 = new SqlCommand(Query5, conexionBD.AbrirConexion());

                using SqlDataReader lector = cmd5.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Console.WriteLine($"El nombre del producto con id: {lector["id"].ToString} es: {lector["nombre"].ToString}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

        }
    }
}
