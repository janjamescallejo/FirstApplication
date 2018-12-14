using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;

namespace FirstApplication
{
    public class Database
    {
        string connectionString;
        SqlConnection con;
        SqlDataReader read;
        SqlCommand com;
        private void OpenDatabase()
        {
            connectionString = @"Data Source=DESKTOP-VT3S0F4;Initial Catalog=test;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
        }
        public UserAccount ReadDatabase(string userName)
        {
            OpenDatabase();
            UserAccount ac=null;
            SqlCommand com;
           
            string sql = "select * from useraccounts where uName = '"+userName+"'";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while(read.Read())
            {
                int id = Convert.ToInt32(read.GetValue(0));
                string name = Convert.ToString(read.GetValue(1));
                string pass = Convert.ToString(read.GetValue(2));
                ac = new UserAccount(id, name, pass);
                if(ac!=null)
                {
                    break;
                }
            }
            CloseDatabase();
            return ac;

        }
        public string writeDatabase(UserAccount ac)
        {
            OpenDatabase();
            string message;
           
            string sql = "insert into useraccounts values ("+ac.Id+",'"+ac.UName+"','"+ac.PWord+"')";
            try
            {
                com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();
                message = "Registration is Successful.";
            }
            catch(Exception)
            {
                
                message = "Registration has failed";
            }
            CloseDatabase();
            return message;
        }
       
        public List<string> readpics()
        {
            OpenDatabase();
            var pictures = new List<string>();
            string ms;
            
            string sql = "select * from imagetable";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while (read.Read())
            {
                byte[] pixar = (byte[])read.GetValue(1);
                ms = Convert.ToBase64String(pixar, 0, pixar.Length);
                pictures.Add(ms);
            }
            CloseDatabase();
            return pictures;

        }
        public List<Product> readProduct()
        {
            OpenDatabase();
            var products = new List<Product>();
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
            int userID;
        
            string sql = "select * from products";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
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
                userID = Convert.ToInt32(read.GetValue(9));
                p = new FirstApplication.Product(ProductID, ProductPic, ProductName, ProductDescription, ProductCategoryA, ProductCategoryB, ProductCategoryC, ProductPrice, ProductQuantity,userID);
                products.Add(p);
            }
            CloseDatabase();
            return products; 
        }
        public List<Documents> readDocs()
            {
            OpenDatabase();
            string document;
            string filename;
            string filetype;
                var docs = new List<Documents>();
            
            string sql = "select * from documentations";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while(read.Read())
            {
                filename = Convert.ToString(read.GetValue(0));
                filetype = Convert.ToString(read.GetValue(1));
                byte[] doc=(byte[])read.GetValue(2);
                document = Encoding.ASCII.GetString(doc);
                // document = Encoding.Unicode.GetString(doc);
                //document = Encoding.UTF8.GetString(doc);


                docs.Add(new Documents { Filename = filename, Filetype = filetype, Document = document });
            }
            CloseDatabase();
            return docs;
            }
        public string updateAccount(UserAccount user)
        {
            string returnmessage;
            OpenDatabase();
            string sql = "update useraccounts set uName='"+user.UName +"', pWord='"+user.PWord+"' where userID="+user.Id;
            try {
                com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();

                if (com.ExecuteNonQuery() <= 0)
                    returnmessage = "Update Failed";
                else
                    returnmessage = "Update Succeeded";
            }
            catch(Exception)
            {
                returnmessage = "Update Failed";
               
            }
            finally
            {
                CloseDatabase();
               
            }
            return returnmessage;
        }
        public void deleteAccount(UserAccount user)
        {
            
            OpenDatabase();
            string sql = "delete from useraccounts where userID="+user.Id;
            try
            {
                com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();

               
            }
          
            finally
            {
                CloseDatabase();

            }
            
        }
        private void CloseDatabase()
        {
            con.Close();
        }
       
    }
}