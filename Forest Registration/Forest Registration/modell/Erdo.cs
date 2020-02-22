using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    partial class Erdo
    {
        private string erdeszetiAzon;
        private string helyrajziSzam;
        private int kor;
        private int terulet;
        private string erdogazdalkodo;
        private string fahasznalat;

        public Erdo(string erdeszetiAzon, string helyrajziSzam, int kor, int terulet, string erdogazdalkodo, string fahasznalat)
        {
            this.erdeszetiAzon = erdeszetiAzon;
            this.helyrajziSzam = helyrajziSzam;
            this.kor = kor;
            this.terulet = terulet;
            this.erdogazdalkodo = erdogazdalkodo;
            this.fahasznalat = fahasznalat;
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

        public void setErdogazdalkodo(string erdogazdalkodo)
        {
            this.erdogazdalkodo = erdogazdalkodo;
        }

        public void setFahasznalat(string fahasznalat) 
        {
            this.fahasznalat = fahasznalat;
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

        public string getErdogazdalkodo()
        {
            return erdogazdalkodo;
        }

        public string getFahasznalat()
        {
            return fahasznalat;
        }
    }
}
