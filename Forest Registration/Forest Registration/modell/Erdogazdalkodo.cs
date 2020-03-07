using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    /// <summary>
    /// Erdőgazdálkodók osztály
    /// </summary>
    partial class Erdogazdalkodo
    {
        private string kod;
        private string erdogazNev;
        private string erdogazCim;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="kod"></param>
        /// <param name="erdogazNev"></param>
        /// <param name="erdogazCim"></param>
        public Erdogazdalkodo(string kod, string erdogazNev, string erdogazCim)
        {
            this.kod = kod;
            this.erdogazNev = erdogazNev;
            this.erdogazCim = erdogazCim;
        }

        public bool nevEllenorzes(string erdogazNev)
        {
            if (erdogazNev == string.Empty)
            {
                return false;
            }

            if (!char.IsUpper(erdogazNev.ElementAt(0)))
            {
                return false;
            }

            for (int i = 1; i < erdogazNev.Length; i++)
            {
                if ((!char.IsLetter(erdogazNev.ElementAt(i))) && (!char.IsWhiteSpace(erdogazNev.ElementAt(i))))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// kod, nev, cim adatoknak értékadás
        /// </summary>
        /// <param name="kod"></param>
        public void setKod(string kod)
        {
            this.kod = kod;
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
            return kod;
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
            this.kod = modify.getKod();
            this.erdogazNev = modify.getErdogazNev();
            this.erdogazCim = modify.getErdogazCim();
        }
    }
}
