using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    partial class Erdo
    {
        public string erdoHozzaadas()
        {
            return "INSERT INTO `erdok`(`erdeszeti_azonosito`, `helyrajzi_szam`, `kor`, `terület`, `hasznalatId`, `egKod`) VALUES('"+ erdeszetiAzon + "', '"+getHelyrajziSzam()+"', '"+getKor()+"', '"+getTerulet()+"', '"+getFahasznalat()+"', '"+getErdogazdalkodo()+"');";
        }

        public string erdoModositas()
        {
            return "UPDATE `erdok` SET `helyrajzi_szam`= '"+ getHelyrajziSzam() + "',`kor`= '"+ getKor() + "',`terület`= "+ getTerulet() + " ,`hasznalatId`= '"+ getFahasznalat() + "',`egKod`='"+ getErdogazdalkodo() + "' WHERE erdok.`erdeszeti_azonosito`= " + erdeszetiAzon;
        }

        public string osszesErdo()
        {
            return "SELECT * FROM `erdok`";
        }

        public string TorolErdok()
        {
            return "DELETE FROM `erdok`";
        }
    }
}
