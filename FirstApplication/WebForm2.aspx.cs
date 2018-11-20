using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<string> pictures;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] != null)
            {
                UName.Text = "Welcome " + Session["UserName"].ToString();
            }
            else
            {
                UName.Text = "You are not logged in";
            }
            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
            Database x = new Database();
            pictures = x.readpics();
            RegUserID.Text = DateTime.Now.ToString("yyMMddHHmm");

            x.CloseDatabase();
            LoadPictures();
           // initPassword();
        }
        protected void initPassword()
        {
            RPassword = new TextBox();
            RConfirmPassword = new TextBox();
            SIPassword = new TextBox();
            
        }
        protected void LoadPictures()
        {

            Image1.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(0);
           // Image2.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(1);
        }

        protected void Register_Click(object sender, EventArgs e)
        {
           

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(
           this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(
           this.GetType(), "OpenWindow", "window.open('Webform2.aspx','_newtab');", true);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SIPassword.Text = "";
            SIUsername.Text = "";
            SIWarning.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Database c = new Database();
            UserAccount user = c.ReadDatabase(SIUsername.Text);
            c.CloseDatabase();
            try
            {
                if (user.uName.Equals(SIUsername.Text)&&user.pWord.Equals(SIPassword.Text))
                {
                   // Combined.Text = "You are Registered";
                    //UName.Text = "Welcome "+Username.Text;
                    Session["UserName"] = SIUsername.Text;
                    UName.Text = "Welcome " + Session["UserName"].ToString();

                }
                else
                {
                    SIWarning.Visible = true;
                    SIWarning.Text = "Please input correct credentials";

                }
            }
            catch (Exception)
            {
              //  Combined.Text = "You are not Registered";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            RUsername.Text = "";
            RPassword.Text = "";
            RConfirmPassword.Text = "";
            RAgreeToTerms.Checked = false;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if(RAgreeToTerms.Checked==false||!RPassword.Text.Equals(RConfirmPassword.Text))
            {
                RWarning.Visible = true;
                RWarning.Text = "Please input complete credentials";
            }
            else
            {
                string res;
                UserAccount ua;
               
                int id = Convert.ToInt32(RegUserID.Text);
                ua = new UserAccount(id, RUsername.Text, RPassword.Text);
                Database dc = new Database();
               res= dc.writeDatabase(ua);
                dc.CloseDatabase();
                RWarning.Visible = true;
                RWarning.Text = res;
            }
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
        }
    }
}