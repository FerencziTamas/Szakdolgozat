using Forest_Register.modell; //modell osztály meghívva
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    /// <summary>
    /// Ebben az osztályban megy végbe a listák példányosítása
    /// </summary>
    partial class Repository
    {
        List<Fafaj> fafajok;
        List<Fa_hasznalat_modja> faHaszModjai;

        public Repository()
        {
            erdok = new List<Erdo>();
            erdogazdalkodok = new List<Erdogazdalkodo>();
            szamlak = new List<Szamla>();
            vevok = new List<Vevo>();
            fafajok = new List<Fafaj>();
            faHaszModjai = new List<Fa_hasznalat_modja>();

        }

        public void setFafajok(List<Fafaj> fafajok)
        {
            this.fafajok = fafajok;
        }

        public void setFaHaszModjai(List<Fa_hasznalat_modja> faHaszModjai)
        {
            this.faHaszModjai = faHaszModjai;
        }

        public List<string> getFafajokMegnevezes()
        {
            List<string> fafajMegnevezes = new List<string>();
            foreach (Fafaj f in fafajok)
            {
                fafajMegnevezes.Add(f.getMegnevezes());
            }
            return fafajMegnevezes;
        }

        public List<string> getFahaszModRoviditesek()
        {
            List<string> fahaszmodRoviditesek = new List<string>();
            foreach (Fa_hasznalat_modja fhsz in faHaszModjai)
            {
                fahaszmodRoviditesek.Add(fhsz.getRovidites());
            }
            return fahaszmodRoviditesek;
        }
    }
}
