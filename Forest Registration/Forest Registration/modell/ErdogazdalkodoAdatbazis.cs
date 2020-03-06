using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Erdogazdalkodo
    {

        public static string OsszesErdogazdalkodo()
        {
            return "SELECT * FROM `erdok`";
        }

        public static string TorolErdogazdalkodok()
        {
            return "DELETE FROM `erdok`";
        }

        public string ErdogazdalkodoModositas(string kod)
        {
            return "UPDATE `erdogazdalkodok` SET `nev`='" + getErdogazNev() + "',`cim`='" + getErdogazCim() + "' WHERE egKod = " + getKod();
        }

        public string ErdogazdalkodoHozzaadas()
        {
            return "INSERT INTO `erdogazdalkodok`(`egKod`, `nev`, `cim`) VALUES ('"+getKod()+"', '"+getErdogazNev()+"', '"+getErdogazCim()+"');";
        }


    }
}
