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
    partial class SzamlakRepositoryAdatbazisTabla
    {
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public SzamlakRepositoryAdatbazisTabla()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        public void SzamlakTablaLetrehozas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query1 = "CREATE TABLE IF NOT EXISTS `szamlak` (" +
                    "`szamlaszam` varchar(17) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`vevoId` int(11) NOT NULL, " +
                    "`teljesites_napja` date NOT NULL, " +
                    "`szamla_keletkezes` date NOT NULL, " +
                    "`kifizetes_napja` date NOT NULL, " +
                    "`lerakodasi_hely` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`felrakasi_hely` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`muveleti_lap_sorszam` varchar(15) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`szallitojegy_sorszam` varchar(15) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "PRIMARY KEY(`szamlaszam`), " +
                    "KEY `vevoId` (`vevoId`))" +
                    " ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";
                string queryKeys1 = "ALTER TABLE `szamlak` ADD CONSTRAINT `szamlak_ibfk_1` FOREIGN KEY(`vevoId`) REFERENCES `vevok` (`vevoId`); ";
                string query2 = "CREATE TABLE IF NOT EXISTS `szamlatetelek` (" +
                    "`fafajId` int(11) NOT NULL, " +
                    "`szamlaszam` varchar(17) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`mennyiseg` int(11) NOT NULL, " +
                    "`felhasznalas_modja` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`brutto_ar` int(11) NOT NULL, " +
                    "`netto_ar` int(11) NOT NULL, " +
                    "KEY `fafajId` (`fafajId`), " +
                    "KEY `szamlaszam` (`szamlaszam`))" +
                    " ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci; ";
                string queryKeys2 = "ALTER TABLE `szamlatetelek`" +
                    " ADD CONSTRAINT `szamlatetelek_ibfk_1` FOREIGN KEY(`fafajId`) REFERENCES `fafajok` (`fafajId`)," +
                    " ADD CONSTRAINT `szamlatetelek_ibfk_2` FOREIGN KEY(`szamlaszam`) REFERENCES `szamlak` (`szamlaszam`); ";
                MySqlCommand cmdUse = new MySqlCommand(use, connection);
                MySqlCommand cmdQuery1 = new MySqlCommand(query1, connection);
                MySqlCommand cmdQuery2 = new MySqlCommand(query2, connection);
                MySqlCommand cmdQueryKeys1 = new MySqlCommand(queryKeys1, connection);
                MySqlCommand cmdQueryKeys2 = new MySqlCommand(queryKeys2, connection);
                cmdUse.ExecuteNonQuery();
                cmdQuery1.ExecuteNonQuery();
                cmdQuery2.ExecuteNonQuery();
                cmdQueryKeys1.ExecuteNonQuery();
                cmdQueryKeys2.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen táblák létrehozás.");
            }            
        }

        public void SzamlaTesztAdatokFeltoltese()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO `erdogazdalkodok` (`egKod`, `nev`, `cim`) VALUES ('DASISTKOD', 'Erdész Péter', 'Szeged Nem utca -2.'), " +
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

        public void SzamlaTablakTorles()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query1 = "DROP TABLE szamlak";
                string query2 = "DROP TABLE szamlatetelek";
                MySqlCommand cmdUse = new MySqlCommand(use, connection);
                MySqlCommand cmdQuery1 = new MySqlCommand(query1, connection);
                MySqlCommand cmdQuery2 = new MySqlCommand(query2, connection);
                cmdUse.ExecuteNonQuery();
                cmdQuery1.ExecuteNonQuery();
                cmdQuery2.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen táblák törlése.");
            }
        }

        public void SzamlaAdatTorlesTablabol()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query1 = Szamla.TorolSzamlak();
                string query2 = Szamla.TorolSzamlaTetelek();
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen adat törlése.");
            }
        }
    }
}