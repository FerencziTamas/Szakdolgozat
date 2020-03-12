using Forest_Register.modell;
using Forest_Register.repository;
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
        private DataTable szamlaDt = new DataTable();

        private void metroButtonSzamlakBetolt_Click(object sender, EventArgs e)
        {
            DataGridViewFrissitese();
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
                metroButtonUjSzamlaFelvetele.Visible = true;
            }
            else
            {
                metroButtonUjSzamlaFelvetele.Visible = false;
            }
        }

        private void DataGridViewSzamlakBeallit()
        {
            szamlaDt.Columns[0].ColumnName = "Számlaszám";
            szamlaDt.Columns[0].Caption = "Számla számlaszám";
            szamlaDt.Columns[1].ColumnName="Fafaj";
            szamlaDt.Columns[1].Caption = "Számla fafaj";
            szamlaDt.Columns[2].ColumnName = "Vevő név";
            szamlaDt.Columns[2].Caption = "Számla vevő név";
            szamlaDt.Columns[3].ColumnName = "Mennyiség";
            szamlaDt.Columns[3].Caption = "Számla mennyiség";
            szamlaDt.Columns[4].ColumnName = "Felhasználás módja";
            szamlaDt.Columns[4].Caption = "Számla felhasználás módja";
            szamlaDt.Columns[5].ColumnName = "Bruttó ár";
            szamlaDt.Columns[5].Caption = "Számla bruttó ár";
            szamlaDt.Columns[6].ColumnName = "Nettó ár";
            szamlaDt.Columns[6].Caption = "Számla nettó ár";
            szamlaDt.Columns[7].ColumnName = "Teljesítés napja";
            szamlaDt.Columns[7].Caption = "Számla teljesítés napja";
            szamlaDt.Columns[8].ColumnName = "Számla keletkezése";
            szamlaDt.Columns[8].Caption = "Számla számla keletkezése";
            szamlaDt.Columns[9].ColumnName = "Kifizetés napja";
            szamlaDt.Columns[9].Caption = "Számla kifizetés napja";
            szamlaDt.Columns[10].ColumnName = "Lerakodási hely";
            szamlaDt.Columns[10].Caption = "Számla lerakodási hely";
            szamlaDt.Columns[11].ColumnName = "Felrakási hely";
            szamlaDt.Columns[11].Caption = "Számla felrakási hely";
            szamlaDt.Columns[12].ColumnName = "Műveleti lap sorszám";
            szamlaDt.Columns[12].Caption = "Számla műveleti lap sorszám";
            szamlaDt.Columns[13].ColumnName = "Szállítójegy sorszám";
            szamlaDt.Columns[13].Caption = "Számla szállítójegy sorszám";

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
            metroTextBoxSzamlaSzam.Text = string.Empty;
            metroComboBoxFafaj.Text = string.Empty;
            metroTextBoxSzamlaVevoNev.Text = string.Empty;
            metroTextBoxMennyiseg.Text = string.Empty;
            metroTextBoxFahasznalatModja.Text = string.Empty;
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

            string szamlaszam = dataGridViewSzamlak.SelectedRows[0].Index.ToString();
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
                DataGridViewFrissitese();
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
                    metroComboBoxFafaj.Text,
                    metroTextBoxSzamlaVevoNev.Text,
                    Convert.ToInt32(metroTextBoxMennyiseg.Text),
                    metroTextBoxFahasznalatModja.Text,
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
                    szrat.SzamlaTorleseAdatbazisbol(szamlaszam);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //DataGridView frissítése
                DataGridViewFrissitese();
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
                    metroComboBoxFafaj.Text,
                    metroTextBoxSzamlaVevoNev.Text,
                    Convert.ToInt32(metroTextBoxMennyiseg.Text),
                    metroTextBoxFahasznalatModja.Text,
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
                if (dataGridViewSzamlak.SelectedRows.Count == 1)
                {
                    DataGridViewSzamlakBeallit();
                }
            }
            catch (Exception)
            {

            }
        }
        private void metroButtonSzamlaMegse_Click(object sender, EventArgs e)
        {
            metroTextBoxSzamlaSzam.Text = string.Empty;
            metroComboBoxFafaj.Text = string.Empty;
            metroTextBoxSzamlaVevoNev.Text = string.Empty;
            metroTextBoxMennyiseg.Text = string.Empty;
            metroTextBoxFahasznalatModja.Text = string.Empty;
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
                metroPanelSzamlaTorolModosit.Visible = true;
                metroPanelSzamla.Visible = true;
                metroTextBoxSzamlaSzam.Text = dataGridViewSzamlak.SelectedRows[0].Cells[0].Value.ToString();
                metroComboBoxFafaj.Text = dataGridViewSzamlak.SelectedRows[0].Cells[1].Value.ToString();
                metroTextBoxSzamlaVevoNev.Text = dataGridViewSzamlak.SelectedRows[0].Cells[2].ToString();
                metroTextBoxMennyiseg.Text = dataGridViewSzamlak.SelectedRows[0].Cells[3].ToString();
                metroComboBoxFelhaszMod.Text = dataGridViewSzamlak.SelectedRows[0].Cells[4].ToString();
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
