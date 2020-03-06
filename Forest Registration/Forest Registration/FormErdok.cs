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
        /// <summary>
        /// Erdőket tartalmazó adattábla
        /// </summary>
        private DataTable erdokDt = new DataTable();

        bool adatFelvetel = false;

        private void metroButtonBetoltErdok_Click(object sender, EventArgs e)
        {
            DataGridViewFrissitese();
            dataGridViewErdokBeallit();
            GombokBealitasaErdo();
            dataGridViewErdok.SelectionChanged += dataGridViewErdok_SelectionChanged;
        }

        private void GombokBealitasaErdo()
        {
            metroPanelErdo.Visible = false;
            metroPanelErdoTorlesModositas.Visible = false;
            if (dataGridViewErdok.SelectedRows.Count > 0)
            {
                metroButtonUjErdo.Visible = false;
            }
            else
            {
                metroButtonUjErdo.Visible = true;
            }
        }

        private void dataGridViewErdokBeallit()
        {
            erdokDt.Columns[0].ColumnName = "Erdészeti azonosító";
            erdokDt.Columns[0].Caption = "Erdő erdészeti azonosító";
            erdokDt.Columns[1].ColumnName = "Helyrajzi szám";
            erdokDt.Columns[1].Caption = "Erdő helyrajzi szám";
            erdokDt.Columns[2].ColumnName = "Kor";
            erdokDt.Columns[2].Caption = "Erdő kor";
            erdokDt.Columns[3].ColumnName = "Terület";
            erdokDt.Columns[3].Caption = "Erdő terület";
            erdokDt.Columns[4].ColumnName = "Fahasználat";
            erdokDt.Columns[4].Caption = "Erdő fahasználat";
            erdokDt.Columns[5].ColumnName = "Erdőgazdálkodó";
            erdokDt.Columns[5].Caption = "Erdő erdőgazdálkodó";

            dataGridViewErdok.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewErdok.ReadOnly = true;
            dataGridViewErdok.AllowUserToDeleteRows = false;
            dataGridViewErdok.AllowUserToAddRows = false;
            dataGridViewErdok.MultiSelect = false;
        }



        private void dataGridViewErdok_SelectionChanged(object sender, EventArgs e)
        {
            if (adatFelvetel)
            {
                GombokBeallitasaKattintaskorErdo();
            }
            if (dataGridViewErdok.SelectedRows.Count == 1)
            {
                metroPanelErdoTorlesModositas.Visible = true;
                metroPanelErdo.Visible = true;
                metroTextBoxErdeszetiAzon.Text = dataGridViewErdok.SelectedRows[0].Cells[0].Value.ToString();
                metroTextBoxHelyrajziSzam.Text = dataGridViewErdok.SelectedRows[0].Cells[1].Value.ToString();
                numericUpDownErdoKor.Value = Convert.ToInt32(dataGridViewErdok.SelectedRows[0].Cells[2].Value);
                metroTextBoxTerulet.Text = dataGridViewErdok.SelectedRows[0].Cells[3].Value.ToString();
                metroTextBoxErdogazNev.Text = dataGridViewErdok.SelectedRows[0].Cells[4].Value.ToString();
                metroTextBoxFahasznalatModja.Text = dataGridViewErdok.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void GombokBeallitasaKattintaskorErdo()
        {
            adatFelvetel = false;
            metroButtonUjErdo.Visible = false;
            metroPanelErdoTorlesModositas.Visible = true;
            ErrorProviderekTorleseErdo();
        }

        private void ErrorProviderekTorleseErdo()
        {
            errorProviderErdeszetiAzon.Clear();
            errorProviderHelyrajziSzam.Clear();
            errorProviderKor.Clear();
            errorProviderTerulet.Clear();
            errorProviderErgazNev.Clear();
            errorProviderFaHaszMod.Clear();
        }

        /// <summary>
        /// Erdő panel megjelenítése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonUjErdo_Click(object sender, EventArgs e)
        {
            adatFelvetel = true;
            metroPanelErdo.Visible = true;
            metroPanelErdoTorlesModositas.Visible = true;
            metroTextBoxErdeszetiAzon.Text = string.Empty;
            metroTextBoxHelyrajziSzam.Text = string.Empty;
            numericUpDownErdoKor.Value = 0;
            metroTextBoxTerulet.Text = string.Empty;
            metroTextBoxErdogazNev.Text = string.Empty;
            metroTextBoxFahasznalatModja.Text = string.Empty;
        }

        /// <summary>
        /// Erdő törlése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtoneErdoTorles_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            if ((dataGridViewErdok.Rows == null) || (dataGridViewErdok.Rows.Count == 0))
                return;

            string erdeszetiAzon = dataGridViewErdok.SelectedRows[0].Index.ToString();
            if (MessageBox.Show(
                "Valóban törölni akarja a sort?",
                "Törlés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                
                //Törlés listából
                try
                {
                    repo.erdoTorleseListabol(erdeszetiAzon);
                }
                catch (RepositoryExceptionNemTudTorolni rennt)
                {
                    HibaUzenetKiirasa(rennt.Message);
                    Debug.WriteLine("Az erdő törlése nem sikerült, nincs a listába!");
                }

                //Törlés adatbázisból
                ErdokRepositoryAdatbazisTabla erat = new ErdokRepositoryAdatbazisTabla();
                try
                {
                    erat.erdoTorleseAdatbazisbol(erdeszetiAzon);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //DataGridView frissítése
                DataGridViewFrissitese();
                dataGridViewErdokBeallit();
            }
        }

        /// <summary>
        /// Erdő módosítása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonErdoModositas_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            ErrorProviderekTorleseErdo();
            try
            {
                Erdo modosult = new Erdo(
                    metroTextBoxErdeszetiAzon.Text,
                    metroTextBoxHelyrajziSzam.Text,
                    Convert.ToInt32(numericUpDownErdoKor.Value),
                    Convert.ToInt32(metroTextBoxTerulet.Text),
                    metroTextBoxErdogazNev.Text,
                    metroTextBoxFahasznalatModja.Text
                    );
                string erdeszetiAzon = metroTextBoxErdeszetiAzon.Text;

                //Modósítás listában
                try
                {
                    repo.erdoModositasaListaban(erdeszetiAzon, modosult);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                    return;
                }

                //Modósítás adatbázisban
                ErdokRepositoryAdatbazisTabla erat = new ErdokRepositoryAdatbazisTabla();
                try
                {
                    erat.ErdoModositasaAdatbazisban(erdeszetiAzon, modosult);
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
                Debug.WriteLine("A módosítás nem sikerült, az erdő nincs a listában!");
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Új erdő hozzáadása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonHozzaad_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            ErrorProviderekTorleseErdo();
            try
            {
                Erdo ujErdo = new Erdo(
                    metroTextBoxErdeszetiAzon.Text,
                    metroTextBoxHelyrajziSzam.Text,
                    Convert.ToInt32(numericUpDownErdoKor.Value),
                    Convert.ToInt32(metroTextBoxTerulet.Text),
                    metroTextBoxErdogazNev.Text,
                    metroTextBoxFahasznalatModja.Text
                    );
                string azonosito = metroTextBoxErdeszetiAzon.Text;

                //Hozzáadás listához
                try
                {
                    repo.erdoHozzaadasaListahoz(ujErdo);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //Hozzáadás adatbázishoz
                ErdokRepositoryAdatbazisTabla erat = new ErdokRepositoryAdatbazisTabla();
                try
                {
                    erat.ErdoAdatbazisbaIllesztese(ujErdo);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //DataGridView frissítése
                if (dataGridViewErdok.SelectedRows.Count==1)
                {
                    dataGridViewErdokBeallit();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Törli a textboxok, numericUpDown tartalmát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButtonMegse_Click(object sender, EventArgs e)
        {
            metroTextBoxErdeszetiAzon.Text = string.Empty;
            metroTextBoxHelyrajziSzam.Text = string.Empty;
            numericUpDownErdoKor.Value = 0;
            metroTextBoxTerulet.Text = string.Empty;
            metroTextBoxErdogazNev.Text = string.Empty;
            metroTextBoxFahasznalatModja.Text = string.Empty;
        }


    }
}
