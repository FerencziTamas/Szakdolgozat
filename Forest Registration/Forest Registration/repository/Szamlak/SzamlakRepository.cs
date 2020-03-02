using Forest_Registration.modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.repository
{
    partial class Repository
    {
        List<Szamla> szamlak;

        public void setSzamlak(List<Szamla> szamlak)
        {
            this.szamlak = szamlak;
        }

        public List<Szamla> getSzamlak()
        {
            return szamlak;
        }
    }
}
