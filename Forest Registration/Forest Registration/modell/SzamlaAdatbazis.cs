using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    partial class Szamla
    {
        public static string SzamlaOsszes()
        {
            return "SELECT * FROM `szamlak` INNER JOIN szamlatetelek ON szamlak.szamlaszam=szamlatetelek.szamlaszam";
        }

        public static string TorolSzamlak()
        {
            return "DELETE FROM `szamlak`" + "DELETE FROM `szamlatetelek`";
        }
    }
}
