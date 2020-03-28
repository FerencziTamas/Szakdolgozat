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
        public List<Szamla> getSzamlakAdatbazisbol()
        {
            List<Szamla> szamlak = new List<Szamla>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Szamla.OsszesSzamla();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string szamlaszam = dr["szamlaszam"].ToString();
                    string fafajId = dr["fafajId"].ToString();
                    string vevo = dr["vevoId"].ToString();
                    string felhasznalas_modja = dr["felhasznalas_modja"].ToString();
                    string teljesites_napja = dr["teljesites_napja"].ToString();
                    string szamla_keletkezes = dr["szamla_keletkezes"].ToString();
                    string kifizetes_napja = dr["kifizetes_napja"].ToString();
                    string lerakodasi_hely = dr["lerakodasi_hely"].ToString();
                    string felrakasi_hely = dr["felrakasi_hely"].ToString();
                    string muveleti_lap_sorszam = dr["muveleti_lap_sorszam"].ToString();
                    string szallitojegy_sorszam = dr["szallitojegy_sorszam"].ToString();
                    int mennyiseg = -1;
                    bool joEredmeny = false;
                    joEredmeny = int.TryParse(dr["mennyiseg"].ToString(), out mennyiseg);
                    if (joEredmeny)
                    {
                        int brutto_ar = -1;
                        joEredmeny = int.TryParse(dr["brutto_ar"].ToString(), out brutto_ar);
                        if (joEredmeny)
                        {
                            int netto_ar = -1;
                            joEredmeny = int.TryParse(dr["netto_ar"].ToString(), out netto_ar);
                            if (joEredmeny)
                            {
                                Szamla sz = new Szamla(szamlaszam, fafajId, vevo, mennyiseg, felhasznalas_modja, brutto_ar, netto_ar, teljesites_napja, szamla_keletkezes, kifizetes_napja, lerakodasi_hely, felrakasi_hely, muveleti_lap_sorszam, szallitojegy_sorszam);
                                szamlak.Add(sz);
                            }
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("A számla adatainak beolvasása az adatbázisból nem sikerült!");
            }
            return szamlak;
        }

        public void SzamlaTorleseAdatbazisbol(string szamlaszam)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query1 = "DELETE FROM `szamlak` WHERE `szamlaszam`= \"" + szamlaszam+ "\"";
                string query2 = "DELETE FROM `szamlatetelek` WHERE szamlaszam = \"" + szamlaszam+ "\"";
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
                Debug.WriteLine(szamlaszam + " számú számlaszám törlése nem sikerült.");
                throw new RepositoryException("Sikertelen törlés az adatbázisból.");
            }
        }
        public void SzamlaModositasaAdatbazisban(string szamlaszam, Szamla modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query1 = modified.SzamlaModositasEgy(szamlaszam);
                string query2 = modified.SzamlaModositasKetto(szamlaszam);
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
                Debug.WriteLine(szamlaszam + " számú számla módosítása nem sikerült.");
                throw new RepositoryException("Sikertelen módosítás az adatbázisból.");
            }
        }

        public void SzamlaAdatbazisbaIllesztese(Szamla ujSzamla)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query1 = ujSzamla.SzamlaHozzaadasEgy();
                string query2 = ujSzamla.SzamlaHozzaadasKetto();
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
                Debug.WriteLine(ujSzamla + " számla beszúrása adatbázisba nem sikerült.");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisba.");
            }
        }

        public void fafajokComboboxba()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT megnevezes FROM `fafajok`";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw new RepositoryException("Sikertelen kiolvasás az adatbázisból.");
            }
        }
    }
}