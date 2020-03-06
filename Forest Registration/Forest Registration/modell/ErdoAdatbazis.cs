using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Erdo
    {
        public string ErdoHozzaadas()
        {
            return "INSERT INTO `erdok`(`erdeszeti_azonosito`, `helyrajzi_szam`, `kor`, `terület`, `hasznalatId`, `egKod`) VALUES('"+ erdeszetiAzon + "', '"+getHelyrajziSzam()+"', '"+getKor()+"', '"+getTerulet()+"', '"+getFahasznalat()+"', '"+getErdogazdalkodo()+"');";
        }

        public string ErdoModositas(string erdeszetiAzon)
        {
            return "UPDATE `erdok` SET `helyrajzi_szam`= '"+ getHelyrajziSzam() + "',`kor`= '"+ getKor() + "',`terület`= "+ getTerulet() + " ,`hasznalatId`= '"+ getFahasznalat() + "',`egKod`='"+ getErdogazdalkodo() + "' WHERE `erdeszeti_azonosito`= " + erdeszetiAzon;
        }

        public static string OsszesErdo()
        {
            return "SELECT * FROM `erdok`";
        }

        public static string TorolErdok()
        {
            return "DELETE FROM `erdok`";
        }
    }
}
