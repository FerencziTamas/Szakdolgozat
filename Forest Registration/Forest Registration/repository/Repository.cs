using Forest_Register.modell; //modell osztály meghívva
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    /// <summary>
    /// Ebben az osztályban megy végbe a listák példányosítása
    /// </summary>
    partial class Repository
    {
        public Repository()
        {
            erdok = new List<Erdo>();
            erdogazdalkodok = new List<Erdogazdalkodo>();
            szamlak = new List<Szamla>();
            vevok = new List<Vevo>();
        }


    }
}
