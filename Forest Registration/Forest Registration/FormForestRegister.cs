using Forest_Register.repository;
using Forest_Registration.repository;
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
        Repository repo = new Repository();
        AdatbazisRepository ar = new AdatbazisRepository();

        bool adatFelvetel = false;

        public FormForestRegister()
        {
            InitializeComponent();
        }

        private void erdőkKiírtatásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroTabControlErdok.SelectTab("metroTabPageErdok");
        }

        private void erdőToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroTabControlErdok.SelectTab("metroTabPageErGaz");
        }

        private void számlákKiíratásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroTabControlErdok.SelectTab("metroTabPageSzamlak");
        }

        private void vevőkKiíratásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroTabControlErdok.SelectTab("metroTabPageVevok");
        }

        private void aProgramInformációiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroTabControlErdok.SelectTab("metroTabPageProgram");
        }

        private void HibauzenetTorlese()
        {
            toolStripLabelHibauzenet.ForeColor = Color.Black;
            toolStripLabelHibauzenet.Text = "";
        }
        private void HibaUzenetKiirasa(string hibauzenet)
        {
            toolStripLabelHibauzenet.ForeColor = Color.Red;
            toolStripLabelHibauzenet.Text = hibauzenet;
            
        }

        private void DataGridViewFrissitese()
        {
            erdokDt = repo.ErdoAdatokListabol();
            erdogazdalkodokDt = repo.ErdogazdalkodoAdatokListabol();
            szamlakDt = repo.SzamlaAdatokListabol();
            vevokDt = repo.VevoAdatokListabol();

            dataGridViewErdok.DataSource = null;
            dataGridViewErdok.DataSource = erdokDt;
            dataGridViewErdogazdalkodok.DataSource = null;
            dataGridViewErdogazdalkodok.DataSource = erdogazdalkodokDt;
            dataGridViewSzamlak.DataSource = null;
            dataGridViewSzamlak.DataSource = szamlakDt;
            dataGridViewVevok.DataSource = null;
            dataGridViewVevok.DataSource = vevokDt;
        }

        

        private void metroPanelVevo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTabControlErdok_Selected(object sender, TabControlEventArgs e)
        {
            //Az erdők tabpage comboboxába betölti az erdőgazdálkodók nevét
            ErdogazdalkodokFeltoltese();
        }

        private void FormForestRegister_Leave(object sender, EventArgs e)
        {
            ar.AdatbazisTorles();
        }
    }
}
