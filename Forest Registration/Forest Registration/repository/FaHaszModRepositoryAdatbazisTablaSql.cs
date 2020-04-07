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
    partial class FaHaszModRepositoryAdatbazisTablaSql
    {
        private readonly string connectionString;

        public FaHaszModRepositoryAdatbazisTablaSql()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        public List<Fa_hasznalat_modja> getFaHaszModAdatbazisbol()
        {
            List<Fa_hasznalat_modja> faHaszModjai = new List<Fa_hasznalat_modja>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM `fa_hasznalat_modjai`";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string megnevezes = dr["megnevezes"].ToString();
                    string rovidites = dr["rovidites"].ToString();
                    int hasznalatId = -1;
                    bool joEredmeny = false;
                    joEredmeny = int.TryParse(dr["hasznalatId"].ToString(), out hasznalatId);
                    if (joEredmeny)
                    {
                        Fa_hasznalat_modja fhm = new Fa_hasznalat_modja(hasznalatId, megnevezes, rovidites);
                        faHaszModjai.Add(fhm);
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("A fahasználat módjainak beolvasása az adatbázisból nem sikerült!");
            }
            return faHaszModjai;
        }
    }
}
