using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    class Fa_hasznalat_modja
    {
        private int hasznalatId;
        private string megnevezes;

        public Fa_hasznalat_modja(int hasznalatId, string megnevezes)
        {
            this.hasznalatId = hasznalatId;
            this.megnevezes = megnevezes;
        }

        public void setHasznalatId(int hasznalatId)
        {
            this.hasznalatId = hasznalatId;
        }

        public void setMegnevezes(string megnevezes)
        {
            this.megnevezes = megnevezes;
        }

        public int getHasznalatId()
        {
            return hasznalatId;
        }

        public string getMegnevezes()
        {
            return megnevezes;
        }
    }
}
