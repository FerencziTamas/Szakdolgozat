using Forest_Register.modell;
using Forest_Register.repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.repository
{
    partial class FafajokRepositoryAdatbazisTabla
    {
        private readonly string connectionString;

        public FafajokRepositoryAdatbazisTabla()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        public List<Fafaj> getFafajokAdatbazisbol()
        {
            List<Fafaj> fafajok = new List<Fafaj>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM `fafajok`";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string megnevezes = dr["megnevezes"].ToString();
                    int fafajId = -1;
                    bool joEredmeny = false;
                    joEredmeny = int.TryParse(dr["fafajId"].ToString(), out fafajId);
                    if (joEredmeny)
                    {
                        Fafaj f = new Fafaj(fafajId, megnevezes);
                        fafajok.Add(f);
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("A fafajok beolvasása az adatbázisból nem sikerült!");
            }
            return fafajok;
        }
    }
}
