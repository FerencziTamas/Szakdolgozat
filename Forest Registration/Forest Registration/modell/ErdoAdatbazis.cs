using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Erdo
    {
        //Az erdő hozzáadása sql utasítása
        public string ErdoHozzaadas()
        {
            return "INSERT INTO `erdok`(`erdeszeti_azonosito`, `helyrajzi_szam`, `kor`, `terulet`, `hasznalatId`, `egKod`) VALUES('\"" + erdeszetiAzon + "\"', '" + getHelyrajziSzam()+"', '"+getKor()+"', '"+getTerulet()+"', '"+getFahasznalat()+"', '"+getErdogazdalkodo()+"');";
        }

        //Az erdő módosítása sql utasítása
        public string ErdoModositas(string erdeszetiAzon)
        {
            return "UPDATE `erdok` SET `helyrajzi_szam`= '"+ getHelyrajziSzam() + "',`kor`= '"+ getKor() + "',`terulet`= "+ getTerulet() + " ,`hasznalatId`= '"+ getFahasznalat() + "',`egKod`='"+ getErdogazdalkodo() + "' WHERE `erdeszeti_azonosito`= \"" + erdeszetiAzon+ "\"";
        }

        //Az erdők kiíratása sql utasítása
        public static string OsszesErdo()
        {
            return "SELECT * FROM `erdok`";
        }

        //Az erdő törlése sql utasítása
        public static string TorolErdok()
        {
            return "DELETE FROM `erdok`";
        }
    }
}
