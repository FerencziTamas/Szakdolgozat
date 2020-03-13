using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Vevo
    {
        public static string OsszesVevo()
        {
            return "SELECT * FROM `vevok`";
        }

        public static string TorolVevok()
        {
            return "DELETE FROM `vevok`";
        }
    }
}
