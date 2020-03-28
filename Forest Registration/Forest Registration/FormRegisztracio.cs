﻿using Forest_Register;
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

        

        private void metroButtonRegisztracio_Click(object sender, EventArgs e)
        {
            string nev = metroTextBoxFelhasznaloNev.Text;
            string email = metroTextBoxEmail.Text;
            string jelszo = metroTextBoxJelszo.Text;
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regexJelszo = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{7,}$");
            Match matchEmail = regexEmail.Match(email);
            Match matchJelszo = regexJelszo.Match(jelszo);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            if (nev != string.Empty)
            {
                if(email != string.Empty)
                {
                    if (matchEmail.Success)
                    {
                        if(jelszo != string.Empty)
                        {
                            if (matchJelszo.Success)
                            {
                                if (metroTextBoxJelszo.Text == metroTextBoxMegerosit.Text)
                                {
                                    string queryReg = "INSERT INTO `felhasznalok`(`nev`, `email`, `jelszo`) VALUES ('" + nev.Trim() + "', '" + email.Trim() + "', '" + jelszo.Trim() + "')";
                                    MySqlCommand cmd = new MySqlCommand(queryReg, connection);
                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                    MessageBox.Show("Sikeres regisztráció!");
                                }
                                else
                                {
                                    connection.Close();
                                    MessageBox.Show("A jelszavak nem egyeznek!");
                                }
                            }
                            else
                            {
                                connection.Close();
                                MessageBox.Show("A jelszónak tartalmaznia kell minimum 7 betűt, nagy- és kisbetűt és számot!");
                            }
                        }
                        else
                        {
                            connection.Close();
                            MessageBox.Show("Adja meg a jelszavát!");
                        }
                    }
                    else
                    {
                        connection.Close();
                        MessageBox.Show("Hibás az e-mail cím formátuma, adja meg újra! (helyes pl.: nev@cim.hu)");
                    }
                }
                else
                {
                    connection.Close();
                    MessageBox.Show("Adja meg az e-mail címét");
                }
            }
            else
            {
                connection.Close();
                MessageBox.Show("Adja meg a nevét!");
            }

            //Regisztráció után bejelentkezés
            string query = "SELECT * FROM `erdo_adatbazis`.`felhasznalok` WHERE email = '" + metroTextBoxEmail.Text.Trim() + "' AND jelszo = '" + metroTextBoxJelszo.Text.Trim() + "'";
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
                MessageBox.Show("Hibás a név, vagy a e-mail cím, vagy a jelszó,  vagy a jelszó megerősítése !");
            }
        }

        private void FormRegisztracio_FormClosed(object sender, FormClosedEventArgs e)
        {
            ar.AdatbazisTorles();
        }
    }
}
