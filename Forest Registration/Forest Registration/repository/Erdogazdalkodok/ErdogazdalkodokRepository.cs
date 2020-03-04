using Forest_Register.modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    partial class Repository
    {
        List<Erdogazdalkodo> erdogazdalkodok;

        public void setErdogazdalkodok(List<Erdogazdalkodo> erdogazdalkodok)
        {
            this.erdogazdalkodok = erdogazdalkodok;
        }

        public List<Erdogazdalkodo> getErdogazdalkodok()
        {
            return erdogazdalkodok;
        }

        public List<string> getErdogazdalkodoNev()
        {
            List<string> erdogazdalkodoNev = new List<string>();
            foreach (Erdogazdalkodo erdogazdalkodo in erdogazdalkodok)
            {
                erdogazdalkodoNev.Add(erdogazdalkodo.getErdogazNev());
            }
            return erdogazdalkodoNev;
        }
    }
}
