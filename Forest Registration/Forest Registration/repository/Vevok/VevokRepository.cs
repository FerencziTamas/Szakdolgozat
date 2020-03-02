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
        List<Vevo> vevok;

        public void setVevok(List<Vevo> vevok)
        {
            this.vevok = vevok;
        }

        public List<Vevo> getVevok()
        {
            return vevok;
        }

        public List<string> getVevokNev()
        {
            List<string> vevokNev = new List<string>();
            foreach (Vevo vevo in vevok)
            {
                vevokNev.Add(vevo.getVevoNev());
            }
            return vevokNev;
        }
    }
}
