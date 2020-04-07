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

        /// <summary>
        /// Konstrukto
        /// </summary>
        /// <param name="erdeszetiAzon"></param>
        /// <param name="helyrajziSzam"></param>
        /// <param name="kor"></param>
        /// <param name="terulet"></param>
        /// <param name="fahasznalat"></param>
        /// <param name="erdogazdalkodo"></param>
        public Erdo(string erdeszetiAzon, string helyrajziSzam, int kor, int terulet, int fahasznalat, string erdogazdalkodo)
        {
            this.erdeszetiAzon = erdeszetiAzon;
            this.helyrajziSzam = helyrajziSzam;
            this.kor = kor;
            this.terulet = terulet;
            this.fahasznalat = fahasznalat;
            this.erdogazdalkodo = erdogazdalkodo;
        }

        //erdeszetiAzon értékét adja meg
        public void setErdeszetiAzon(string erdeszetiAzon)
        {
            this.erdeszetiAzon = erdeszetiAzon;
        }

        //helyrajziSzam értékét adja meg
        public void setHelyrajziSzam(string helyrajziSzam)
        {
            this.helyrajziSzam = helyrajziSzam;
        }

        //kor értékét adja meg
        public void setKor(int kor)
        {
            this.kor = kor;
        }

        //terulet értékét adja meg
        public void setTerulet(int terulet)
        {
            this.terulet = terulet;
        }

        //fahasznalat értékét adja meg
        public void setFahasznalat(int fahasznalat) 
        {
            this.fahasznalat = fahasznalat;
        }

        //erdeszetiAzon értékét adja meg
        public void setErdogazdalkodo(string erdogazdalkodo)
        {
            this.erdogazdalkodo = erdogazdalkodo;
        }

        //visszaadja az erdészeti azonosítót
        public string getErdeszetiAzon()
        {
            return erdeszetiAzon;
        }

        //Visszaadja a helyrajzi számot
        public string getHelyrajziSzam()
        {
            return helyrajziSzam;
        }

        //Visszaadja a kort
        public int getKor()
        {
            return kor;
        }

        //Visszaadja a területet
        public int getTerulet()
        {
            return terulet;
        }

        //Visszaadja a fahasználatot
        public int getFahasznalat()
        {
            return fahasznalat;
        }

        //Visszaadja az erdogazdálkodót
        public string getErdogazdalkodo()
        {
            return erdogazdalkodo;
        }

        /// <summary>
        /// A módosításért felelős metódus
        /// </summary>
        /// <param name="modified"></param>
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
