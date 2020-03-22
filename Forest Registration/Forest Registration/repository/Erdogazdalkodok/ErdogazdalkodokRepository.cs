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
        List<Erdogazdalkodo> erdogazdalkodok;

        public void setErdogazdalkodok(List<Erdogazdalkodo> erdogazdalkodok)
        {
            this.erdogazdalkodok = erdogazdalkodok;
        }

        public List<Erdogazdalkodo> getErdogazdalkodok()
        {
            return erdogazdalkodok;
        }

        public DataTable ErdogazdalkodoAdatokListabol()
        {
            DataTable erdogazdalkodoDt = new DataTable();
            erdogazdalkodoDt.Columns.Add("egKod", typeof(string));
            erdogazdalkodoDt.Columns.Add("erdogazNev", typeof(string));
            erdogazdalkodoDt.Columns.Add("erdogazCim", typeof(string));
            foreach (Erdogazdalkodo eg in erdogazdalkodok)
            {
                erdogazdalkodoDt.Rows.Add(eg.getKod(), eg.getErdogazNev(), eg.getErdogazCim());
            }
            return erdogazdalkodoDt;
        }

        public List<string> getErdogazdalkodoNev()
        {
            List<string> erdogazdalkodoNev = new List<string>();
            foreach (Erdogazdalkodo erdogazdalkodo in erdogazdalkodok)
            {
                erdogazdalkodoNev.Add(erdogazdalkodo.getErdogazNev());
            }
            return erdogazdalkodoNev;
        }

        public void erdogazdalkodoHozzadasaListahoz(Erdogazdalkodo ujErdogazdalkodo)
        {
            try
            {
                erdogazdalkodok.Add(ujErdogazdalkodo);
            }
            catch (Exception ex)
            {
                throw new RepositoryExceptionNemTudHozzaadni("Az erdőgazdálkodó hozzáadása nem sikerült");
            }
        }

        public void erdogazdakodoTorleseListabol(string kod)
        {
            Erdogazdalkodo eg = erdogazdalkodok.Find(x => x.getKod() == kod);
            if (eg != null)
                erdogazdalkodok.Remove(eg);
            else
                throw new RepositoryExceptionNemTudTorolni("Az erdőgazdalkodót nem lehet törölni!");
        }

        internal void erdogazdalkodoModositasaListaban(string kod, Erdogazdalkodo modosult)
        {
            Erdogazdalkodo eg = erdogazdalkodok.Find(x => x.getKod() == kod);
            if (eg != null)
                eg.modosit(modosult);
            else
                throw new RepositoryExceptionNemTudModositani("Az erdőgazdálkodó módosítása nem sikerült");
        }
    }
}
