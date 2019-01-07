using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace FirstApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Product> products;
        List<string> pictures;
        UserAccount user;
        static List<Transaction> transactionItems = new List<Transaction>();
        protected void credentialCheck()
        {
            

                if (Session["UserAccount"] != null)
                {
                    user = (UserAccount)Session["UserAccount"];
                    UName.Text = "Welcome " + user.UName;
                    LogInButton1.Visible = false;
                    SignUpButton1.Visible = false;
                    LogOutButton1.Visible = true;
                }
                else
                {
                    LogInButton1.Visible = true;
                    SignUpButton1.Visible = true;
                    LogOutButton1.Visible = false;
                    UName.Text = "You are not logged in";
                }
              
        }
        protected void ShowTransaction()
        {
            if (Session["transactionList"] != null)
            {
                transactionItems = (List<Transaction>)Session["transactionList"];
                cartCount.Text = transactionItems.Count.ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            credentialCheck();
            CopyrightLabel.Text = "©"+DateTime.Now.ToString("yyyy")+" Jan James Callejo All Rights Reserved";
            Database data=new Database();
            pictures = data.readpics();
            
            products = data.readProduct();
            
            LoadPictures();
            readProducts();
            if(!IsPostBack)
            {
                ShowTransaction();
            }

        }
        protected void LoadPictures()
        {

        Image1.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(0);
        Image2.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(1);
        }
            protected void readProducts()
        {
            Random r = new Random();
            int index = r.Next(0, products.Count);
            int index1 = r.Next(0, products.Count);
            int index2 = r.Next(0, products.Count);
            while (index == index2 || index == index1 || index1 == index2)
            {
                if (index == index2)
                {

                    index = r.Next(products.Count);
                    index2 = r.Next(products.Count);

                }
                else if (index == index1)
                {

                    index = r.Next(products.Count);
                    index1 = r.Next(products.Count);

                }
                else if (index2 == index1)
                {

                    index2 = r.Next(products.Count);
                    index1 = r.Next(products.Count);

                }
            }
            Product p;
            p = products.ElementAt(index);
            ProductImage1.ImageUrl = "data:image/jpg;base64," + p.ProductPic;
            ItemName1.Text = p.ProductName;
            ItemPrize1.Text = "Price: P " + Convert.ToString(p.ProductPrice);
            ItemQuantity1.Text = "Quantity: " + Convert.ToString(p.ProductQuantity);
           
            p = products.ElementAt(index1);
            ProductImage2.ImageUrl = "data:image/jpg;base64," + p.ProductPic;
            ItemName2.Text = p.ProductName;
            ItemPrize2.Text = "Price: P " + Convert.ToString(p.ProductPrice);
            ItemQuantity2.Text = "Quantity: " + Convert.ToString(p.ProductQuantity);
           
            p = products.ElementAt(index2);
            ProductImage3.ImageUrl = "data:image/jpg;base64," + p.ProductPic;
            ItemName3.Text = p.ProductName;
            ItemPrize3.Text = "Price: P " + Convert.ToString(p.ProductPrice);
            ItemQuantity3.Text = "Quantity: " + Convert.ToString(p.ProductQuantity);
           
        }

       
        protected void Register_Click(object sender, EventArgs e)
        {

            Response.Redirect("Webform2.aspx");
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Product1.Visible = false;
            Product2.Visible = false;
            Product3.Visible = false;
            menu.Style.Add("background-color", "Red"); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Product1.Visible = true;
            Product2.Visible = true;
            Product3.Visible = true;

        }

        protected void SignUpButton1_Click(object sender, EventArgs e)
        {
            // Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
            Response.Redirect("Webform2.aspx");
        }

        protected void LogInButton1_Click(object sender, EventArgs e)
        {
            // Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
            Response.Redirect("Webform2.aspx");
        }

        protected void LogOutButton1_Click(object sender, EventArgs e)
        {
            Session["UserAccount"] = null;
            Session["EditMode"] = null;
            Response.Redirect("WebForm1.aspx");
           
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string searchQuery = Searchbox.Text;
            string searchOption = searchOptionList.Text;
            string[] searchInputs = new string[2];
            searchInputs[0] = searchQuery;
            searchInputs[1] = searchOption;
            Session["searchInputs"] = searchInputs;
            Response.Redirect("WebForm6.aspx");
        }
    }
}