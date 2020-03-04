using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Erdogazdalkodo
    {

        public static string osszesErdogazdalkodo()
        {
            return "SELECT * FROM `erdok`";
        }

        public static string torolErdogazdalkodok()
        {
            return "DELETE FROM `erdok`";
        }
    }
}
