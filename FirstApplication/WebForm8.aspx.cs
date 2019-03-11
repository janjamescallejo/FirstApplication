using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        UserAccount user;
        static List<Transaction> transactionItems = new List<Transaction>();
        static string productName;
        Database data = new Database();
        Product product = new Product();
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
            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
           
            LoadPictures();
            productName = Session["ViewedProduct"].ToString();
            product = data.showProduct(productName);
            LoadProduct();
            if (!IsPostBack)
            {
                ShowTransaction();
            }
        }
        protected void LoadProduct()
        {
            productLabel.Text = product.ProductName;
            productQuantity.Text = productQuantity.Text + product.ProductQuantity;
            productPrice.Text = productPrice.Text + product.ProductPrice;
            productDescription.Text = product.ProductDescription;
            productDate.Text = productDate.Text + product.ProductDate.ToString("MMMM dd, yyyy");
            productImage.ImageUrl = "data:image/jpg;base64," + product.ProductPic;
            showTags();
        }
        protected void showTags()
        {
            List<Tag> tags = new List<Tag>();
            tags = data.readTags();
            foreach(Tag t in tags)
            {
                if(t.TagID.Equals(product.ProductCategoryA))
                {
                    productTags.Text = productTags.Text +t.TagName+ ", "; 
                }
                if (t.TagID.Equals(product.ProductCategoryB))
                {
                    productTags.Text = productTags.Text + t.TagName + ", ";
                }
                if (t.TagID.Equals(product.ProductCategoryC))
                {
                    productTags.Text = productTags.Text +"and "+ t.TagName;
                }
            }
            showSeller();
        }
        protected void showSeller()
        {
            UserAccount seller = data.ShowAccount(product.UserID);
            productSeller.Text = productSeller.Text + seller.UName;
        }
        protected void LoadPictures()
        {

            Image1.ImageUrl = "StoreLogo.jpg";

        }

        protected void Register_Click(object sender, EventArgs e)
        {

            Response.Redirect("Webform2.aspx");
        }

        protected void SignUpButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Webform2.aspx");
        }

        protected void LogInButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Webform2.aspx");
        }

        protected void LogOutButton1_Click(object sender, EventArgs e)
        {
            Session["UserAccount"] = null;
            Session["EditMode"] = null;
            Response.Redirect("WebForm1.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string[] searchInputs = new string[2];
            searchInputs[0] = "Purple";
            searchInputs[1] = "Products";
            Session["searchInputs"]=searchInputs;
            Page.ClientScript.RegisterStartupScript(
this.GetType(), "OpenWindow", "window.open('WebForm6.aspx','_newtab');", true);

        }
    }
}