using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductXpert.Classes
{
    internal class Database
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=ProductXpert;Integrated Security=True");
        public Database()
        {
        }

        public void Execute(string s)
        {
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }



        public bool CheckUser(string username, string password)
        {
            Employee first = new Employee(username, password);

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=ProductXpert;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Pracownicy where login = @username and haslo = @password;", con);

            cmd.Parameters.AddWithValue("@username", first.Username);
            cmd.Parameters.AddWithValue("@password", first.PasswordHash);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
