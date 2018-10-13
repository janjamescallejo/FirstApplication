using System;
using System.Collections.Generic;
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
            catch(Exception)
            {
                Combined.Text = "You are not Registered";
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {

            Response.Redirect("Webform2.aspx");
            }
    }
}