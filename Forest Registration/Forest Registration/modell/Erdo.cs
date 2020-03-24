using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Erdo
    {
        private string erdeszetiAzon;
        private string helyrajziSzam;
        private int kor;
        private int terulet;
        private int fahasznalat;
        private string erdogazdalkodo;


        public Erdo(string erdeszetiAzon, string helyrajziSzam, int kor, int terulet, int fahasznalat, string erdogazdalkodo)
        {
            this.erdeszetiAzon = erdeszetiAzon;
            this.helyrajziSzam = helyrajziSzam;
            this.kor = kor;
            this.terulet = terulet;
            this.fahasznalat = fahasznalat;
            this.erdogazdalkodo = erdogazdalkodo;
        }

        
        public void setErdeszetiAzon(string erdeszetiAzon)
        {
            this.erdeszetiAzon = erdeszetiAzon;
        }

        public void setHelyrajziSzam(string helyrajziSzam)
        {
            this.helyrajziSzam = helyrajziSzam;
        }

        public void setKor(int kor)
        {
            this.kor = kor;
        }

        public void setTerulet(int terulet)
        {
            this.terulet = terulet;
        }
        public void setFahasznalat(int fahasznalat) 
        {
            this.fahasznalat = fahasznalat;
        }

        public void setErdogazdalkodo(string erdogazdalkodo)
        {
            this.erdogazdalkodo = erdogazdalkodo;
        }

        public string getErdeszetiAzon()
        {
            return erdeszetiAzon;
        }

        public string getHelyrajziSzam()
        {
            return helyrajziSzam;
        }

        public int getKor()
        {
            return kor;
        }

        public int getTerulet()
        {
            return terulet;
        }
        public int getFahasznalat()
        {
            return fahasznalat;
        }

        public string getErdogazdalkodo()
        {
            return erdogazdalkodo;
        }

        public void modosit(Erdo modified)
        {
            this.helyrajziSzam = modified.getHelyrajziSzam();
            this.kor = modified.getKor();
            this.terulet = modified.getTerulet();
            this.fahasznalat = modified.getFahasznalat();
            this.erdogazdalkodo = modified.getErdogazdalkodo();
        }
    }
}
