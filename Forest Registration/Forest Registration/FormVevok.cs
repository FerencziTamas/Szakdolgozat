using Forest_Register.modell;
using Forest_Register.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forest_Register
{
    public partial class FormForestRegister : MetroFramework.Forms.MetroForm
    {
        private DataTable vevokDt = new DataTable();

        private void metroButtonVevokBetolt_Click(object sender, EventArgs e)
        {
            DataGridViewFrissitese();
            DataGridViewVevokBeallit();
            GombokBeallitasaVevo();
            dataGridViewVevok.SelectionChanged += dataGridViewVevok_SelectionChanged;
        }

        private void dataGridViewVevok_SelectionChanged(object sender, EventArgs e)
        {
            if (adatFelvetel)
            {
                GombokBeallitasaKattintaskorVevo();
            }
            else
            {
                metroPanelVevoTorolModosit.Visible = true;
                metroPanelVevo.Visible = true;
                metroTextBoxVevoAzon.Text = dataGridViewVevok.SelectedRows[0].Cells[0].Value.ToString();
                metroTextBoxVevoNev.Text = dataGridViewVevok.SelectedRows[0].Cells[1].Value.ToString();
                metroTextBoxVevoCim.Text = dataGridViewVevok.SelectedRows[0].Cells[2].Value.ToString();
                metroTextBoxVevoTechAzon.Text = dataGridViewVevok.SelectedRows[0].Cells[0].Value.ToString();
                metroTextBoxVevoAdoszam.Text = dataGridViewVevok.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void GombokBeallitasaKattintaskorVevo()
        {
            adatFelvetel = false;
            metroButtonUjVevo.Visible = false;
            metroPanelVevoTorolModosit.Visible = true;
            ErrorProviderekTorleseVevo();
        }

        private void ErrorProviderekTorleseVevo()
        {
            errorProviderVevoNev.Clear();
            errorProviderVevoCim.Clear();
            errorProviderTechAzon.Clear();
            errorProviderAdoszam.Clear();
        }

        private void GombokBeallitasaVevo()
        {
            metroPanelVevo.Visible = false;
            metroPanelVevoTorolModosit.Visible = false;
            if(dataGridViewVevok.SelectedRows.Count > 0)
            {
                metroButtonUjVevo.Visible = false;
            }
            else
            {
                metroButtonUjVevo.Visible = true;
            }
        }

        private void DataGridViewVevokBeallit()
        {
            vevokDt.Columns[0].ColumnName = "Azonosító";
            vevokDt.Columns[0].Caption = "Vevő azonosító";
            vevokDt.Columns[1].ColumnName = "Név";
            vevokDt.Columns[1].Caption = "Vevő név";
            vevokDt.Columns[2].ColumnName = "Cím";
            vevokDt.Columns[2].Caption = "Vevő cím";
            vevokDt.Columns[3].ColumnName = "Technikai azonosító";
            vevokDt.Columns[3].Caption = "Vevő technikai azonosító";
            vevokDt.Columns[4].ColumnName = "Adószám";
            vevokDt.Columns[4].Caption = "Vevő adószám";

            dataGridViewVevok.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewVevok.ReadOnly = true;
            dataGridViewVevok.AllowUserToDeleteRows = false;
            dataGridViewVevok.AllowUserToAddRows = false;
            dataGridViewVevok.MultiSelect = false;
        }

        private void metroButtonVevoFelvetel_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            ErrorProviderekTorleseVevo();
            try
            {
                Vevo ujVevo = new Vevo(
                    Convert.ToInt32(metroTextBoxVevoAzon.Text),
                    metroTextBoxVevoNev.Text,
                    metroTextBoxVevoCim.Text,
                    metroTextBoxVevoTechAzon.Text,
                    Convert.ToInt32(metroTextBoxVevoAdoszam)
                    );
                int azonosito = Convert.ToInt32(metroTextBoxVevoAzon.Text);

                //Hozzáadás listához
                try
                {
                    repo.VevoHozzaadasaListahoz(ujVevo);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //Hozzáadás adatbázishoz
                VevokRepositoryAdatbazisTabla vrat = new VevokRepositoryAdatbazisTabla();
                try
                {
                    vrat.VevoAdatbazisbaIllesztese(ujVevo);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch
            {

            }
        }

        private void metroButtonVevokTorol_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonVevokModosit_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonUjVevo_Click(object sender, EventArgs e)
        {
            adatFelvetel = true;
            metroPanelVevo.Visible = true;
            metroPanelVevoTorolModosit.Visible = true;
            metroTextBoxVevoAzon.Text = string.Empty;
            metroTextBoxVevoNev.Text = string.Empty;
            metroTextBoxVevoCim.Text = string.Empty;
            metroTextBoxVevoTechAzon.Text = string.Empty;
            metroTextBoxVevoAdoszam.Text = string.Empty;
        }

        private void metroButtonVevoMegse_Click(object sender, EventArgs e)
        {
            metroTextBoxVevoAzon.Text = string.Empty;
            metroTextBoxVevoNev.Text = string.Empty;
            metroTextBoxVevoCim.Text = string.Empty;
            metroTextBoxVevoTechAzon.Text = string.Empty;
            metroTextBoxVevoAdoszam.Text = string.Empty;
        }
    }
}
