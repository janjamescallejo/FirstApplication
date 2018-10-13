using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Database
    {
        string connectionString;
        SqlConnection con;
        public Database()
        {
            connectionString = @"Data Source=DESKTOP-VT3S0F4;Initial Catalog=test;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
        }
        public UserAccount ReadDatabase(string userName)
        {
            UserAccount ac;
            SqlCommand com;
            SqlDataReader read;
            string sql = "select * from useraccounts where uName = '"+userName+"'";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while(read.Read())
            {
                int id = Convert.ToInt32(read.GetValue(0));
                string name = Convert.ToString(read.GetValue(1));
                string pass = Convert.ToString(read.GetValue(2));
                ac = new UserAccount(id, name, pass);
                return ac;
            }
            return null;

        }
        public string writeDatabase(UserAccount ac)
        {
            string message;
            SqlCommand com;
            string sql = "insert into useraccounts values ("+ac.id+",'"+ac.uName+"','"+ac.pWord+"')";
            try
            {
                com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();
                message = "registration success";
            }
            catch(Exception e)
            {
                message = "registration problem";
            }
            return message;
        }
        public void CloseDatabase()
        {
            con.Close();
        }
       
    }
}