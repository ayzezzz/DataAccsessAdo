using MySqlConnector;
using System;

namespace MySqlAdo
{
    class Program
    {
        static void Main(string[] args)
        {

            string constr = "Server=localhost;Database=sakila;Uid=root;Pwd=qweasd;";
            MySqlConnection conn = new(constr);
            MySqlCommand cmd = conn.CreateCommand();

            #region Table reading
            cmd.CommandText = "Select * from city";
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                Console.WriteLine(reader["city"]);
            #endregion

            #region Single Value Reading
            conn.Open();
            cmd.CommandText = "select count(*) Adet from City";
            var res = cmd.ExecuteScalar();
            Console.WriteLine("Kayit Sayisi:" + res);
            #endregion
            conn.Close();
        }
    }
}
