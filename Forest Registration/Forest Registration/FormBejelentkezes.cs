using Forest_Register;
using Forest_Register.modell;
using Forest_Register.repository;
using Forest_Registration.repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forest_Registration
{
    public partial class FormBejelentkezes : MetroFramework.Forms.MetroForm
    {
        ErdokRepositoryAdatbazisTabla erat = new ErdokRepositoryAdatbazisTabla();
        ErdogazdalkodokRepositoryAdatbazisTabla egrat = new ErdogazdalkodokRepositoryAdatbazisTabla();
        SzamlakRepositoryAdatbazisTabla szrat = new SzamlakRepositoryAdatbazisTabla();
        VevokRepositoryAdatbazisTabla vrat = new VevokRepositoryAdatbazisTabla();
        AdatbazisRepository ar = new AdatbazisRepository();

        private readonly string connectionString;

        public FormBejelentkezes()
        {
            InitializeComponent();

            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        //Ellenőrzi hogy létezik-e az adatbázis
        public bool EllenorizAdatbazisLetezikE(string dataBase)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string cmdText = "SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME = '"+dataBase+"'";
            bool isExist = false;
            using (connection)
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(cmdText, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        isExist = reader.HasRows;
                    }
                }
                connection.Close();
            }
            return isExist;
        }

        private void FormBejelentkezes_Load(object sender, EventArgs e)
        {
            if (!EllenorizAdatbazisLetezikE("erdo_adatbazis"))
            {
                ar.AdatbazisLetrehozas();

                //Táblák létrehozása
                erat.ErdokTablaLetrehozas();
                egrat.ErGazokTablaLetrehozas();
                szrat.SzamlakTablaLetrehozas();
                vrat.VevokTablaLetrehozas();
                ar.FelhasznalokTablaLetrehozas();
                ar.FafajokTablaLetrehozas();
                ar.FahaszModTablaLetrehozas();
                ar.FakTablaLetrehozasa();

                //Táblák feltöltése
                erat.ErdoTesztAdatokFeltoltes();
                egrat.ErGazTesztAdatokFeltoltes();
                szrat.SzamlaTesztAdatokFeltoltese();
                vrat.VevokTesztAdatokFeltoltese();
                ar.FelhasznalokTesztAdatokFeltoltese();
                ar.FafajokTesztAdatokFeltoltese();
                ar.FaHaszModTesztAdatokFeltoltese();
                ar.FakTesztAdatokFeltoltese();
            }
            else
            {
                //Adatok lekérdezése adatbázisból
                erat.getErdokAdatbazisbol();
                egrat.getErdogazdalkodokAdatbazisbol();
                szrat.getSzamlakAdatbazisbol();
                vrat.getVevokAdatbazisbol();
            }
        }

        private void metroButtonBejelentkezes_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM `felhasznalok` WHERE email = '"+metroTextBoxEmail.Text.Trim()+"' AND jelszo = '"+metroTextBoxJelszo.Text.Trim()+"'";
            MySqlDataAdapter msda = new MySqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            msda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                FormForestRegister mainForm = new FormForestRegister();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Hibás e-mail cím vagy jelszó!");
            }

            
        }

        private void metroButtonReg_Click(object sender, EventArgs e)
        {
            FormRegisztracio regisztracio = new FormRegisztracio();
            this.Hide();
            regisztracio.Show();
        }

       
    }
}
