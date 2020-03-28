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
            return "SELECT * FROM erdogazdalkodok";
        }

        public static string TorolErdogazdalkodok()
        {
            return "DELETE FROM `erdogazdalkodok`";
        }

        public string ErdogazdalkodoModositas(string kod)
        {
            return "UPDATE `erdogazdalkodok` SET `erdogazNev`='" + getErdogazNev() + "', `erdogazCim`='" + getErdogazCim() + "' WHERE `erdogazdalkodok`.`egKod` = \"" + kod+ "\"";
        }

        public string ErdogazdalkodoHozzaadas()
        {
            return "INSERT INTO `erdogazdalkodok`(`egKod`, `nev`, `cim`) VALUES ('\"" + egKod+ "\"', '" + getErdogazNev()+"', '"+getErdogazCim()+"');";
        }


    }
}
