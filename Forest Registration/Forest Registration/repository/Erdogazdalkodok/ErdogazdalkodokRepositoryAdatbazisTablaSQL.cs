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
                    string egKod = dr["egKod"].ToString();
                    string erdogazNev = dr["erdogazNev"].ToString();
                    string erdogazCim = dr["erdogazCim"].ToString();

                    Erdogazdalkodo eg = new Erdogazdalkodo(egKod, erdogazNev, erdogazCim);
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

        public void erdogazdalkodoTorleseAdatbazisbol(string egKod)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM `erdogazdalkodok` WHERE `egKod` = \"" + egKod+ "\"";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(egKod + " kodú erdőgazdálkodó törlése nem sikerült.");
                throw new RepositoryException("Sikertelen törlés az adatbázisból. Egyik erdő tartalmazza az erdőgazdálkodót!");
            }
        }

        public void ErdogazdalkodoModositasaAdatbazisban(string egKod, Erdogazdalkodo modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.ErdogazdalkodoModositas(egKod);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(egKod + " kodú erdőgazdalkodó módosítása nem sikerült.");
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
    }
}
