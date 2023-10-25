using facturacion;
using System;
using System.Data.SqlClient;

public class Program
{
    public static void Main()
    {
        // Crea una cadena de conexión.
        string connectionString = "Data Source=localhost;Initial Catalog=sistema de facturacion;Integrated Security=True";

        // Crea una nueva conexión.
        SqlConnection connection = new SqlConnection(connectionString);

        // Intenta conectarse a la base de datos.
        try
        {
            connection.Open();
            Console.WriteLine("Conectado a la base de datos.");
            Compras compras =new Compras("2023-09-12","sergio","cepillo","5");
            Console.WriteLine(compras.ToString());

            // Establece los parámetros del comando.
            //Pass values to Parameters
            
            SqlCommand sqlCommand1 = new SqlCommand("INSERT INTO Compras (fecha,proveedor,producto,total)  VALUES ( @fecha,@proveedor,@producto,@total)", connection);
            //sqlCommand1.Parameters.AddWithValue("@id", 4);
            sqlCommand1.Parameters.AddWithValue("@fecha", compras.Fecha);
            sqlCommand1.Parameters.AddWithValue("@proveedor",compras.Proveedor);
            sqlCommand1.Parameters.AddWithValue("@producto", compras.Productos);
            sqlCommand1.Parameters.AddWithValue("@total", compras.Total);
            // Crea una nueva instancia de SqlCommandBuilder.


            // Establece los parámetros del comando.

            sqlCommand1.ExecuteNonQuery();   
                     // Ejecuta el comando.\r\n        " +
          
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Cierra la conexión.
        connection.Close();
    }
}
