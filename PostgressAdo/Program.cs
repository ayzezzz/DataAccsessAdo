using Npgsql;
using System;

namespace PostgressAdo
{
    class Program
    {
        static void Main(string[] args)
        {
           string constr = "Server=127.0.0.1;Port=5432;Database=Northwind;User Id=postgres;Password=qweasd;";
            // NpgsqlConnection nesnesi oluşturuluyor ve bağlantı dizesi atanıyor.
            NpgsqlConnection conn = new(constr);
            NpgsqlCommand command = conn.CreateCommand();
            command.CommandText = "Select * from Shippers";
            conn.Open();
            // SQL sorgusu çalıştırılıyor ve sonuçlar NpgsqlDataReader ile okunuyor.
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine(reader[0] + " " + reader[1]);
            
            conn.Close();
           // Console.WriteLine("Hello World!");
        }
    }
}
