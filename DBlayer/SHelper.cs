using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayer
{
    public class SHelper : IStudent
    {
        private SqlConnection _cn;
        public SqlConnection con
        {
            get
            {
                if (_cn == null)
                {
                    _cn = new SqlConnection(GlobalConstant.Connection);
                }
                return _cn;
            }
        }
        public void Insert()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Gender");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter City");
            string city = Console.ReadLine();

            Console.WriteLine("Enter Roll number");
            int Rollno = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Mobile number");
            string mobile = Console.ReadLine();

            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();

            //Connection string
            //string Connection = "Data Source=.\\SQLExpress;Initial Catalog=consult_DB;Integrated Security=True";
            //SqlConnection con = new SqlConnection(GlobalConstant.Connection);
            con.Open();

            string command_stringb = "INSERT INTO Student (RollNo, Name, Gender, City, Mobile, Email) VALUES (" + Rollno + ", '" + name + "', '" + gender + "', '" + city + "', '" + mobile + "', '" + email + "')";
            SqlCommand command = new SqlCommand(command_stringb, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public void Select()
        {
            //string Connection = ConfigurationManager.ConnectionStrings["consultDB"].ConnectionString;
            //SqlConnection con = new SqlConnection(GlobalConstant.Connection);
            if (con != null)
            {
                con.Close();
            }
            con.Open();
            string command = "SELECT * FROM Student";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string gender = reader["Gender"].ToString();
                Console.WriteLine($"Name : {name}, Gender: {gender}");
            }
            con.Close();
        }
    }
}
