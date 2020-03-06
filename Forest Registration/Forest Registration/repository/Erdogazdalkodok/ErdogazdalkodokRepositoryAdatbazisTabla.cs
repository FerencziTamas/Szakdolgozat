using Forest_Register.modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    partial class ErdogazdalkodokRepositoryAdatbazisTabla
    {
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public ErdogazdalkodokRepositoryAdatbazisTabla()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }
    }
}
