using System.Data.Common;
using System.Data.SqlClient;

namespace sql_connect;

class Program
{
    static void Main(string[] args)
    {
        // var sqlStringConnection = "Data Source = localhost, 1433; Initial Catalog = xtlab; User ID = sa; Password=Password123";
        var sqlStringBuilder = new SqlConnectionStringBuilder();
        sqlStringBuilder["Server"] = "localhost, 1433";
        sqlStringBuilder["Database"] = "xtlab";
        sqlStringBuilder["UID"] = "sa";
        sqlStringBuilder["PWD"] = "Password123";

        var sqlStringConnection = sqlStringBuilder.ToString();

        using var connection = new SqlConnection(sqlStringConnection);
        Console.WriteLine(connection.State);
        connection.Open();
        Console.WriteLine(connection.State);

        using DbCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT TOP (5) * FROM Sanpham";

        var dataReader = command.ExecuteReader();

        while(dataReader.Read())
        {
            Console.WriteLine($"{dataReader["TenSanPham"], 10}");
        }

        connection.Close();
    }
}
