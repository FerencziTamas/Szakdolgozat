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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forest_Registration
{
    public partial class FormRegisztracio : MetroFramework.Forms.MetroForm
    {
        private readonly string connectionString;
        AdatbazisRepository ar = new AdatbazisRepository();

        public FormRegisztracio()
        {
            InitializeComponent();

            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButtonBej_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBejelentkezes bejelentkezes = new FormBejelentkezes();
            bejelentkezes.Show();
        }

        private void metroButtonRegisztracio_Click(object sender, EventArgs e)
        {
            string email = metroTextBoxEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            if (match.Success)
            {
                if (metroTextBoxJelszo.Text == metroTextBoxMegerosit.Text)
                {
                    string query = "INSERT INTO `felhasznalok`(`nev`, `email`, `jelszo`) VALUES ('"+metroTextBoxFelhasznaloNev.Text.Trim()+"', '"+email.Trim()+"', '"+metroTextBoxJelszo.Text.Trim()+"')";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Sikeres regisztráció!");

                }
            }
            else
            {
                connection.Close();
                MessageBox.Show("Sikertelen regisztráció!");
            }
        }

        private void FormRegisztracio_FormClosed(object sender, FormClosedEventArgs e)
        {
            ar.AdatbazisTorles();
        }
    }
}
