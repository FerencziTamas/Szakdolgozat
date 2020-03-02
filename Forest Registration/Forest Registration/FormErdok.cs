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
            metroPaneljErdo.Visible = false;
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
            erdokDt.Columns[2].ColumnName = "Terület";
            erdokDt.Columns[2].Caption = "Erdő terület";
            erdokDt.Columns[2].ColumnName = "Fahasználat";
            erdokDt.Columns[2].Caption = "Erdő fahasználat";
            erdokDt.Columns[2].ColumnName = "Erdőgazdálkodó";
            erdokDt.Columns[2].Caption = "Erdő erdőgazdálkodó";

            dataGridViewErdok.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewErdok.ReadOnly = true;
            dataGridViewErdok.AllowUserToDeleteRows = false;
            dataGridViewErdok.AllowUserToAddRows = false;
            dataGridViewErdok.MultiSelect = false;
        }

        private void DataGridViewFrissitese()
        {
            erdokDt = repo.ErdoAdatokListabol();
        }

        private void dataGridViewErdok_SelectionChanged(object sender, EventArgs e)
        {
            if (adatFelvetel)
            {

            }
            if (dataGridViewErdok.SelectedRows.Count == 1)
            {
                metroPanelErdoTorlesModositas.Visible = true;
                metroPaneljErdo.Visible = true;
                metroButtonUjErdo.Visible = true;
                metroTextBoxErdeszetiAzon.Text = dataGridViewErdok.SelectedRows[0].Cells[0].Value.ToString();
                metroTextBoxHelyrajziSzam.Text = dataGridViewErdok.SelectedRows[0].Cells[1].Value.ToString();
                numericUpDownErdoKor.Value = Convert.ToInt32(dataGridViewErdok.SelectedRows[0].Cells[2].Value);
                metroTextBoxTerulet.Text = dataGridViewErdok.SelectedRows[0].Cells[3].Value.ToString();
                metroTextBoxErdogazNev.Text = dataGridViewErdok.SelectedRows[0].Cells[4].Value.ToString();
                metroTextBoxFahasznalatModja.Text = dataGridViewErdok.SelectedRows[0].Cells[5].Value.ToString();
            }
        }
    }
}
