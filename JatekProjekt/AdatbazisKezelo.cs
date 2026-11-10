using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private static List<Karakter> karakterek = new List<Karakter>();

        private static void AdatbazisKezeloFunction()
        {
            string connectionString = "server=127.0.0.1;port=4201;database=JatekDb;uid=root;pwd=root";// Irjuk meg a connectionstringet a megfelelő adatbázisra hivatkozva
            using(MySqlConnection connection = new(connectionString))
            {
                string query = "SELECT * FROM Karakterek";
                using(MySqlCommand command = new(query, connection))
                {
                    connection.Open();
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Karakter karakter = new(
                                Convert.ToInt32(reader[0]),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                Convert.ToInt32(reader[3]),
                                Convert.ToInt32(reader[4]),
                                reader[5].ToString()
                            );
                            karakterek.Add(karakter);
                        }
                    }
                }
            }
        }
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
        public List<Karakter> AdatokBetoltese()
        {
            AdatbazisKezeloFunction();
            return karakterek;
        }
    }
}