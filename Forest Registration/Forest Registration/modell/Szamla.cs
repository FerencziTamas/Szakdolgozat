using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Szamla
    {
        private string szamlaszam;
        private string fafaj; 
        private string vevonev;
        private int nettoar;
        private int bruttoar;
        private int mennyiseg;
        private string felhasznalasModja;
        private int teljesitesNapja;
        private int szamlaKeletkezese;
        private int kifizetesNapja;
        private string lerakodasiHely;
        private string felrakasiHely;
        private string erdogazdalkodo;
        private string muveletiLapSorszam;
        private string szallitojegySorszam;

        public Szamla(string szamlaszam, string fafaj, string vevonev, int nettoar, int bruttoar, int mennyiseg, string felhasznalasModja, int teljesitesNapja, int szamlaKeletkezese, int kifizetesNapja, string lerakodasiHely, string felrakasiHely,string erdogazdalkodo, string muveletiLapSorszam, string szallitojegySorszam)
        {
            this.szamlaszam = szamlaszam;
            this.fafaj = fafaj;
            this.vevonev = vevonev;
            this.nettoar = nettoar;
            this.bruttoar = bruttoar;
            this.mennyiseg = mennyiseg;
            this.felhasznalasModja = felhasznalasModja;
            this.teljesitesNapja = teljesitesNapja;
            this.szamlaKeletkezese = szamlaKeletkezese;
            this.kifizetesNapja = kifizetesNapja;
            this.lerakodasiHely = lerakodasiHely;
            this.felrakasiHely = felrakasiHely;
            this.erdogazdalkodo = erdogazdalkodo;
            this.muveletiLapSorszam = muveletiLapSorszam;
            this.szallitojegySorszam = szallitojegySorszam;
        }

        public void setSzamlaSzam(string szamlaszam)
        {
            this.szamlaszam = szamlaszam;
        }

        public void setVevoNev(string vevonev)
        {
            this.vevonev = vevonev;
        }

        public void setNettoAr(int nettoar)
        {
            this.nettoar = nettoar;
        }

        public void setBruttoAr(int bruttoar)
        {
            this.bruttoar = bruttoar;
        }

        public void setMennyiseg(int mennyiseg)
        {
            this.mennyiseg = mennyiseg;
        }

        public void setFelhasznalasModja(string felhasznalasModja)
        {
            this.felhasznalasModja = felhasznalasModja;
        }
        
        public void setTeljesitesNapja(int teljesitesNapja)
        {
            this.teljesitesNapja = teljesitesNapja;
        }

        public void setSzamlaKeletkezese(int szamlaKeletkezese)
        {
            this.szamlaKeletkezese = szamlaKeletkezese;
        }

        public void setKifizetesNapja(int kifizetesNapja)
        {
            this.kifizetesNapja = kifizetesNapja;
        }

        public void setLerakodasiHely(string lerakodasiHely)
        {
            this.lerakodasiHely = lerakodasiHely;
        }

        public void setFelrakasiHely(string felrakasiHely)
        {
            this.felrakasiHely = felrakasiHely;
        }

        public void setErdogazdalkodoSzamla(string erdogazdalkodo)
        {
            this.erdogazdalkodo = erdogazdalkodo;
        }

        public void setMuveletiLapSorszam(string muveletiLapSorszam)
        {
            this.muveletiLapSorszam = muveletiLapSorszam;
        }

        public void setSzallitojegySorszam(string szallitojegySorszam)
        {
            this.szallitojegySorszam = szallitojegySorszam;
        }

        public string getSzamlaSzam()
        {
            return szamlaszam;
        }

        public string getVevoNev()
        {
            return vevonev;
        }

        public int getNettoAr()
        {
            return nettoar;
        }

        public int getBruttoAr()
        {
            return bruttoar;
        }

        public int getMennyiseg()
        {
            return mennyiseg;
        }

        public string getFelhasznalasModja()
        {
            return felhasznalasModja;
        }

        public int getTeljesitesNapja()
        {
            return teljesitesNapja;
        }

        public int getSzamlaKeletkezese()
        {
            return szamlaKeletkezese;
        }

        public int getKifizetesNapja()
        {
            return kifizetesNapja;
        }

        public string getLerakodasiHely()
        {
            return lerakodasiHely;
        }

        public string getFelrakasiHely()
        {
            return felrakasiHely;
        }

        public string getErdogazdalkodoSzamla()
        {
            return erdogazdalkodo;
        }

        public string getMuveletiLapSorszam()
        {
            return muveletiLapSorszam;
        }

        public string getSzallitojegySorszam()
        {
            return szallitojegySorszam;
        }
    }
}
