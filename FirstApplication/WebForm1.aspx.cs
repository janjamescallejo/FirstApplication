using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Product> products;
        List<string> pictures;
      
        

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(Session["UserName"] != null)
            {
                UName.Text = "Welcome " + Session["UserName"].ToString();
                Button3.Visible = false;
                Button4.Visible = false;
                Button6.Visible = true;
            }
            else
            {
                UName.Text = "You are not logged in";
            }
            CopyrightLabel.Text = "©"+DateTime.Now.ToString("yyyy")+" Jan James Callejo All Rights Reserved";
            Database x = new Database();
            pictures = x.readpics();


            x.CloseDatabase();
            LoadPictures();
            Database y = new Database();
            products = y.readProduct();

            y.CloseDatabase();
            readProducts();
            //Combined.Text = "Your username is " + Username.Text + " Your password is " + Password.Text;

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

        protected void Submit_Click(object sender, EventArgs e)
        {
            Database c = new Database();
            UserAccount user = c.ReadDatabase(Username.Text);
            c.CloseDatabase();
            try
            {
                if (user.uName.Equals(Username.Text))
                {
                    Combined.Text = "You are Registered";
                    //UName.Text = "Welcome "+Username.Text;
                    Session["UserName"] = Username.Text;
                    UName.Text = "Welcome " + Session["UserName"].ToString();

                }
                else
                {
                    Combined.Text = "You are not Registered";
                   
                }
            }
            catch (Exception)
            {
                Combined.Text = "You are not Registered";
            }
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
        }
    }
}