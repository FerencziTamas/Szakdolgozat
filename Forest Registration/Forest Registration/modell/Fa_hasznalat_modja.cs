using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    class Fa_hasznalat_modja
    {
        private int hasznalatId;
        private string megnevezes;
        private string rovidites;

        public Fa_hasznalat_modja(int hasznalatId, string megnevezes, string rovidites)
        {
            this.hasznalatId = hasznalatId;
            this.megnevezes = megnevezes;
            this.rovidites = rovidites;
        }

        public void setHasznalatId(int hasznalatId)
        {
            this.hasznalatId = hasznalatId;
        }

        public void setMegnevezes(string megnevezes)
        {
            this.megnevezes = megnevezes;
        }

        public void setRovidites(string rovidites)
        {
            this.rovidites = rovidites;
        }

        public int getHasznalatId()
        {
            return hasznalatId;
        }

        public string getMegnevezes()
        {
            return megnevezes;
        }

        public string getRovidites()
        {
            return rovidites;
        }
    }
}
