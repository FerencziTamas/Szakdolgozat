using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    /// <summary>
    /// Erdőgazdálkodók osztály
    /// </summary>
    class Erdogazdalkodo
    {
        private string kod;
        private string nev;
        private string cim;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="kod"></param>
        /// <param name="nev"></param>
        /// <param name="cim"></param>
        public Erdogazdalkodo(string kod, string nev, string cim)
        {
            this.kod = kod;
            this.nev = nev;
            this.cim = cim;
        }

        /// <summary>
        /// kod, nev, cim adatoknak értékadás
        /// </summary>
        /// <param name="kod"></param>
        /// <param name="nev"></param>
        /// <param name="cim"></param>
        public void setKod(string kod)
        {
            this.kod = kod;
        }

        public void setNev(string nev)
        {
            this.nev = nev;
        }

        public void setCim(string cim)
        {
            this.cim = cim;
        }

        /// <summary>
        /// kod, nev, cim adatok lekérdezése
        /// </summary>
        /// <returns>kod, nev, cim</returns>
        public string getKod()
        {
            return kod;
        }

        public string getNev()
        {
            return nev;
        }

        public string getCim()
        {
            return cim;
        }
    }
}
