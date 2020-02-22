using Forest_Registration.modell; //modell osztály meghívva
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.repository
{
    /// <summary>
    /// Külön osztály az listák példányosításához
    /// </summary>
    partial class Repository
    {
        public Repository()
        {
            erdok = new List<Erdo>();
            erdogazdalkodok = new List<Erdogazdalkodo>();
        }
    }
}
