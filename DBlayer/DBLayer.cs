using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBlayer
{
   public class DBLayer
    {
        public static string Connection;

        public DBLayer()
        {
            Connection = ConfigurationManager.ConnectionStrings["consultDB"].ConnectionString;
        }

    }
}
