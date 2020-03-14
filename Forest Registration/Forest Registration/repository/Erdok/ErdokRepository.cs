using Forest_Register.modell; //modell osztály meghívva
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
        List<Erdo> erdok;

        public void setErdok(List<Erdo> erdok)
        {
            this.erdok = erdok;
        }

        public List<Erdo> getErdok()
        {
            return erdok;
        }

        public DataTable ErdoAdatokListabol()
        {
            DataTable erdoDt = new DataTable();
            erdoDt.Columns.Add("erdeszeti_azonosito", typeof(string));
            erdoDt.Columns.Add("helyrajzi_szam", typeof(string));
            erdoDt.Columns.Add("kor", typeof(int));
            erdoDt.Columns.Add("terulet", typeof(int));
            erdoDt.Columns.Add("hasznalatId", typeof(int));
            erdoDt.Columns.Add("egKod", typeof(string));
            foreach (Erdo e in erdok)
            {
                erdoDt.Rows.Add(e.getErdeszetiAzon(), e.getHelyrajziSzam(), e.getKor(), e.getTerulet(), e.getFahasznalat(), e.getErdogazdalkodo());
            }
            return erdoDt;
        }

        private void ErdoListaFeltolteseAdatbazisbol(DataTable erdokDt)
        {
            foreach (DataRow row in erdokDt.Rows)
            {
                string erdeszetiAzon = row[0].ToString();
                string helyrajziSzam = row[1].ToString();
                int kor = Convert.ToInt32(row[2]);
                int terulet = Convert.ToInt32(row[3]);
                string fahasznalat = row[4].ToString();
                string erdogazdalkodo = row[5].ToString();
                Erdo e = new Erdo(erdeszetiAzon,helyrajziSzam,kor,terulet,fahasznalat,erdogazdalkodo);
                erdok.Add(e);
            }
        }

        public void ErdoTorleseListabol(string erdeszetiAzon)
        {
            Erdo e = erdok.Find(x => x.getErdeszetiAzon()==erdeszetiAzon);
            if (e != null)
                erdok.Remove(e);
            else
                throw new RepositoryExceptionNemTudTorolni("Az erdőt nem lehetett törölni.");
        }

        public void erdoModositasaListaban(string erdeszetiAzon, Erdo modosult)
        {
            Erdo e = erdok.Find(x => x.getErdeszetiAzon() == erdeszetiAzon);
            if (e != null)
                e.modosit(modosult);
            else
                throw new RepositoryExceptionNemTudModositani("Az erdő módosítása nem sikerült");
        }

        public void erdoHozzaadasaListahoz(Erdo ujErdo)
        {
            try
            {
                erdok.Add(ujErdo);
            }
            catch (Exception e)
            {
                throw new RepositoryExceptionNemTudHozzaadni("Az erdő hozzáadása nem sikerült");
            }
        }

        public Erdo getErdo(string erdeszetiAzon)
        {
            return erdok.Find(x => x.getErdeszetiAzon()==erdeszetiAzon);
        }

        
    }
}
