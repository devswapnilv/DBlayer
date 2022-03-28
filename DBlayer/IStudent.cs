using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayer
{
   public interface IStudent
    {
        SqlConnection con { get; }
        void Insert();
        void Select();
    }
}
