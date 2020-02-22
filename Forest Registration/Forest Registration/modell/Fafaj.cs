using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    class Fafaj
    {
        private int fafajId;
        private string megnevezes;

        public Fafaj(int fafajId, string megnevezes)
        {
            this.fafajId = fafajId;
            this.megnevezes = megnevezes;
        }

        public void setFafajId(int fafajId)
        {
            this.fafajId = fafajId;
        }

        public void setMegevezes(string megnevezes)
        {
            this.megnevezes = megnevezes;
        }
    }
}
