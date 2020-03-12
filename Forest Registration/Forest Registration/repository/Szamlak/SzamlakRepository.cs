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
        List<Szamla> szamlak;

        public void setSzamlak(List<Szamla> szamlak)
        {
            this.szamlak = szamlak;
        }

        public List<Szamla> getSzamlak()
        {
            return szamlak;
        }


        public DataTable SzamlaAdatokListabol()
        {
            DataTable szamlaDt = new DataTable();
            szamlaDt.Columns.Add("szamlaszam", typeof(string));
            szamlaDt.Columns.Add("fafajId", typeof(int));
            szamlaDt.Columns.Add("vevoId", typeof(string));
            szamlaDt.Columns.Add("mennyiseg", typeof(int));
            szamlaDt.Columns.Add("felhasznalas_modja", typeof(string));
            szamlaDt.Columns.Add("brutto_ar", typeof(int));
            szamlaDt.Columns.Add("netto_ar",typeof(int));
            szamlaDt.Columns.Add("teljesites_napja", typeof(string));
            szamlaDt.Columns.Add("szamla_keletkezes", typeof(string));
            szamlaDt.Columns.Add("kifizetes_napja", typeof(string));
            szamlaDt.Columns.Add("lerakodasi_hely", typeof(string));
            szamlaDt.Columns.Add("felrakasi_hely", typeof(string));
            szamlaDt.Columns.Add("muveleti_lap_sorszam", typeof(string));
            szamlaDt.Columns.Add("szallitojegy_sorszam", typeof(string));
            foreach (Szamla sz in szamlak)
            {
                szamlaDt.Rows.Add(sz.getSzamlaSzam(), sz.getFafaj(), sz.getVevoNev(), sz.getMennyiseg(), sz.getFelhasznalasModja(), sz.getBruttoAr(), sz.getNettoAr(), sz.getTeljesitesNapja(), sz.getSzamlaKeletkezese(), sz.getKifizetesNapja(), sz.getLerakodasiHely(), sz.getFelrakasiHely(), sz.getMuveletiLapSorszam(), sz.getSzallitojegySorszam());
            }
            return szamlaDt;
        }

        public void SzamlaTorleseListabol(string szamlaszam)
        {
            Szamla sz = szamlak.Find(x => x.getSzamlaSzam() == szamlaszam);
            if (sz != null)
                szamlak.Remove(sz);
            else
                throw new RepositoryExceptionNemTudTorolni("A számlát nem lehetett törölni.");
        }

        public void SzamlaModositasaListaban(string szamlaszam, Szamla modosult)
        {
            Szamla sz = szamlak.Find(x => x.getSzamlaSzam() == szamlaszam);
            if (sz != null)
                sz.modosit(modosult);
            else
                throw new RepositoryExceptionNemTudModositani("A számla módosítása nem sikerült");
        }

        public void SzamlaHozzaadasaListahoz(Szamla ujSzamla)
        {
            try
            {
                szamlak.Add(ujSzamla);
            }
            catch (Exception e)
            {
                throw new RepositoryExceptionNemTudHozzaadni("A számla hozzáadása nem sikerült");
            }

        }
    }
}
