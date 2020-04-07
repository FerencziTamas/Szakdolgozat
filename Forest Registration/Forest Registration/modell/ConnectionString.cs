using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    public class ConnectionString
    {
        public string getCreateString()
        {
            //Azért kell hogy ne ütközzön a program hibába az adatbázis készítése során
            return
                "SERVER=\"localhost\";"
                + "DATABASE=\"test\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
        }

        //Adatbázishoz való csatlakozás
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
