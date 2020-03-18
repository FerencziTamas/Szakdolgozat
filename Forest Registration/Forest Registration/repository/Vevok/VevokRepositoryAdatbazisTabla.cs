using Forest_Register.modell;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    partial class VevokRepositoryAdatbazisTabla
    {
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public VevokRepositoryAdatbazisTabla()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        public void VevokTablaLetrehozas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "CREATE TABLE IF NOT EXISTS `vevok` (" +
                    "`vevoId` int(11) NOT NULL AUTO_INCREMENT, " +
                    "`nev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`cim` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`technikai azonosító` varchar(20) COLLATE utf8_hungarian_ci NOT NULL," +
                    " `adoszam` int(11) NOT NULL," +
                    " PRIMARY KEY(`vevoId`))" +
                    " ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci; ";
                MySqlCommand cmdUse = new MySqlCommand(use, connection);
                MySqlCommand cmdQuery = new MySqlCommand(query, connection);
                cmdUse.ExecuteNonQuery();
                cmdQuery.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen tábla létrehozás.");
            }
        }

        public void VevokTablaTorles()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "DROP TABLE vevok";
                MySqlCommand cmdUse = new MySqlCommand(use, connection);
                MySqlCommand cmdQuery = new MySqlCommand(query, connection);
                cmdUse.ExecuteNonQuery();
                cmdQuery.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen táblák törlése.");
            }
        }

        public void VevokAdatTorlesTablabol()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Vevo.TorolVevok();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen adat törlés.");
            }
        }
    }
}
