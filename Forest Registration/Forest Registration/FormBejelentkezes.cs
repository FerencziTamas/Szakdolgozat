using Forest_Register;
using Forest_Register.modell;
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
        private readonly string connectionString;

        AdatbazisRepository ar = new AdatbazisRepository();

        public FormBejelentkezes()
        {
            InitializeComponent();

            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
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

            ar.adatbazisLetrehozas();
        }

        private void metroButtonReg_Click(object sender, EventArgs e)
        {
            FormRegisztracio regisztracio = new FormRegisztracio();
            this.Hide();
            regisztracio.Show();
        }
    }
}
