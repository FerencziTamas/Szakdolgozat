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
        private string teljesitesNapja;
        private string szamlaKeletkezese;
        private string kifizetesNapja;
        private string lerakodasiHely;
        private string felrakasiHely;
        private string erdogazdalkodo;
        private string muveletiLapSorszam;
        private string szallitojegySorszam;

        public Szamla(string szamlaszam, string fafaj, string vevonev, int mennyiseg, string felhasznalasModja, int nettoar, int bruttoar,  string teljesitesNapja, string szamlaKeletkezese, string kifizetesNapja, string lerakodasiHely, string felrakasiHely, string muveletiLapSorszam, string szallitojegySorszam)
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
            this.muveletiLapSorszam = muveletiLapSorszam;
            this.szallitojegySorszam = szallitojegySorszam;
        }

        public void setSzamlaSzam(string szamlaszam)
        {
            this.szamlaszam = szamlaszam;
        }

        public void setFafaj(string fafaj)
        {
            this.fafaj = fafaj;
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
        
        public void setTeljesitesNapja(string teljesitesNapja)
        {
            this.teljesitesNapja = teljesitesNapja;
        }

        public void setSzamlaKeletkezese(string szamlaKeletkezese)
        {
            this.szamlaKeletkezese = szamlaKeletkezese;
        }

        public void setKifizetesNapja(string kifizetesNapja)
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

        public string getFafaj()
        {
            return fafaj;
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

        public string getTeljesitesNapja()
        {
            return teljesitesNapja;
        }

        public string getSzamlaKeletkezese()
        {
            return szamlaKeletkezese;
        }

        public string getKifizetesNapja()
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

        public string getMuveletiLapSorszam()
        {
            return muveletiLapSorszam;
        }

        public string getSzallitojegySorszam()
        {
            return szallitojegySorszam;
        }

        public void modosit(Szamla modosult)
        {
            this.fafaj = modosult.getFafaj();
            this.vevonev = modosult.getVevoNev();
            this.mennyiseg = modosult.getMennyiseg();
            this.felhasznalasModja = modosult.getFelhasznalasModja();
            this.bruttoar = modosult.getBruttoAr();
            this.nettoar = modosult.getNettoAr();
            this.teljesitesNapja = modosult.getTeljesitesNapja();
            this.szamlaKeletkezese = modosult.getSzamlaKeletkezese();
            this.kifizetesNapja = modosult.getKifizetesNapja();
            this.lerakodasiHely = modosult.getLerakodasiHely();
            this.felrakasiHely = modosult.getFelrakasiHely();
            this.muveletiLapSorszam = modosult.getMuveletiLapSorszam();
            this.szallitojegySorszam = modosult.getSzallitojegySorszam();
        }
    }
}
