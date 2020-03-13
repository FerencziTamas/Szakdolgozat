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
        public List<Vevo> getVevokAdatbazisbol()
        {
            List<Vevo> vevok = new List<Vevo>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Vevo.OsszesVevo();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string vevoNev = dr["nev"].ToString();
                    string vevoCim = dr["cim"].ToString();
                    string technikaiAzonosito = dr["technikai_azonosito"].ToString();
                    bool joEredmeny = false;
                    int vevoId = -1;
                    joEredmeny = int.TryParse(dr["vevoId"].ToString(), out vevoId);
                    if (joEredmeny)
                    {
                        int adoszam = -1;
                        joEredmeny = int.TryParse(dr["adoszam"].ToString(), out adoszam);
                        if (joEredmeny)
                        {
                            Vevo v = new Vevo(vevoId, vevoNev, vevoCim, technikaiAzonosito, adoszam);
                            vevok.Add(v);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("A vevő adatainak beolvasása az adatbázisból nem sikerült!");
            }
            return vevok;
        }

        public void vevoTorleseAdatbazisbol(int vevoId)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM `vevok` WHERE `vevoId` = " + vevoId;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(vevoId + " azonosítójú vevő törlése nem sikerült.");
                throw new RepositoryException("Sikertelen törlés az adatbázisból.");
            }
        }

        public void VevoModositasaAdatbazisban(int vevoId, Vevo modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.VevoModositas(vevoId);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(vevoId + " azonosítójú vevő módosítása nem sikerült.");
                throw new RepositoryException("Sikertelen módosítás az adatbázisból.");
            }
        }

        public void VevoAdatbazisbaIllesztese(Vevo ujVevo)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = ujVevo.VevoHozzaadas();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(ujVevo + " vevő beszúrása adatbázisba nem sikerült.");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisba.");
            }
        }
    }
}
