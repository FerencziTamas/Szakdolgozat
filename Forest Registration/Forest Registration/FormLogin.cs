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
        private void InitializeComponent()
        {
            this.metroLabelEmail = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabelEmail
            // 
            this.metroLabelEmail.AutoSize = true;
            this.metroLabelEmail.Location = new System.Drawing.Point(239, 43);
            this.metroLabelEmail.Name = "metroLabelEmail";
            this.metroLabelEmail.Size = new System.Drawing.Size(108, 19);
            this.metroLabelEmail.TabIndex = 0;
            this.metroLabelEmail.Text = "metroLabelEmail";
            // 
            // FormForestRegister
            // 
            this.ClientSize = new System.Drawing.Size(537, 300);
            this.Controls.Add(this.metroLabelEmail);
            this.Name = "FormForestRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
