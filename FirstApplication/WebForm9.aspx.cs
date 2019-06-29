using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm9 : System.Web.UI.Page
    {
       

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
        protected void Page_Load(object sender, EventArgs e)
        {

            credentialCheck();
            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
            Database data = new Database();


           

            LoadPictures();
           
            if (!IsPostBack)
            {
                ShowTransaction();
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

    }
}