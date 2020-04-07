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
        ErdokRepositoryAdatbazisTabla erat = new ErdokRepositoryAdatbazisTabla();
        ErdogazdalkodokRepositoryAdatbazisTabla egrat = new ErdogazdalkodokRepositoryAdatbazisTabla();
        SzamlakRepositoryAdatbazisTabla szrat = new SzamlakRepositoryAdatbazisTabla();
        VevokRepositoryAdatbazisTabla vrat = new VevokRepositoryAdatbazisTabla();
        FafajokRepositoryAdatbazisTablaSql frat = new FafajokRepositoryAdatbazisTablaSql();
        FaHaszModRepositoryAdatbazisTablaSql fhmrat = new FaHaszModRepositoryAdatbazisTablaSql();

        bool adatFelvetel = false;

        public FormForestRegister()
        {
            InitializeComponent();
        }

        private void FormForestRegister_Load(object sender, EventArgs e)
        {
            repo.setErdok(erat.getErdokAdatbazisbol());
            repo.setErdogazdalkodok(egrat.getErdogazdalkodokAdatbazisbol());
            repo.setSzamlak(szrat.getSzamlakAdatbazisbol());
            repo.setVevok(vrat.getVevokAdatbazisbol());
            repo.setFafajok(frat.getFafajokAdatbazisbol());
            repo.setFaHaszModjai(fhmrat.getFaHaszModAdatbazisbol());

            //comboboxok betöltése
            ErdogazdalkodokFeltoltese();
            FafajokFeltoltese();
            FaHaszModFeltoltese();
            VevokFeltoltese();
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

        private void DataGridViewFrissiteseErdo()
        {
            metroButtonUjErdo.Visible = true;
            erdokDt = repo.ErdoAdatokListabol();
            dataGridViewErdok.DataSource = null;
            dataGridViewErdok.DataSource = erdokDt;
        }

        private void DataGridViewFrissiteseErGaz()
        {
            erdogazdalkodokDt = repo.ErdogazdalkodoAdatokListabol();
            dataGridViewErdogazdalkodok.DataSource = null;
            dataGridViewErdogazdalkodok.DataSource = erdogazdalkodokDt;
            metroButtonUjErdo.Visible = true;
        }

        private void DataGridViewFrissiteseVevo()
        {
            vevokDt = repo.VevoAdatokListabol();
            dataGridViewVevok.DataSource = null;
            dataGridViewVevok.DataSource = vevokDt;
        }

        private void DataGridViewFrissiteseSzamla()
        {
            szamlakDt = repo.SzamlaAdatokListabol();
            dataGridViewSzamlak.DataSource = null;
            dataGridViewSzamlak.DataSource = szamlakDt;
            dataGridViewSzamlak.Columns[7].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridViewSzamlak.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridViewSzamlak.Columns[9].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        private void metroPanelVevo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormForestRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            ar.AdatbazisTorles();
        }

        private void metroTextBoxNettoAr_Click(object sender, EventArgs e)
        {

        }
    }
}
