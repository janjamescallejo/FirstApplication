using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        List<string> pictures;
        UserAccount user;
        Database data = new Database();
        Random random = new Random();
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
                Response.Redirect("Webform1.aspx");
            }
        }
        protected string generateID(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected void showTransaction()
        {
            if (Session["transactionList"] != null)
            {
                transactionItems = (List<Transaction>)Session["transactionList"];
            }
            if (Session["chosenProduct"] != null)
            {
                Product chosenProduct = (Product)Session["chosenProduct"];
                Transaction item = new Transaction();
                item.TransactionItem = chosenProduct;
                item.TransactionID = transactionID.Text;
                transactionItems.Add(item);
               
                Session["chosenProduct"] = null;
            }
            LoadTransaction();
          
        }
        protected void LoadTransaction()
        {
            transactionList.DataSource = transactionItems;
            transactionList.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            credentialCheck();

            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
            transactionLabel.Text = user.UName + "'s Transaction";
            pictures = data.readpics();
            LoadPictures();
            if (Session["transactionID"] == null)
            {

                transactionID.Text = "BAG" + generateID(9);
                Session["transactionID"] = transactionID.Text;
            }
            else
            {
                transactionID.Text = (string)Session["transactionID"];

            }
            if (!IsPostBack)
            {
                
                showTransaction();
                Session["transactionList"] = transactionItems;
            }
           
        }
        protected void LoadPictures()
        {

            Image1.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(0);


        }
        protected void SignUpButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebForm2.aspx");
        }

        protected void LogInButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebForm2.aspx");
        }
        protected void LogOutButton1_Click(object sender, EventArgs e)
        {
            Session["UserAccount"] = null;
            Session["EditMode"] = null;
            Response.Redirect("WebForm1.aspx");
        }
        protected void transactionList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var transactionItem = (Transaction)e.Item.DataItem;
            Image productImage = e.Item.FindControl("Image2") as Image;
            Label productName = e.Item.FindControl("Label1") as Label;
            Label productPrice = e.Item.FindControl("Label2") as Label;
            Label totalPrice = e.Item.FindControl("Label3") as Label;
            DropDownList chosenQuantity = e.Item.FindControl("itemQuantity") as DropDownList;
            Label productTags = e.Item.FindControl("Label4") as Label;

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                productImage.ImageUrl = "data:image/jpg;base64," + transactionItem.TransactionItem.ProductPic;
                productName.Text = transactionItem.TransactionItem.ProductName;
                productPrice.Text = transactionItem.TransactionItem.ProductPrice.ToString();
                totalPrice.Text = transactionItem.TransactionPrice.ToString();
                productTags.Text = productTags.Text + transactionItem.TransactionItem.ProductCategoryA + ", " + transactionItem.TransactionItem.ProductCategoryB + ", " + transactionItem.TransactionItem.ProductCategoryC;
                int stock;
                for (int i=0; i<transactionItem.TransactionItem.ProductQuantity;i++)
                {
                    stock = i + 1;
                    chosenQuantity.Items.Add(stock.ToString());
                }

            }
        }

        protected void itemQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            /*  transactionItems.ElementAt(index).TransactionQuantity = count;
              transactionItems.ElementAt(index).TransactionPrice = transactionItems.ElementAt(index).TransactionQuantity * transactionItems.ElementAt(index).TransactionItem.ProductPrice;
              LoadTransaction();*/
        }

        protected void quantityButton_Click(object sender, EventArgs e)
        {
            var dbx = (Button)sender;
            var item = (ListViewItem)dbx.NamingContainer;
            var index = item.DataItemIndex;
            DropDownList ddl = item.FindControl("itemQuantity") as DropDownList;
            Label totalPrice = item.FindControl("Label3") as Label;
            Label unitPrice = item.FindControl("label2") as Label;
            double price = Convert.ToDouble(unitPrice.Text);
            int count = Convert.ToInt32(ddl.SelectedItem.Text);
            double total = price * count;
            totalPrice.Text = total.ToString();
            transactionItems.ElementAt(index).TransactionQuantity = count;
            transactionItems.ElementAt(index).TransactionPrice = total;
        }
    }
}