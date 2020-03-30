using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    partial class Szamla
    {
        public static string TorolSzamlak()
        {
            return "DELETE FROM `szamlak`";
        }

        public static string TorolSzamlaTetelek()
        {
            return "DELETE FROM `szamlatetelek`";
        }

        public static string OsszesSzamla()
        {
            return "SELECT * FROM `szamlak` INNER JOIN szamlatetelek ON szamlak.szamlaszam=szamlatetelek.szamlaszam";
        }

        public string SzamlaModositas(string szamlaszam)
        {
            return "UPDATE `szamlak` SET `vevoId`= " + getVevoID() + ",`teljesites_napja`= '" + getTeljesitesNapja() + "',`szamla_keletkezes`= '" + getSzamlaKeletkezese() + "',`kifizetes_napja`= '" + getKifizetesNapja() + "',`lerakodasi_hely`= '" + getLerakodasiHely() + "',`felrakasi_hely`= '" + getFelrakasiHely() + "',`muveleti_lap_sorszam`= '" + getMuveletiLapSorszam() + "',`szallitojegy_sorszam`= '" + getSzallitojegySorszam() + "' WHERE `szamlaszam`= \"" + szamlaszam + "\";" +
                "UPDATE `szamlatetelek` SET `fafajId`= " + getFafaj() + ",`mennyiseg`= " + getMennyiseg() + ",`felhasznalas_modja`= '" + getFelhasznalasModja() + "',`brutto_ar`=" + getBruttoAr() + ",`netto_ar`=" + getNettoAr() + " WHERE `szamlaszam`= \"" + szamlaszam + "\"";
        }

        public string SzamlaHozzaadas()
        {
            return "INSERT INTO `szamlak`(`szamlaszam`, `vevoId`, `teljesites_napja`, `szamla_keletkezes`, `kifizetes_napja`, `lerakodasi_hely`, `felrakasi_hely`, `muveleti_lap_sorszam`, `szallitojegy_sorszam`) VALUES (\"" + szamlaszam + "\", " + getVevoID() + ", \"" + getTeljesitesNapja() + "\", \"" + getSzamlaKeletkezese() + "\", \"" + getKifizetesNapja() + "\", \"" + getLerakodasiHely() + "\", \"" + getFelrakasiHely() + "\", \"" + getMuveletiLapSorszam() + "\", \"" + getSzallitojegySorszam() + "\")" +
                "INSERT INTO `szamlatetelek`(`fafajId`, `szamlaszam`, `mennyiseg`, `felhasznalas_modja`, `brutto_ar`, `netto_ar`) VALUES (" + getFafaj() + ", '\"" + szamlaszam + "\"', " + getMennyiseg() + ", \"" + getFelhasznalasModja() + "\", " + getBruttoAr() + ", " + getNettoAr() + ")";
        }
    }
}
