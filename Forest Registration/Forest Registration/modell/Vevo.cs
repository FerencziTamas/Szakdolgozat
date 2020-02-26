using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    class Vevo
    {
        private int vevoId;
        private string nev;
        private string cim;
        private string technikaiAzonosito;
        private int adoszam;

        public Vevo(int vevoId, string nev, string cim, string technikaiAzonosito, int adoszam)
        {
            this.vevoId = vevoId;
            this.nev = nev;
            this.cim = cim;
            this.technikaiAzonosito = technikaiAzonosito;
            this.adoszam = adoszam;
        }

        public void setVevoId(int vevoId)
        {
            this.vevoId = vevoId;
        }

        public void setNev(string nev)
        {
            this.nev = nev;
        }

        public void setCim(string cim)
        {
            this.cim = cim;
        }

        public void setTechnikaiAzonosito(string technikaiAzonosito)
        {
            this.technikaiAzonosito = technikaiAzonosito;
        }

        public void setAdoszam(int adoszam)
        {
            this.adoszam = adoszam;
        }

        public int getVevoId()
        {
            return vevoId;
        }

        public string getNev()
        {
            return nev;
        }

        public string getCim()
        {
            return cim;
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
