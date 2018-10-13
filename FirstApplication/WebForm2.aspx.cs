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
        string datastring;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = DateTime.Now.ToString("yyyyMMdd");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(Label3.Text);
            if(!Password.Text.Equals(ConfirmPassword.Text))
            {
                Label7.Text = "Modify the Password!";
            }
            else
            {
                UserAccount acc = new UserAccount(userID, Username.Text, Password.Text);
                Database d = new Database();
                datastring = d.writeDatabase(acc);
                d.CloseDatabase();
                Label7.Text = datastring;
            }

        }
    }
}