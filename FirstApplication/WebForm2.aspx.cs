using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<string> pictures;
        Database data = new Database();
        UserAccount user;
        static Random random = new Random();
        string editAccount;
        static List<Transaction> transactionItems = new List<Transaction>();
        protected string generateID(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
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
        protected void EditMode()
        {
            if (editAccount.Equals("Account"))
                {
                 
                    Registration.Visible = false;
                    SignInLabel1.Text = "Edit";
                    SIUsername.Text = user.UName;
                    SIPassword.Text = user.PWord;
                    SIPassword.TextMode = TextBoxMode.SingleLine;
                    SignInButton2.Text = "Update";
                }
                else
                {
                    return;
                }
          
        }
        protected void EditEnd()
        {
            user.UName = SIUsername.Text;
            user.PWord = SIPassword.Text;
            SIWarning.Visible = true;
            SIWarning.Text = data.updateAccount(user);
            Submit();
        }
        protected void Submit()
        {
            user = data.ReadAccount(SIUsername.Text);
            if (user.UName.Equals(SIUsername.Text) && user.PWord.Equals(SIPassword.Text))
            {

                Session["UserAccount"] = user;
                credentialCheck();
                SIWarning.Visible = false;
                Response.Redirect("WebForm1.aspx");
                SIClear();

            }
            else
            {
                SIWarning.Visible = true;
                SIWarning.Text = "Please input correct credentials";

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
            try {editAccount= Session["EditMode"].ToString(); }
            catch(Exception)
            { editAccount = ""; }
            if(!Page.IsPostBack)
            {
                EditMode();
                ShowTransaction();
            }

           
            
            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
           
            pictures = data.readpics();
            RegUserID.Text = "ACCOUNT"+generateID(5);

          
            LoadPictures();
          
        }
       
        protected void LoadPictures()
        {

            Image1.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(0);
           // Image2.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(1);
        }
        protected void SIClear()
        {
            SIPassword.Text = "";
            SIUsername.Text = "";

        }
        protected void LOClear()
        {
            RUsername.Text = "";
            RPassword.Text = "";
            RConfirmPassword.Text = "";
        }

        protected void SignUpButton1_Click(object sender, EventArgs e)
        {
            // Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
            Response.Redirect("WebForm2.aspx");
        }

        protected void LogInButton1_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
            Response.Redirect("Webform2.aspx");
        }

        protected void SignInButton3_Click(object sender, EventArgs e)
        {
            SIClear();
            SIWarning.Visible = false;
        }

        protected void SignInButton2_Click(object sender, EventArgs e)
        {
            try
                {
                if (editAccount.Equals("Account"))
                {
                    EditEnd();
                }
                else
                {
                    Submit();
                }
                }
                catch (SqlException)
                {
                    SIWarning.Visible = true;
                    SIWarning.Text = "Please input correct credentials";
                }
           
            
        }

       protected void LogInButton3_Click(object sender, EventArgs e)
        {
            LOClear();
            RAgreeToTerms.Checked = false;
        }

        protected void LogInButton2_Click(object sender, EventArgs e)
        {
            if(RAgreeToTerms.Checked==false||!RPassword.Text.Equals(RConfirmPassword.Text))
            {
                RWarning.Visible = true;
                RWarning.Text = "Please input complete credentials";
            }
            else
            {
                string res;
                UserAccount ua = new UserAccount();


                ua.Id = RegUserID.Text;
                ua.UName = RUsername.Text;
                ua.PWord = RPassword.Text;
                ua.UserDate = DateTime.Now;
                ua.UserType = "Customer";
                
               res= data.writeDatabase(ua);
                RWarning.Visible = true;
                RWarning.Text = res;
                LOClear();
            }
        }

        protected void LogOutButton1_Click(object sender, EventArgs e)
        {
            Session["UserAccount"] = null;
            Session["EditMode"] = null;
            Response.Redirect("WebForm1.aspx");
          
        }
    }
}