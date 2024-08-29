using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace sqlServerAdo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shipper> shippers = new List<Shipper>();

            //SqlConnection: verilen conectionstring üzerinden veri tabanına baglanır.
            string constr = "Server=(localdb)\\mssqllocaldb; Database = Northwind; Trusted_Connection = True; TrustServerCertificate=true";
            SqlConnection con = new SqlConnection(constr);

            //SqlCommand:  SqlConnection nesnesine ihtiyaç duyar.
            //Çalıştığı zaman gerekli sql scriptler yazılarak sonuç beklenir.

            try
            {
                con.Open();
                // SQl'den veri Okuma
                //SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Shippers";
                SqlDataReader rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    Shipper shipper = new Shipper();
                //    shipper.ShipperId = int.Parse(rdr[0].ToString());
                //    shipper.CompanyName = rdr[1].ToString();
                //    shipper.Phone = rdr[2].ToString();
                //    shippers.Add(shipper);
                //}

                //shippers.ForEach(shipper => Console.WriteLine(shipper.ShipperId + " " + shipper.CompanyName + " " + shipper.Phone));

                //Console.WriteLine("Durum:" + con.State);

               // DataSet,DataTable , SqlDataAdaptor Kullanimi
                cmd.CommandText = "Select * from Shippers";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.InsertCommand.CommandText = "Insert into ....";
                DataSet ds = new DataSet(); // Database'e karsilik Gelen nesnedir.
                DataTable table = new DataTable(); // Database de tablo'ya karsilik gelen nesne

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata:" + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open);
                con.Close();
            }
        }
    }
    public struct Shipper
    {
        public int ShipperId;
        public string CompanyName;
        public string Phone;
    }
}
