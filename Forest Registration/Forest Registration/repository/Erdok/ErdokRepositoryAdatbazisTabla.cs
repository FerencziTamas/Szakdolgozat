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
    partial class ErdokRepositoryAdatbazisTabla
    {
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public ErdokRepositoryAdatbazisTabla()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        public void ErdokTablaLetrehozas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "CREATE TABLE IF NOT EXISTS `erdok` (" +
                    "`erdeszeti_azonosito` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`helyrajzi_szam` varchar(30) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`kor` int(11) NOT NULL, " +
                    "`terulet` int(11) NOT NULL COMMENT 'Négyzetkilóméterben', " +
                    "`hasznalatId` int(11) NOT NULL, " +
                    "`egKod` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "PRIMARY KEY(`erdeszeti_azonosito`), " +
                    "KEY `egKod` (`egKod`), " +
                    "KEY `hasznalatId` (`hasznalatId`)) " +
                    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";
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

        public void ErdokIdegenKulcsok()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryKeys = "ALTER TABLE `erdok` " +
                    "ADD CONSTRAINT `erdok_ibfk_1` FOREIGN KEY IF NOT EXISTS (`egKod`) REFERENCES `erdogazdalkodok` (`egKod`), " +
                    "ADD CONSTRAINT `erdok_ibfk_2` FOREIGN KEY IF NOT EXISTS (`egKod`) REFERENCES `erdogazdalkodok` (`egKod`), " +
                    "ADD CONSTRAINT `erdok_ibfk_3` FOREIGN KEY IF NOT EXISTS (`hasznalatId`) REFERENCES `fa_hasznalat_modjai` (`hasznalatId`); ";
                MySqlCommand cmdQueryKeys = new MySqlCommand(queryKeys, connection);
                cmdQueryKeys.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen idegen kulcsok beállítása.");
            }
        }

        public void ErdoTablaTorlese()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "DROP TABLE erdok";
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
                throw new RepositoryException("Sikertelen tábla törlés.");
            }
        }

        public void ErdoTesztAdatokFeltoltes()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO `erdo_adatbazis`.`erdok` (`erdeszeti_azonosito`, `helyrajzi_szam`, `kor`, `terulet`, `hasznalatId`, `egKod`) VALUES " +
                    "('DASISTERDO420', 'LISSZABON3', 40, 5000, 4, 'Én24141442'), " +
                    "('DASISTERDO421', 'LISSZABON3', 40, 5000, 4, 'Én24141442'), " +
                    "('DASISTERDO44', 'LISSZABON4', 40, 5000, 4, 'Kod2'), " +
                    "('DASISTERDO423', 'LISSZABON3', 40, 5000, 4, 'Én24141442'), " +
                    "('DASISTERDO422', 'LISSZABON3', 40, 5000, 4, 'Én24141442'), " +
                    "('ERDO555/', 'ÁSOTTALOM22-T', 40, 1000, 1, 'DASISTKOD'), " +
                    "('ERDO9', 'SZEGED54-K', 10, 870, 2, 'FAVAGO134252'), " +
                    "('valamiErdo', 'ZALA203', 21, 5000, 3, 'Hello There!');";
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

        public void ErdoAdatTorlesTablabol()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try 
            {
                connection.Open();
                string query = Erdo.TorolErdok();
                MySqlCommand cmd = new MySqlCommand(query,connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen adat törlés");
            }
        }
    }     
}
    