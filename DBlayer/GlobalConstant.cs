using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DBlayer
{
   public class GlobalConstant
    {
        //public static string Connection { get; }
        //private string _ConnectionString;

        public static string Connection
        {
            get
            { 
                return  ConfigurationManager.ConnectionStrings["consultDB"].ConnectionString;
            }
            
        }
    }
}
