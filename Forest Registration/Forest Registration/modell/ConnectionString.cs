using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Registration.modell
{
    class ConnectionString
    {
        public string getConnectionString()
        {
            return
             "SERVER=\"localhost\";"
             + "DATABASE=\"erdo_adatbazis\";"
             + "UID=\"root\";"
             + "PASSWORD=\"\";"
             + "PORT=\"3306\";";
        }
    }
}
