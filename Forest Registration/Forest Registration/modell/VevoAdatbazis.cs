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

        internal string VevoModositas(string vevoId)
        {
            return "UPDATE `vevok` SET `nev`='"+getVevoNev()+"',`cim`='"+getVevoCim()+"',`technikai_azonosito`='"+getTechnikaiAzonosito()+"',`adoszam`='"+getAdoszam()+"' WHERE `vevoId`="+vevoId;
        }

        internal string VevoHozzaadas()
        {
            return "INSERT INTO `vevok`(`vevoId`, `nev`, `cim`, `technikai_azonosito`, `adoszam`) VALUES ('"+vevoId+"', '"+getVevoNev()+"', '"+getVevoCim()+"', '"+getTechnikaiAzonosito()+"', '"+getAdoszam()+"')";
        }
    }
}
