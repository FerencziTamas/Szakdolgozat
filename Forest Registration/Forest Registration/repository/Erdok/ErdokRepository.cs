using Forest_Registration.modell; //modell osztály meghívva
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.repository
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
            erdoDt.Columns.Add("terület", typeof(int));
            erdoDt.Columns.Add("hasznalatId", typeof(int));
            erdoDt.Columns.Add("egKod", typeof(string));
            foreach (Erdo e in erdok)
            {
                erdoDt.Rows.Add(e.getErdeszetiAzon(), e.getHelyrajziSzam(), e.getKor(), e.getTerulet(), e.getFahasznalat(), e.getErdogazdalkodo());
            }
            return erdoDt;
        }
    }
}
