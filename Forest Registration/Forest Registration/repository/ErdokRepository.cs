using Forest_Registration.modell; //modell osztály meghívva
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.repository
{
    partial class Repository
    {
        List<Erdo> erdok;

        public void setErdok(List<Erdo> erdok)
        {
            this.erdok = erdok;
        }

        public List<Erdo> getErdok()
        {
            return erdok;
        }

        
    }
}
