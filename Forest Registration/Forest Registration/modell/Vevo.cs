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
    class Vevo
    {
        private int vevoId;
        private string vevoNev;
        private string vevoCim;
        private string technikaiAzonosito;
        private int adoszam;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="vevoId"></param>
        /// <param name="vevoNev"></param>
        /// <param name="vevoCim"></param>
        /// <param name="technikaiAzonosito"></param>
        /// <param name="adoszam"></param>
        public Vevo(int vevoId, string vevoNev, string vevoCim, string technikaiAzonosito, int adoszam)
        {
            this.vevoId = vevoId;
            this.vevoNev = vevoNev;
            this.vevoCim = vevoCim;
            this.technikaiAzonosito = technikaiAzonosito;
            this.adoszam = adoszam;
        }

        /// <summary>
        /// vevoId, vevoNev, vevoCim, technikaiAzonosito és adoszam adatoknak értékadás
        /// </summary>
        /// <param name="vevoId"></param>
        public void setVevoId(int vevoId)
        {
            this.vevoId = vevoId;
        }

        /// <param name="vevoNev"></param>
        public void setVevoNev(string vevoNev)
        {
            this.vevoNev = vevoNev;
        }

        /// <param name="vevoCim"></param>
        public void setVevoCim(string vevoCim)
        {
            this.vevoCim = vevoCim;
        }

        /// <param name="technikaiAzonosito"></param>
        public void setTechnikaiAzonosito(string technikaiAzonosito)
        {
            this.technikaiAzonosito = technikaiAzonosito;
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
            return vevoNev;
        }

        public string getVevoCim()
        {
            return vevoCim;
        }

        public string getTechnikaiAzonosito()
        {
            return technikaiAzonosito;
        }

        public int getAdoszam()
        {
            return adoszam;
        }
    }
}
