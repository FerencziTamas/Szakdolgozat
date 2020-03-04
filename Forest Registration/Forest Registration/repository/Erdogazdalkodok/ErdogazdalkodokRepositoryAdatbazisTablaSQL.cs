using Forest_Register.modell;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    class ErdogazdalkodokRepositoryAdatbazisTablaSQL
    {
        /*public List<Erdogazdalkodo> getErdokAdatbazisbol()
        {
            List<Erdo> erdok = new List<Erdo>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Erdo.osszesErdo();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string erdeszetiAzon = dr["erdeszeti_azonosito"].ToString();
                    string helyrajziSzam = dr["helyrajzi_szam"].ToString();
                    string fahasznalat = dr["hasznalatId"].ToString();
                    string erdogazdalkodo = dr["egKod"].ToString();
                    bool joEredmeny = false;
                    int kor = -1;
                    joEredmeny = int.TryParse(dr["kor"].ToString(), out kor);
                    if (joEredmeny)
                    {
                        int terulet = -1;
                        joEredmeny = int.TryParse(dr["terulet"].ToString(), out terulet);
                        if (joEredmeny)
                        {
                            Erdo e = new Erdo(erdeszetiAzon, helyrajziSzam, kor, terulet, fahasznalat, erdogazdalkodo);
                            erdok.Add(e);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Az erdő adatainak beolvasása az adatbázisból nem sikerült!");
            }
            return erdok;
        }

        public void erdoTorleseAdatbazisbol(string erdeszetiAzon)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM `erdok` WHERE `erdeszeti_azonosito` = " + erdeszetiAzon;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(erdeszetiAzon + " azonosítójú erdő törlése nem sikerült.");
                throw new RepositoryException("Sikertelen törlés az adatbázisból.");
            }
        }

        public void ErdoModositasaAdatbazisban(string erdeszetiAzon, Erdo modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.erdoModositas(erdeszetiAzon);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(erdeszetiAzon + " azonosítójú erdő módosítása nem sikerült.");
                throw new RepositoryException("Sikertelen módosítás az adatbázisból.");
            }
        }

        public void ErdoAdatbazisbaIllesztese(Erdo ujErdo)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = ujErdo.erdoHozzaadas();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(ujErdo + " erdő beszúrása adatbázisba nem sikerült.");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisból.");
            }
        }*/
    }
}
