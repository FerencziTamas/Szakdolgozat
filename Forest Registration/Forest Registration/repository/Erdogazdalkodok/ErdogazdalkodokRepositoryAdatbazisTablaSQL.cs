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
        public List<Erdogazdalkodo> getErdogazdalkodokAdatbazisbol()
        {
            List<Erdogazdalkodo> erdogazdalkodok = new List<Erdogazdalkodo>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Erdogazdalkodo.OsszesErdogazdalkodo();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string kod = dr["egKod"].ToString();
                    string nev = dr["nev"].ToString();
                    string cim = dr["cim"].ToString();

                    Erdogazdalkodo eg = new Erdogazdalkodo(kod, nev, cim);
                    erdogazdalkodok.Add(eg);

                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Az erdőgazdálkodó adatainak beolvasása az adatbázisból nem sikerült!");
            }
            return erdogazdalkodok;
        }

        public void erdogazdalkodoTorleseAdatbazisbol(string kod)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM `erdogazdalkodok` WHERE `egKod` = " + kod;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(kod + " kodú erdőgazdálkodó törlése nem sikerült.");
                throw new RepositoryException("Sikertelen törlés az adatbázisból.");
            }
        }

        public void ErdogazdalkodoModositasaAdatbazisban(string kod, Erdogazdalkodo modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.ErdogazdalkodoModositas(kod);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(kod + " kodú erdőgazdalkodó módosítása nem sikerült.");
                throw new RepositoryException("Sikertelen módosítás az adatbázisból.");
            }
        }

        public void ErdogazdalkodoAdatbazisbaIllesztese(Erdogazdalkodo ujErdogazdalkodo)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = ujErdogazdalkodo.ErdogazdalkodoHozzaadas();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(ujErdogazdalkodo + " erdőgazdalkodó beszúrása adatbázisba nem sikerült.");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisba.");
            }
        }

        public void ErGazTablaLetrehozas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string use = "USE erdo_adatbazis";
                string query = "CREATE TABLE IF NOT EXISTS `erdogazdalkodok` (" +
                    " `egKod` varchar(20) COLLATE utf8_hungarian_ci NOT NULL," +
                    " `nev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, " +
                    "`cim` varchar(20) COLLATE utf8_hungarian_ci NOT NULL, PRIMARY KEY(`egKod`)" +
                    ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci; ";
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
                throw new RepositoryException("Sikertelen beszúrás az adatbázisba.");
            }
        }

        public void ErGazTablaTorles()
        {

        }
    }
}
