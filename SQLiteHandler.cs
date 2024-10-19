using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Mono.Data.Sqlite;
using System.Text;

namespace Open_Food_Facts
{
    public static class SqLiteHandler
    {
        public static void FetchData()
        {
            List<Products> products = new List<Products>();
            try
            {
                string conn = "URI=file:/home/user/apps/openfoodfacts.db";
                


                IDbConnection dbconn = new SqliteConnection(conn);
                dbconn.Open();
                IDbCommand dbcmd = dbconn.CreateCommand();

                string query = "SELECT * FROM products";
                dbcmd.CommandText = query;
                IDataReader reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Products() { Code = reader.GetString(1), ProductName = reader.GetString(2), NovaGroup = reader.GetInt16(3), NutriscoreGrade = reader.GetString(4), ImageSmallUrl = reader.GetString(5), Quantity = reader.GetString(6) });
                }

                Variables.localDbProductsList = products;
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
