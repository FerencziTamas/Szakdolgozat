using Forest_Register.modell;
using Forest_Register.repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.repository
{
    class AdatbazisRepository
    {
        private readonly string connectionString;

        public AdatbazisRepository()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        public void adatbazisLetrehozas()
        {

            string query = "CREATE DATABASE IF NOT EXISTS erdo_adatbazis DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci";
            MySqlConnection connection = new MySqlConnection();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Az adatbázis létrehozása nem sikerült vagy már létezik");
            }
        }
    }
}
