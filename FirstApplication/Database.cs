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
            connectionString = @"Data Source=Janjamescallejo;Initial Catalog=storeProduction;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
        }
        public UserAccount ReadAccount(string userName)
        {
            OpenDatabase();
            UserAccount ac=new UserAccount();
            SqlCommand com;
           
            string sql = "select * from useraccounts where userName = '"+userName+"'";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while(read.Read())
            {
                ac.Id = Convert.ToString(read["userID"]);
                ac.UName = Convert.ToString(read["userName"]);
                ac.PWord = Convert.ToString(read["userPassword"]);
                ac.UserType = Convert.ToString(read["userType"]);
                ac.UserDate = (DateTime)read["accountDate"];
                
                if(ac!=null)
                {
                    break;
                }
            }
            CloseDatabase();
            return ac;

        }
        public UserAccount ShowAccount(string userID)
        {
            OpenDatabase();
            UserAccount ac = new UserAccount();
            SqlCommand com;

            string sql = "select * from useraccounts where userID = '" + userID + "'";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while (read.Read())
            {
                ac.Id = Convert.ToString(read["userID"]);
                ac.UName = Convert.ToString(read["userName"]);
                ac.PWord = Convert.ToString(read["userPassword"]);
                ac.UserType = Convert.ToString(read["userType"]);
                ac.UserDate = (DateTime)read["accountDate"];

                if (ac != null)
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
           
            string sql = "insert into useraccounts values('"+ac.Id+"','"+ac.UName+"','"+ac.PWord+"','"+ac.UserType+"','"+ac.UserDate.ToString("yyyy-MM-dd") +"')";
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
       
      
        public List<Product> readProduct()
        {
            OpenDatabase();
            var products = new List<Product>();
          
            string sql = "select * from products";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while (read.Read())
            {
                Product p = new Product();
                byte[] pixar = (byte[])read["productPic"];
                p.ProductPic = Convert.ToBase64String(pixar, 0, pixar.Length);
                p.ProductID = Convert.ToString(read["productID"]);
                p.ProductName = Convert.ToString(read["productName"]);
                p.ProductDescription = Convert.ToString(read["productDescription"]);
                p.ProductCategoryA = Convert.ToString(read["productCategoryA"]);
                p.ProductCategoryB = Convert.ToString(read["productCategoryB"]);
                p.ProductCategoryC = Convert.ToString(read["productCategoryC"]);
                p.ProductPrice = Convert.ToDouble(read["productPrice"]);
                p.ProductQuantity = Convert.ToInt32(read["productQuantity"]);
                p.UserID = Convert.ToString(read["userID"]);
                p.ProductDate = (DateTime)read["productDate"];
                products.Add(p);
            }
            CloseDatabase();
            return products; 
        }

        public Product showProduct(string productName)
        {
            Product product=new Product();
            OpenDatabase();
            string sql = "select * from products where productName = '"+productName+"'";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while (read.Read())
            {
                
                byte[] pixar = (byte[])read["productPic"];
                product.ProductPic = Convert.ToBase64String(pixar, 0, pixar.Length);
                product.ProductID = Convert.ToString(read["productID"]);
                product.ProductName = Convert.ToString(read["productName"]);
                product.ProductDescription = Convert.ToString(read["productDescription"]);
                product.ProductCategoryA = Convert.ToString(read["productCategoryA"]);
                product.ProductCategoryB = Convert.ToString(read["productCategoryB"]);
                product.ProductCategoryC = Convert.ToString(read["productCategoryC"]);
                product.ProductPrice = Convert.ToDouble(read["productPrice"]);
                product.ProductQuantity = Convert.ToInt32(read["productQuantity"]);
                product.UserID = Convert.ToString(read["userID"]);
                product.ProductDate = (DateTime)read["productDate"];
              
            }
            CloseDatabase();
            return product;
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
              

                docs.Add(new Documents { Filename = filename, Filetype = filetype, Document = document });
            }
            CloseDatabase();
            return docs;
            }
        public string updateAccount(UserAccount user)
        {
            string returnmessage;
            OpenDatabase();
            string sql = "update useraccounts set uName='"+user.UName +"', pWord='"+user.PWord+"' where userID='"+user.Id+"'";
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

        public List<Product> readAccountProduct(UserAccount user)
        {
            OpenDatabase();
            var products = new List<Product>();
           
           

            string sql = "select * from products where userID = '"+user.Id+"'";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while (read.Read())
            {
                Product p = new Product();
                byte[] pixar = (byte[])read["productPic"];
                p.ProductPic = Convert.ToBase64String(pixar, 0, pixar.Length);
                p.ProductID = Convert.ToString(read["productID"]);
                p.ProductName = Convert.ToString(read["productName"]);
                p.ProductDescription = Convert.ToString(read["productDescription"]);
                p.ProductCategoryA = Convert.ToString(read["productCategoryA"]);
                p.ProductCategoryB = Convert.ToString(read["productCategoryB"]);
                p.ProductCategoryC = Convert.ToString(read["productCategoryC"]);
                p.ProductPrice = Convert.ToDouble(read["productPrice"]);
                p.ProductQuantity = Convert.ToInt32(read["productQuantity"]);
                p.UserID = Convert.ToString(read["userID"]);
                p.ProductDate = (DateTime)read["productDate"];
                products.Add(p);
                
            }
            CloseDatabase();
            return products;
        }
        public void deleteAccount(UserAccount user)
        {
            
            OpenDatabase();
            string sql = "delete from useraccounts where userID='"+user.Id+"'";
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

        public List<Tag> readTags()
        {
            var tags = new List<Tag>();
            OpenDatabase();
            string sql = "select * from tags";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while(read.Read())
            {
                Tag tag = new Tag();
                tag.TagID = Convert.ToString(read["tagID"]);
                tag.TagName = Convert.ToString(read["tagName"]);
                tag.TagDescription = Convert.ToString(read["tagDescription"]);
                tag.UserID = Convert.ToString(read["userID"]);
                tags.Add(tag);
            }
            CloseDatabase();
            return tags;
        }
        public void sellProduct(Product prod)
        {
            OpenDatabase();
            string sql = "insert into products (productID, productName, productDescription, productCategoryA, productCategoryB, productCategoryC, productPrice, ProductQuantity, userID, productDate) values ('"+prod.ProductID+"', '"+prod.ProductName+"','"+prod.ProductDescription+"', '"+prod.ProductCategoryA+"','"+prod.ProductCategoryB+"','"+prod.ProductCategoryC+"',"+prod.ProductPrice+","+prod.ProductQuantity+",'"+prod.UserID+"','"+prod.ProductDate.ToString("yyyy-MM-dd")+"')";
            try
            {
                com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();


            }

            finally
            {
                CloseDatabase();
                productPicture(prod);
            }

        }
        private void productPicture(Product prod)
        {
            OpenDatabase();
            string sql = "UPDATE products SET productPic = (SELECT * FROM OPENROWSET(BULK N'"+prod.ProductPic+"', SINGLE_BLOB) AS pic) WHERE productID = '"+prod.ProductID+"'";
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
        private static string output = null;
        private string appostropheSeparator(string input)
        {

            string insert = "'";


           
            int index = input.IndexOf(@"'");
            if (index < 0)
                return output += input;
            for (int i = 0; i < input.Length; i++)
            {
                output += input.Substring(i, 1);
                if (i == index)
                {
                    output += insert;
                    break;

                }

            }
            int mindex = index + 1;

            string input1 = null;

            input1 = input.Substring(mindex, input.Length - mindex);

        
            if (input.Length - mindex > 0)
                appostropheSeparator(input1);

            return output;
        }
        public void uploadTag(Tag tag)
        {
            int index = tag.TagDescription.IndexOf(@"'");
            if(index>0)
            {
                tag.TagDescription = appostropheSeparator(tag.TagDescription);
            }
            OpenDatabase();
            string sql = "insert into tags values('"+tag.TagID+"','"+tag.TagName+"','"+tag.TagDescription+"','"+tag.UserID+"','"+tag.TagDate.ToString("yyyy-MM-dd") +"')";
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
        public List<UserAccount> readAccounts()
        {
            var Accounts = new List<UserAccount>();
            OpenDatabase();
            string sql = "select * from useraccounts ";
            com = new SqlCommand(sql, con);
            read = com.ExecuteReader();
            while (read.Read())
            {
                UserAccount ac = new UserAccount();
                ac.Id = Convert.ToString(read["userID"]);
                ac.UName = Convert.ToString(read["userName"]);
                ac.PWord = Convert.ToString(read["userPassword"]);
                ac.UserDate = (DateTime)read["accountDate"];
                Accounts.Add(ac);
                
            }
            CloseDatabase();
            return Accounts;
        }
        private void updateProductQuantity(Product product, int chosenQuantity)
        {
            OpenDatabase();
            string sql = "update products set productQuantity = productQuantity-"+chosenQuantity+" where productID='"+product.ProductID+"'";
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
        private void insertTransactionItem(Transaction transaction)
        {
            OpenDatabase();
            string sql = "insert into usertransaction values('"+transaction.TransactionID+"','"+transaction.TransactionItem.ProductID+"',"+transaction.TransactionQuantity+","+transaction.TransactionPrice+",'"+transaction.UserID+"')";
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
        public void ConfirmTransaction(Transaction transaction)
        {
            updateProductQuantity(transaction.TransactionItem,transaction.TransactionQuantity);
            insertTransactionItem(transaction);
        }
        public void ConfirmTransactionDetails(TransactionDetails transactionDetails)
        {
            OpenDatabase();
            string sql = "insert into usertransactionDetails values('"+transactionDetails.TransactionID+"','"+transactionDetails.UserID+"',"+transactionDetails.TransactionCash+","+transactionDetails.TransactionChange+")";
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