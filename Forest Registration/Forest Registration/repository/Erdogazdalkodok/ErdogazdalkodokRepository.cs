using Forest_Registration.modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.repository
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
    }
}
