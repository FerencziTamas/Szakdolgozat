using Forest_Register.modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.repository
{
    partial class VevokRepositoryAdatbazisTabla
    {
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public VevokRepositoryAdatbazisTabla()
        {
            ConnectionString cs = new ConnectionString();
            connectionString = cs.getConnectionString();
        }

        internal void VevoAdatbazisbaIllesztese(Vevo ujVevo)
        {
            throw new NotImplementedException();
        }
    }
}
