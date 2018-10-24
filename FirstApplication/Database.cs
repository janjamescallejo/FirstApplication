using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
        public string readpic()
        {
            string ms;
            SqlCommand com;
            string sql = "select * from imagetable where imageID = 201803";
            com = new SqlCommand(sql,con);
            SqlDataReader read = com.ExecuteReader();
            if(read.Read())
            {
                byte[] pixar = (byte[])read["pic"];
                ms = Convert.ToBase64String(pixar, 0, pixar.Length);
                return ms;
            }
            return null;
            
        }
        public Product readProduct()
        {
            Product p;
               int ProductID;
          string ProductPic;
            string ProductName;
          string ProductDescription;
          string ProductCategoryA;
          string ProductCategoryB;
          string ProductCategoryC;
          double ProductPrice;
          int ProductQuantity;
        SqlCommand com;
            string sql = "select * from products";
            com = new SqlCommand(sql, con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                //byte[] pixar = (byte[])read["productPic"];
                byte[] pixar = (byte[])read.GetValue(1);
                ProductPic = Convert.ToBase64String(pixar, 0, pixar.Length);
                ProductID = Convert.ToInt32(read.GetValue(0));
                ProductName = Convert.ToString(read.GetValue(2));
                ProductDescription = Convert.ToString(read.GetValue(3));
                ProductCategoryA = Convert.ToString(read.GetValue(4));
                ProductCategoryB = Convert.ToString(read.GetValue(5));
                ProductCategoryC = Convert.ToString(read.GetValue(6));
                ProductPrice = Convert.ToDouble(read.GetValue(7));
                ProductQuantity = Convert.ToInt32(read.GetValue(8));
                p = new FirstApplication.Product(ProductID, ProductPic, ProductName, ProductDescription, ProductCategoryA, ProductCategoryB, ProductCategoryC, ProductPrice, ProductQuantity);
                return p;
            }
            return null; 
        }
        public void CloseDatabase()
        {
            con.Close();
        }
       
    }
}