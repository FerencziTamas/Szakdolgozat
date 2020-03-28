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

        public string SzamlaModositasEgy(string szamlaszam)
        {
            return "UPDATE `szamlak` SET `vevoId`= '"+getVevoNev()+"',`teljesites_napja`='"+getTeljesitesNapja()+"',`szamla_keletkezes`='"+getSzamlaKeletkezese()+"',`kifizetes_napja`='"+getKifizetesNapja()+"',`lerakodasi_hely`='"+getLerakodasiHely()+"',`felrakasi_hely`='"+getFelrakasiHely()+"',`muveleti_lap_sorszam`='"+getMuveletiLapSorszam()+"',`szallitojegy_sorszam`='"+getSzallitojegySorszam()+ "' WHERE `szamlaszam`= \"" + szamlaszam+ "\"";
        }

        public string SzamlaModositasKetto(string szamlaszam)
        {
            return "UPDATE `szamlatetelek` SET `fafajId`='"+getFafaj()+"',`mennyiseg`='"+getMennyiseg()+"',`felhasznalas_modja`='"+getFelhasznalasModja()+"',`brutto_ar`='"+getBruttoAr()+"',`netto_ar`='"+getNettoAr()+ "' WHERE `szamlaszam`= \"" + szamlaszam+ "\"";
        }

        public string SzamlaHozzaadasEgy()
        {
            return "INSERT INTO `szamlak`(`szamlaszam`, `vevoId`, `teljesites_napja`, `szamla_keletkezes`, `kifizetes_napja`, `lerakodasi_hely`, `felrakasi_hely`, `muveleti_lap_sorszam`, `szallitojegy_sorszam`) VALUES ('" + szamlaszam + "', '" + getVevoNev() + "', '" + getTeljesitesNapja() + "', '" + getSzamlaKeletkezese() + "', '" + getKifizetesNapja() + "', '" + getLerakodasiHely() + "', '" + getFelrakasiHely() + "', '" + getMuveletiLapSorszam() + "', '" + getSzallitojegySorszam() + "')";
        }

        public string SzamlaHozzaadasKetto()
        {
            return "INSERT INTO `szamlatetelek`(`fafajId`, `szamlaszam`, `mennyiseg`, `felhasznalas_modja`, `brutto_ar`, `netto_ar`) VALUES ('" + getFafaj() + "', '\"" + szamlaszam + "\"', '" + getMennyiseg() + "', '" + getFelhasznalasModja() + "', '" + getBruttoAr() + "', '" + getNettoAr() + "')";
        }


    }
}
