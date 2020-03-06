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
        private DataTable erdogazdalkodokDt = new DataTable();

        private void metroButtonErdogazBetolt_Click(object sender, EventArgs e)
        {
            DataGridViewFrissitese();
            dataGridViewErdogazdalkodokBeallit();
            GombokBealitasaErdogazdalkodok();
            dataGridViewErdogazdalkodok.SelectionChanged += dataGridViewErdogazdalkodok_SelectionChanged;
        }

        private void GombokBealitasaErdogazdalkodok()
        {
            metroPanelErdoGazTorolModosit.Visible = false;
            metroPanelErGaz.Visible = false;
            if (dataGridViewErdogazdalkodok.SelectedRows.Count > 0)
            {
                metroButtonUjErGazFelvetele.Visible = false;
            }
            else
            {
                metroButtonUjErGazFelvetele.Visible = true;
            }
        }

        private void dataGridViewErdogazdalkodok_SelectionChanged(object sender, EventArgs e)
        {
            if (adatFelvetel)
            {
                GombokBeallitasaKattintaskorErdogazdalkodo();
            }
            if (dataGridViewErdogazdalkodok.SelectedRows.Count == 1)
            {
                metroPanelErdoGazTorolModosit.Visible = true;
                metroPanelErGaz.Visible = true;
                metroButtonUjErGazFelvetele.Visible = true;
                metroTextBoxErGazKod.Text = dataGridViewErdogazdalkodok.SelectedRows[0].Cells[0].Value.ToString();
                metroTextBoxErGazNev.Text = dataGridViewErdogazdalkodok.SelectedRows[0].Cells[1].Value.ToString();
                metroTextBoxErGazCim.Text = dataGridViewErdogazdalkodok.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void GombokBeallitasaKattintaskorErdogazdalkodo()
        {
            adatFelvetel = false;
            metroButtonUjErGazFelvetele.Visible = false;
            metroPanelErdoGazTorolModosit.Visible = false;
            ErrorProviderekTorleseErdogazdalkodok();
        }

        private void ErrorProviderekTorleseErdogazdalkodok()
        {
            errorProviderErGazKod.Clear();
            errorProviderErgazNev.Clear();
            errorProviderErgazCim.Clear();
        }

        private void dataGridViewErdogazdalkodokBeallit()
        {
            erdogazdalkodokDt.Columns[0].ColumnName = "Kód";
            erdogazdalkodokDt.Columns[0].Caption = "Erdőgazdálkodó kód";
            erdogazdalkodokDt.Columns[1].ColumnName = "Név";
            erdogazdalkodokDt.Columns[1].Caption = "Erdőgazdálkodó név";
            erdogazdalkodokDt.Columns[2].ColumnName = "Cím";
            erdogazdalkodokDt.Columns[2].Caption = "Erdőgazdálkodó cím";

            dataGridViewErdogazdalkodok.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewErdogazdalkodok.ReadOnly = true;
            dataGridViewErdogazdalkodok.AllowUserToDeleteRows = false;
            dataGridViewErdogazdalkodok.AllowUserToAddRows = false;
            dataGridViewErdogazdalkodok.MultiSelect = false;
        }

        private void metroButtonUjErGazFelvetele_Click(object sender, EventArgs e)
        {
            HibauzenetTorlese();
            ErrorProviderekTorleseErdogazdalkodok();
            try
            {
                Erdogazdalkodo ujErdogazdalkodo = new Erdogazdalkodo(
                    metroTextBoxErGazKod.Text,
                    metroTextBoxErGazNev.Text,
                    metroTextBoxErGazCim.Text
                    );
                string kod = metroTextBoxErGazKod.Text;

                //Hozzáadás listához
                try
                {
                    repo.erdogazdalkodoHozzadasaListahoz(ujErdogazdalkodo);
                }
                catch (Exception ex)
                {
                    HibaUzenetKiirasa(ex.Message);
                }

                //Hozzáadás adatbázishoz
                ErdogazdalkodoRepositoryAdatbazisTabla egrat = new ErdogazdalkodoRepositoryAdatbazisTabla();
                try
                {
                    egrat.ErdogazdalkodoAdatbazisbaIllesztese(ujErdogazdalkodo);
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void metroButtonEdGazTorol_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonErGazModosit_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonUjErGazHozzaad_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonErGazMegse_Click(object sender, EventArgs e)
        {

        }
    }
}
