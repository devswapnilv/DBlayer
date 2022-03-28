using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBlayer
{
   public class SHelperB : IStudent
    {
        //SqlConnection IStudent.con;
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

        void IStudent.Insert()
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

            //string command_stringb = "INSERT INTO Student (RollNo, Name, Gender, City, Mobile, Email) VALUES (" + Rollno + ", '" + name + "', '" + gender + "', '" + city + "', '" + mobile + "', '" + email + "')";
            //SqlCommand command = new SqlCommand(command_stringb, con);
            SqlCommand command = new SqlCommand("", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@roll_no", Rollno); 
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@Mobile", mobile);
            command.Parameters.AddWithValue("@Email", email);

/*            SqlParameter rn = new SqlParameter() { 
            ParameterName = "@roll_no",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Output
            };*/
            command.ExecuteNonQuery();

            con.Close();
        }

        void IStudent.Select()
        {
            //string Connection = ConfigurationManager.ConnectionStrings["consultDB"].ConnectionString;
            //SqlConnection con = new SqlConnection(GlobalConstant.Connection);
            if (con != null)
            {
                con.Close();
            }
            con.Open();
            string command = "SELECT * FROM Student";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            //SqlCommand cmd = new SqlCommand(command, con);
            //SqlDataReader reader = cmd.ExecuteReader();
            //int row = ds.
            var rowcount = ds.Tables[0].Rows.Count;
            for(int i = 0; i < rowcount; i++)
            {
                var row = ds.Tables[0].Rows[i];
                Console.WriteLine($"Name : {row["Name"].ToString()}");
            }
            con.Close();
        }
    }
}
