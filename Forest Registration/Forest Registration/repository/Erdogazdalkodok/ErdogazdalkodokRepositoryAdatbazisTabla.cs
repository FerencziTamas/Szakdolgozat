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
    partial class ErdogazdalkodokRepositoryAdatbazisTabla
    {
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public ErdogazdalkodokRepositoryAdatbazisTabla()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        public void ErGazokTablaLetrehozas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "CREATE TABLE IF NOT EXISTS `erdogazdalkodok` (" +
                    "`egKod` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`erdogazNev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`erdogazCim` varchar(50) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "PRIMARY KEY(`egKod`))" +
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

        public void ErGazTesztAdatokFeltoltes()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT IGNORE INTO `erdogazdalkodok` (`egKod`, `erdogazNev`, `erdogazCim`) VALUES " +
                    "('Kod1', 'Erdész Miki', 'Szeged Nem utca -3.'), " +
                    "('Kod2', 'Erdész Elek', 'Szeged Nem utca -4.'), " +
                    "('Kod3', 'Erdész Tibi', 'Szeged Nem utca -5.'), " +
                    "('DASISTKOD', 'Erdész Péter', 'Szeged Nem utca -2.'), " +
                    "('Én24141442', 'Ferenczi Tamás', 'Ásotthalom Királyhalmi utca. 56.'), " +
                    "('FAVAGO134252', 'Favágó János', 'Szeged Favágó utca 50.'), " +
                    "('Hello There!', 'General Kenobi!', 'Halálcsillag utca 66.'); ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen teszt adat feltöltés.");
            }
        }

        public void ErGazTablaTorles()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "DROP TABLE erdogazdalkodok";
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
                throw new RepositoryException("Sikertelen tábla törlése.");
            }
        }

        public void ErGazAdatTorlesTablabol()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Erdogazdalkodo.TorolErdogazdalkodok();
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
