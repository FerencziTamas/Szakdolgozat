using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    /// <summary>
    /// Vevő osztály
    /// </summary>
    public partial class Vevo
    {
        private int vevoId;
        private string nev;
        private string cim;
        private string technikai_azonosito;
        private int adoszam;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="vevoId"></param>
        /// <param name="vevoNev"></param>
        /// <param name="vevoCim"></param>
        /// <param name="technikai_azonosito"></param>
        /// <param name="adoszam"></param>
        public Vevo(int vevoId, string vevoNev, string vevoCim, string technikai_azonosito, int adoszam)
        {
            this.vevoId = vevoId;
            if (isValid(vevoNev))
            {
                this.nev = vevoNev;
            }
            
            this.cim = vevoCim;
            this.technikai_azonosito = technikai_azonosito;
            this.adoszam = adoszam;
        }

        public bool isValid(string vevoNev)
        {
            if(isValidNagyBetuvelKezdodik(vevoNev))
            {
                throw new HibasVevoNevException("A név nem nagy betűvel kezdődik");
            }
            return true;
        }

        private bool isValidNagyBetuvelKezdodik(string vevoNev)
        {
            if(char.IsUpper(vevoNev.ElementAt(0)))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// vevoId, vevoNev, vevoCim, technikai_azonosito és adoszam adatoknak értékadás
        /// </summary>
        /// <param name="vevoId"></param>
        public void setVevoId(int vevoId)
        {
            this.vevoId = vevoId;
        }

        /// <param name="vevoNev"></param>
        public void setVevoNev(string vevoNev)
        {
            this.nev = vevoNev;
        }

        /// <param name="vevoCim"></param>
        public void setVevoCim(string vevoCim)
        {
            this.cim = vevoCim;
        }

        /// <param name="technikai_azonosito"></param>
        public void setTechnikaiAzonosito(string technikai_azonosito)
        {
            this.technikai_azonosito = technikai_azonosito;
        }

        /// <param name="adoszam"></param>
        public void setAdoszam(int adoszam)
        {
            this.adoszam = adoszam;
        }

        /// <summary>
        /// vevoId, vevoNev, vevoCim, technikaiAzonosito és adoszam adatok lekérdezése
        /// </summary>
        /// <returns>vevoId, vevoNev, vevoCim, technikaiAzonosito, adoszam</returns>
        public int getVevoId()
        {
            return vevoId;
        }

        public string getVevoNev()
        {
            return nev;
        }

        public string getVevoCim()
        {
            return cim;
        }

        public string getTechnikaiAzonosito()
        {
            return technikai_azonosito;
        }

        public int getAdoszam()
        {
            return adoszam;
        }

        public void modosit(Vevo modosult)
        {
            this.nev = modosult.getVevoNev();
            this.cim = modosult.getVevoCim();
            this.technikai_azonosito = modosult.getTechnikaiAzonosito();
            this.adoszam = modosult.getAdoszam();
        }
    }
}
