using Forest_Register.modell;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    partial class Repository
    {
        List<Vevo> vevok;

        public void setVevok(List<Vevo> vevok)
        {
            this.vevok = vevok;
        }

        public List<Vevo> getVevok()
        {
            return vevok;
        }

        public List<string> getVevokNev()
        {
            List<string> vevokNev = new List<string>();
            foreach (Vevo vevo in vevok)
            {
                vevokNev.Add(vevo.getVevoNev());
            }
            return vevokNev;
        }

        public DataTable VevoAdatokListabol()
        {
            DataTable vevokDt = new DataTable();
            vevokDt.Columns.Add("vevoId", typeof(int));
            vevokDt.Columns.Add("nev", typeof(string));
            vevokDt.Columns.Add("cim", typeof(string));
            vevokDt.Columns.Add("technikai_azonosito", typeof(string));
            vevokDt.Columns.Add("adoszam", typeof(string));
            foreach (Vevo v in vevok)
            {
                vevokDt.Rows.Add(v.getVevoId(), v.getVevoNev(), v.getVevoCim(), v.getTechnikaiAzonosito(), v.getAdoszam());
            }
            return vevokDt;
        }
    }
}
