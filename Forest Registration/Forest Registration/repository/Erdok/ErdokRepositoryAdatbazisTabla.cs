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

        public void ErdoTablaLetrehozas()
        {
            MySqlConnection connection = new MySqlConnection();
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "CREATE TABLE IF NOT EXISTS `erdok` (" +
                    "`erdeszeti_azonosito` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`helyrajzi_szam` varchar(30) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`kor` int(11) NOT NULL, " +
                    "`terület` int(11) NOT NULL COMMENT 'Négyzetkilóméterben', " +
                    " `hasznalatId` int(11) NOT NULL, " +
                    "`egKod` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "PRIMARY KEY(`erdeszeti_azonosito`), " +
                    "KEY `egKod` (`egKod`), " +
                    "KEY `hasznalatId` (`hasznalatId`)) " +
                    "ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";
                string queryKeys = "ALTER TABLE `erdok` " +
                    "ADD CONSTRAINT `erdok_ibfk_1` FOREIGN KEY(`egKod`) REFERENCES `erdogazdalkodok` (`egKod`), " +
                    "ADD CONSTRAINT `erdok_ibfk_2` FOREIGN KEY(`egKod`) REFERENCES `erdogazdalkodok` (`egKod`), " +
                    "ADD CONSTRAINT `erdok_ibfk_3` FOREIGN KEY(`hasznalatId`) REFERENCES `fa_hasznalat_modjai` (`hasznalatId`); ";
                MySqlCommand cmdUse = new MySqlCommand(use, connection);
                MySqlCommand cmdQuery = new MySqlCommand(query, connection);
                MySqlCommand cmdQueryKeys = new MySqlCommand(queryKeys, connection);
                cmdUse.ExecuteNonQuery();
                cmdQuery.ExecuteNonQuery();
                cmdQueryKeys.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Sikertelen tábla létrehozás.");
            }

        }

        public void ErdoTablaTorlese()
        {
            MySqlConnection connection = new MySqlConnection();
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

        public void ErdoAdatTorlesTablabol()
        {
            MySqlConnection connection = new MySqlConnection();
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
    