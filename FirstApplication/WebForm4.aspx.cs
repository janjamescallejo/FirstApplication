using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        List<string> pictures;
        UserAccount user;
        Database data = new Database();
        
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
                Response.Redirect("Webform1.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            credentialCheck();
            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
            
            pictures = data.readpics();
            LoadPictures();
            LoadAccount();
        }
        protected void LoadAccount()
        {
            AccountInfo_AccountName.Text = user.UName;
            AccountInfo_AccountID.Text = user.Id.ToString();
            AccountInfo_AccountDate.Text = user.date.ToString("MMMM dd, yyyy");

        }
        protected void LoadPictures()
        {

            Image1.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(0);

            // Image2.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(1);
        }
        protected void SignUpButton1_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
            Response.Redirect("WebForm2.aspx");
        }

        protected void LogInButton1_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
            Response.Redirect("WebForm2.aspx");
        }
        protected void LogOutButton1_Click(object sender, EventArgs e)
        {
            Session["UserAccount"] = null;
            Session["EditMode"] = null;
            Response.Redirect("WebForm1.aspx");
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Session["EditMode"] = "Account";
             
            Response.Redirect("WebForm2.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            data.deleteAccount(user);
            Session["UserAccount"] = null;
            Session["EditMode"] = null;
            Response.Redirect("WebForm1.aspx");
        }
    }
}