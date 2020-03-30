using Forest_Register.modell;
using Forest_Register.repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forest_Register
{
    public partial class FormForestRegister : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// Számlákat tartalmazó adattábla
        /// </summary>
        private DataTable szamlakDt = new DataTable();

        private void metroButtonSzamlakBetolt_Click(object sender, EventArgs e)
        {
            DataGridViewFrissiteseSzamla();
            DataGridViewSzamlakBeallit();
            GombokBeallitasaSzamla();
            dataGridViewSzamlak.SelectionChanged += dataGridViewSzamlak_SelectionChanged;
        }

        private void GombokBeallitasaSzamla()
        {
            metroPanelSzamla.Visible = false;
            metroPanelSzamlaTorolModosit.Visible = false;
            if(dataGridViewSzamlak.SelectedRows.Count > 0)
            {
                metroButtonUjSzamlaFelvetele.Visible = false;
            }
            else
            {
                metroButtonUjSzamlaFelvetele.Visible = true;
            }
        }

        public void FafajokFeltoltese()
        {
            metroComboBoxFafaj.DataSource = null;
            metroComboBoxFafaj.DataSource = repo.getFafajokMegnevezes();
        }

        private void VevokFeltoltese()
        {
            metroComboBoxSzamlaVevo.DataSource = null;
            metroComboBoxSzamlaVevo.DataSource = repo.getVevokNeve();
        }

        private void metroTextBoxMennyiseg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void metroTextBoxBruttoAr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void metroTextBoxNettoAr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void DataGridViewSzamlakBeallit()
        {
            szamlakDt.Columns[0].ColumnName = "Számlaszám";
            szamlakDt.Columns[0].Caption = "Számla számlaszám";
            szamlakDt.Columns[1].ColumnName="Fafaj";
            szamlakDt.Columns[1].Caption = "Számla fafaj";
            szamlakDt.Columns[2].ColumnName = "Vevő név";
            szamlakDt.Columns[2].Caption = "Számla vevő név";
            szamlakDt.Columns[3].ColumnName = "Mennyiség";
            szamlakDt.Columns[3].Caption = "Számla mennyiség";
            szamlakDt.Columns[4].ColumnName = "Felhasználás módja";
            szamlakDt.Columns[4].Caption = "Számla felhasználás módja";
            szamlakDt.Columns[5].ColumnName = "Bruttó ár";
            szamlakDt.Columns[5].Caption = "Számla bruttó ár";
            szamlakDt.Columns[6].ColumnName = "Nettó ár";
            szamlakDt.Columns[6].Caption = "Számla nettó ár";
            szamlakDt.Columns[7].ColumnName = "Teljesítés napja";
            szamlakDt.Columns[7].Caption = "Számla teljesítés napja";
            szamlakDt.Columns[8].ColumnName = "Számla keletkezése";
            szamlakDt.Columns[8].Caption = "Számla számla keletkezése";
            szamlakDt.Columns[9].ColumnName = "Kifizetés napja";
            szamlakDt.Columns[9].Caption = "Számla kifizetés napja";
            szamlakDt.Columns[10].ColumnName = "Lerakodási hely";
            szamlakDt.Columns[10].Caption = "Számla lerakodási hely";
            szamlakDt.Columns[11].ColumnName = "Felrakási hely";
            szamlakDt.Columns[11].Caption = "Számla felrakási hely";
            szamlakDt.Columns[12].ColumnName = "Műveleti lap sorszám";
            szamlakDt.Columns[12].Caption = "Számla műveleti lap sorszám";
            szamlakDt.Columns[13].ColumnName = "Szállítójegy sorszám";
            szamlakDt.Columns[13].Caption = "Számla szállítójegy sorszám";

            dataGridViewSzamlak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewSzamlak.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSzamlak.ReadOnly = true;
            dataGridViewSzamlak.AllowUserToDeleteRows = false;
            dataGridViewSzamlak.AllowUserToAddRows = false;
            dataGridViewSzamlak.MultiSelect = false;
        }

        private void metroButtonUjSzamlaFelvetele_Click(object sender, EventArgs e)
        {
            adatFelvetel = true;
            metroPanelSzamla.Visible = true;
            metroPanelSzamlaTorolModosit.Visible = true;
            metroButtonSzamlaHozzaad.Visible = true;
            metroButtonSzamlaMegse.Visible = true;
            metroTextBoxSzamlaSzam.ReadOnly = false;
            metroTextBoxSzamlaSzam.Text = string.Empty;
            metroComboBoxFafaj.Text = string.Empty;
            metroComboBoxSzamlaVevo.Text = string.Empty;
            metroTextBoxMennyiseg.Text = string.Empty;
            metroComboBoxFelhaszMod.Text = string.Empty;
            metroTextBoxBruttoAr.Text = string.Empty;
            metroTextBoxNettoAr.Text = string.Empty;
            metroDateTimeTeljesitesNap.Text = string.Empty;
            metroDateTimeSzamlaKel.Text = string.Empty;
            metroDateTimeTeljesitesNap.Text = string.Empty;
            metroTextBoxLerakodasiHely.Text = string.Empty;
            metroTextBoxFelrakasiHely.Text = string.Empty;
            metroTextBoxMuvLapSzam.Text = string.Empty;
            metroTextBoxSzallitojegySorszam.Text = string.Empty;

        }

        private void metroButtonSzamlaTorol_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            if ((dataGridViewSzamlak.SelectedRows.Count == 0) || dataGridViewSzamlak.Rows == null)
                return;

            string szamlaszam = dataGridViewSzamlak.SelectedRows[0].Cells[0].Value.ToString();
            if (MessageBox.Show(
                "Valóban törölni akarja a sort?",
                "Törlés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //Törlés listából
                try
                {
                    repo.SzamlaTorleseListabol(szamlaszam);
                }
                catch (RepositoryExceptionNemTudTorolni rennt)
                {
                    HibaUzenetKiirasa(rennt.Message);
                    Debug.WriteLine("Az erdő törlése nem sikerült, nincs a listába!");
                }

                //Törlés adatbázisban
                SzamlakRepositoryAdatbazisTabla szrat = new SzamlakRepositoryAdatbazisTabla();
                try
                {
                    szrat.SzamlaTorleseAdatbazisbol(szamlaszam);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //DataGridView frissítése
                DataGridViewFrissiteseSzamla();
                DataGridViewSzamlakBeallit();
            }
        }

        private void metroButtonSzamlaModosit_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            ErrorProviderekTorleseSzamla();
            try
            {
                Szamla modosult = new Szamla(
                    metroTextBoxSzamlaSzam.Text,
                    repo.KeresIdNevAlapjanSzamla(metroComboBoxFafaj.Text),
                    repo.KeresIdVevoAlapjanSzamla(metroComboBoxSzamlaVevo.Text),
                    Convert.ToInt32(metroTextBoxMennyiseg.Text),
                    metroComboBoxFelhaszMod.Text,
                    Convert.ToInt32(metroTextBoxBruttoAr.Text),
                    Convert.ToInt32(metroTextBoxNettoAr.Text),
                    metroDateTimeTeljesitesNap.Text,
                    metroDateTimeSzamlaKel.Text,
                    metroDateTimeKifizetesNapja.Text,
                    metroTextBoxLerakodasiHely.Text,
                    metroTextBoxFelrakasiHely.Text,
                    metroTextBoxMuvLapSzam.Text,
                    metroTextBoxSzallitojegySorszam.Text
                    );

                string szamlaszam = metroTextBoxSzamlaSzam.Text;

                //Módosítás listában
                try
                {
                    repo.SzamlaModositasaListaban(szamlaszam, modosult);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                    return;
                }

                //Módosítás adatbázisban
                SzamlakRepositoryAdatbazisTabla szrat = new SzamlakRepositoryAdatbazisTabla();
                try
                {
                    szrat.SzamlaModositasaAdatbazisban(szamlaszam, modosult);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }
                //DataGridView frissítése
                DataGridViewSzamlakBeallit();
                DataGridViewFrissiteseSzamla();
            }
            catch (RepositoryExceptionNemTudModositani rentm)
            {
                HibaUzenetKiirasa(rentm.Message);
                Debug.WriteLine("A módosítás nem sikerült, a számla nincs a listában!");
            }
            catch (Exception)
            {

            }
        }


        private void metroButtonSzamlaHozzaad_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            ErrorProviderekTorleseSzamla();
            try
            {
                Szamla ujSzamla = new Szamla(
                    metroTextBoxSzamlaSzam.Text,
                    repo.KeresIdNevAlapjanSzamla(metroComboBoxFafaj.Text),
                    repo.KeresIdVevoAlapjanSzamla(metroComboBoxSzamlaVevo.Text),
                    Convert.ToInt32(metroTextBoxMennyiseg.Text),
                    metroComboBoxFelhaszMod.Text,
                    Convert.ToInt32(metroTextBoxBruttoAr.Text),
                    Convert.ToInt32(metroTextBoxNettoAr.Text),
                    metroDateTimeTeljesitesNap.Text,
                    metroDateTimeSzamlaKel.Text,
                    metroDateTimeTeljesitesNap.Text,
                    metroTextBoxLerakodasiHely.Text,
                    metroTextBoxFelrakasiHely.Text,
                    metroTextBoxMuvLapSzam.Text,
                    metroTextBoxSzallitojegySorszam.Text
                    );

                string szamlaszam = metroTextBoxSzamlaSzam.Text;

                //Hozzáadás listához
                try
                {
                    repo.SzamlaHozzaadasaListahoz(ujSzamla);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //Hozzáadás adatbázishoz
                SzamlakRepositoryAdatbazisTabla szrat = new SzamlakRepositoryAdatbazisTabla();
                try
                {
                    szrat.SzamlaAdatbazisbaIllesztese(ujSzamla);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //DataGridView frissítése
                DataGridViewFrissiteseSzamla();
                if (dataGridViewSzamlak.SelectedRows.Count == 1)
                {
                    DataGridViewSzamlakBeallit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        
        private void metroButtonSzamlaMegse_Click(object sender, EventArgs e)
        {
            metroTextBoxSzamlaSzam.Text = string.Empty;
            metroComboBoxFafaj.Text = string.Empty;
            metroTextBoxMennyiseg.Text = string.Empty;
            metroComboBoxFelhaszMod.Text = string.Empty;
            metroTextBoxBruttoAr.Text = string.Empty;
            metroTextBoxNettoAr.Text = string.Empty;
            metroDateTimeTeljesitesNap.Text = string.Empty;
            metroDateTimeSzamlaKel.Text = string.Empty;
            metroDateTimeTeljesitesNap.Text = string.Empty;
            metroTextBoxLerakodasiHely.Text = string.Empty;
            metroTextBoxFelrakasiHely.Text = string.Empty;
            metroTextBoxMuvLapSzam.Text = string.Empty;
            metroTextBoxSzallitojegySorszam.Text = string.Empty;
        }

        private void dataGridViewSzamlak_SelectionChanged(object sender, EventArgs e)
        {
            if (adatFelvetel)
            {
                GombokBeallitasaKattintaskorSzamla();
            }
            if(dataGridViewSzamlak.SelectedRows.Count==1)
            {
                metroTextBoxSzamlaSzam.ReadOnly = true;
                metroPanelSzamlaTorolModosit.Visible = true;
                metroPanelSzamla.Visible = true;
                metroButtonUjSzamlaFelvetele.Visible = true;
                metroTextBoxSzamlaSzam.Text = dataGridViewSzamlak.SelectedRows[0].Cells[0].Value.ToString();
                metroComboBoxFafaj.Text = dataGridViewSzamlak.SelectedRows[0].Cells[1].Value.ToString();
                metroComboBoxSzamlaVevo.Text = dataGridViewSzamlak.SelectedRows[0].Cells[2].Value.ToString();
                metroTextBoxMennyiseg.Text = dataGridViewSzamlak.SelectedRows[0].Cells[3].Value.ToString();
                metroComboBoxFelhaszMod.Text = dataGridViewSzamlak.SelectedRows[0].Cells[4].Value.ToString();
                metroTextBoxBruttoAr.Text = dataGridViewSzamlak.SelectedRows[0].Cells[5].Value.ToString();
                metroTextBoxNettoAr.Text = dataGridViewSzamlak.SelectedRows[0].Cells[6].Value.ToString();
                metroDateTimeTeljesitesNap.Text = dataGridViewSzamlak.SelectedRows[0].Cells[7].Value.ToString();
                metroDateTimeSzamlaKel.Text = dataGridViewSzamlak.SelectedRows[0].Cells[8].Value.ToString();
                metroDateTimeKifizetesNapja.Text = dataGridViewSzamlak.SelectedRows[0].Cells[9].Value.ToString();
                metroTextBoxLerakodasiHely.Text = dataGridViewSzamlak.SelectedRows[0].Cells[10].Value.ToString();
                metroTextBoxFelrakasiHely.Text = dataGridViewSzamlak.SelectedRows[0].Cells[11].Value.ToString();
                metroTextBoxMuvLapSzam.Text = dataGridViewSzamlak.SelectedRows[0].Cells[12].Value.ToString();
                metroTextBoxSzallitojegySorszam.Text = dataGridViewSzamlak.SelectedRows[0].Cells[13].Value.ToString();
            }
        }

        private void GombokBeallitasaKattintaskorSzamla()
        {
            adatFelvetel = false;
            metroButtonUjSzamlaFelvetele.Visible = false;
            metroPanelSzamlaTorolModosit.Visible = true;
            ErrorProviderekTorleseSzamla();
        }

        private void ErrorProviderekTorleseSzamla()
        {
            errorProviderSzamlaszam.Clear();
            errorProviderFafaj.Clear();
            errorProviderVevoNev.Clear();
            errorProviderMennyiseg.Clear();
            errorProviderFaHaszMod.Clear();
            errorProviderBruttoAr.Clear();
            errorProviderNettoAr.Clear();
            errorProviderTelNap.Clear();
            errorProviderSzamlaKel.Clear();
            errorProviderKifNap.Clear();
            errorProviderLerakHely.Clear();
            errorProviderFelrakHely.Clear();
            errorProviderMuvlapSor.Clear();
            errorProviderSzallitojegySor.Clear();
        }
    }
}
