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
       
        protected void Page_Load(object sender, EventArgs e)
        {

            Database x = new Database();
            String ms = x.readpic();
            Image1.ImageUrl = "data:image/jpg;base64," + ms;
            x.CloseDatabase();
            Database y = new Database();
            Product p = y.readProduct();
            ProductImage1.ImageUrl = "data:image/jpg;base64," + p.ProductPic;
            ItemName1.Text = p.ProductName;
            ItemPrize1.Text = "Price: P "+Convert.ToString(p.ProductPrice);
            ItemQuantity1.Text = "Quantity: "+Convert.ToString(p.ProductQuantity);
            ItemDescription1.Text = p.ProductDescription;
            ItemCat11.Text = p.ProductCategoryA;
            ItemCat12.Text = p.ProductCategoryB;
            ItemCat13.Text = p.ProductCategoryC;
            y.CloseDatabase();

            //Combined.Text = "Your username is " + Username.Text + " Your password is " + Password.Text;

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
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Product1.Visible = true;
            Product2.Visible = true;
        }
    }
}