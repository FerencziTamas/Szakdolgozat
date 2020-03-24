using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    /// <summary>
    /// Erdőgazdálkodó osztály
    /// </summary>
    partial class Erdogazdalkodo
    {
        private string egKod;
        private string erdogazNev;
        private string erdogazCim;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="egKod"></param>
        /// <param name="erdogazNev"></param>
        /// <param name="erdogazCim"></param>
        public Erdogazdalkodo(string egKod, string erdogazNev, string erdogazCim)
        {
            this.egKod = egKod;
            this.erdogazNev = erdogazNev;
            this.erdogazCim = erdogazCim;
        }

        //Ellenőrzi a nevet hogy helyes-e
       

        /// <summary>
        /// kod, nev, cim adatoknak értékadás
        /// </summary>
        /// <param name="egKod"></param>
        public void setKod(string egKod)
        {
            this.egKod = egKod;
        }

        /// <param name="erdogazNev"></param>
        public void setErdogazNev(string erdogazNev)
        {
            this.erdogazNev = erdogazNev;
        }

        /// <param name="erdogazCim"></param>
        public void setErdogazCim(string erdogazCim)
        {
            this.erdogazCim = erdogazCim;
        }

        /// <summary>
        /// kod, nev, cim adatok lekérdezése
        /// </summary>
        /// <returns>kod, nev, cim</returns>
        public string getKod()
        {
            return egKod;
        }

        public string getErdogazNev()
        {
            return erdogazNev;
        }

        public string getErdogazCim()
        {
            return erdogazCim;
        }

        public void modosit(Erdogazdalkodo modify)
        {
            this.egKod = modify.getKod();
            this.erdogazNev = modify.getErdogazNev();
            this.erdogazCim = modify.getErdogazCim();
        }
    }
}
