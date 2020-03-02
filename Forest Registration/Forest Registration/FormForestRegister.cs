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

namespace Forest_Registration
{
    public partial class FormForestRegister : MetroFramework.Forms.MetroForm
    {
        Repository repo = new Repository();
        public FormForestRegister()
        {
            InitializeComponent();
        }

        private void metroTabPageSzamlak_Click(object sender, EventArgs e)
        {

        }
    }
}
