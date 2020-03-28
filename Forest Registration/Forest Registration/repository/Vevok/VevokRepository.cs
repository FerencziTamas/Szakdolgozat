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
            vevokDt.Columns.Add("adoszam", typeof(int));
            foreach (Vevo v in vevok)
            {
                vevokDt.Rows.Add(v.getVevoId(), v.getVevoNev(), v.getVevoCim(), v.getTechnikaiAzonosito(), v.getAdoszam());
            }
            return vevokDt;
        }



        public void VevoHozzaadasaListahoz(Vevo ujVevo)
        {
            try
            {
                vevok.Add(ujVevo);
            }
            catch (Exception e)
            {
                throw new RepositoryExceptionNemTudHozzaadni("A vevő hozzáadása nem sikerült");
            }
        }

        public void VevoModositasaListaban(int vevoId, Vevo modosult)
        {
            Vevo v = vevok.Find(x => x.getVevoId() == vevoId);
            if (v != null)
                v.modosit(modosult);
            else
                throw new RepositoryExceptionNemTudModositani("A vevő módosítása nem sikerült");
        }

        public void VevoTorleseListabol(int vevoId)
        {
            Vevo v = vevok.Find(x => x.getVevoId() == vevoId);
            if (v != null)
                vevok.Remove(v);
            else
                throw new RepositoryExceptionNemTudTorolni("A vevőt nem lehetett törölni.");
        }

        public int getKovVevoId()
        {
            if (vevok.Count == 0)
                return 1;
            else
                return vevok.Max(x => x.getVevoId()) + 1;
        }
    }
}
