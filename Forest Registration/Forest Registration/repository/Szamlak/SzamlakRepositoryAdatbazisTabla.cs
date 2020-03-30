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
                throw new RepositoryException("Sikertelen táblák létrehozás.");
            }            
        }

        public void SzamlakIdegenKulcsok()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryKeys1 = "ALTER TABLE `szamlak` ADD CONSTRAINT `szamlak_ibfk_1` FOREIGN KEY IF NOT EXISTS (`vevoId`) REFERENCES `vevok` (`vevoId`) ON DELETE CASCADE ON UPDATE CASCADE; ";
                string queryKeys2 = "ALTER TABLE `szamlatetelek`" +
                    " ADD CONSTRAINT `szamlatetelek_ibfk_1` FOREIGN KEY IF NOT EXISTS (`fafajId`) REFERENCES `fafajok` (`fafajId`) ON DELETE CASCADE ON UPDATE CASCADE," +
                    " ADD CONSTRAINT `szamlatetelek_ibfk_2` FOREIGN KEY IF NOT EXISTS (`szamlaszam`) REFERENCES `szamlak` (`szamlaszam`) ON DELETE CASCADE ON UPDATE CASCADE; ";
                MySqlCommand cmdQueryKeys1 = new MySqlCommand(queryKeys1, connection);
                MySqlCommand cmdQueryKeys2 = new MySqlCommand(queryKeys2, connection);
                cmdQueryKeys1.ExecuteNonQuery();
                cmdQueryKeys2.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen idegen kulcsok létrehozása.");
            }
        }

        public void SzamlaTesztAdatokFeltoltese()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string querySzamlak = "INSERT IGNORE INTO `szamlak` (`szamlaszam`, `vevoId`, `teljesites_napja`, `szamla_keletkezes`, `kifizetes_napja`, `lerakodasi_hely`, `felrakasi_hely`, `muveleti_lap_sorszam`, `szallitojegy_sorszam`) VALUES " +
                    "('02021144-02021313', 1, '2020-03-18', '2020-03-18', '2020-03-20', 'Zala', 'Ásotthalom', 'MUV4255', 'SZAL14414'), " +
                    "('02021144-02021314', 5, '2020-03-18', '2020-03-18', '2020-03-20', 'Zala', 'Ásotthalom', 'MUV4255', 'SZAL14414'), " +
                    "('28271111-11111111', 3, '2020-03-10', '2020-03-10', '2020-03-10', 'Nem Szeged', 'Nem Ásotthalom', 'MUV4255', 'SZALL1T'), " +
                    "('77777777-77777777', 4, '2020-03-05', '2020-03-06', '2020-03-07', 'LERAKOHELY', 'FELRAKOHELY', 'lap222', 'szam555'), " +
                    "('99999999-88888888', 2, '2020-03-09', '2020-03-09', '2020-03-09', 'Szeged', 'Tompa', 'MUV42525', 'SZALLITO53'); ";

                string queryTetelek = "INSERT IGNORE INTO `szamlatetelek` (`fafajId`, `szamlaszam`, `mennyiseg`, `felhasznalas_modja`, `brutto_ar`, `netto_ar`) VALUES " +
                    "(1, '02021144-02021313', 1000, 'Rönk', 2000000, 1000000), " +
                    "(1, '02021144-02021314', 20000, 'Rönk', 2000000, 1000000), " +
                    "(2, '28271111-11111111', 2000, 'Tűzifa', 700000, 650000), " +
                    "(5, '77777777-77777777', 4300, 'Apríték', 400000, 370000), " +
                    "(7, '99999999-88888888', 5000, 'Tüzifa', 3000000, 2800000); ";
                MySqlCommand cmd1 = new MySqlCommand(querySzamlak, connection);
                cmd1.ExecuteNonQuery();
                MySqlCommand cmd2 = new MySqlCommand(queryTetelek, connection);
                cmd2.ExecuteNonQuery();
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