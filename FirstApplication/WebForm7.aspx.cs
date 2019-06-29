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
       
        UserAccount user;
        Database data = new Database();
        Random random = new Random();
        static List<Transaction> transactionItems = new List<Transaction>();
        static string transactionItemID;
        static TransactionDetails transactionDetails = new TransactionDetails();
        static double totalPayable;
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
                cartCount.Text = transactionItems.Count.ToString();
            }
            if (Session["chosenProduct"] != null)
            {
                Product chosenProduct = (Product)Session["chosenProduct"];
                Transaction item = new Transaction();
                item.TransactionItem = chosenProduct;
                item.TransactionID = transactionItemID;
                transactionItems.Add(item);
               
                Session["chosenProduct"] = null;
            }
            
            transactionDetails.TransactionID = transactionItemID;
            transactionDetails.UserID = user.Id;
            LoadTransaction();
          
        }
        protected void LoadTransaction()
        {
            transactionList.DataSource = transactionItems;
            transactionList.DataBind();
        }
        protected void ComputeTransaction()
        {
            
            string totalPrice = "Total Price";
            totalPayable = 0;
            transactionDetails.TransactionID = transactionItemID;
            transactionDetails.UserID = user.Id;
            foreach(Transaction t in transactionItems)
            {
                totalPayable = t.TransactionPrice + totalPayable;
            }
            totalPriceLabel.Text = totalPrice+": " + totalPayable.ToString();
            
         

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            credentialCheck();

            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
            transactionLabel.Text = user.UName + "'s Transaction";
           
            LoadPictures();
            if (Session["transactionID"] == null)
            {
                transactionItemID = "BAG" + generateID(9);
                transactionID.Text = "Transaction ID is " +transactionItemID;
               
                Session["transactionID"] = transactionItemID;
            }
            else
            {
                transactionItemID = (string)Session["transactionID"];
                transactionID.Text = "Transaction ID is " + transactionItemID;

            }

            if (!IsPostBack)
            {
                
                showTransaction();
                Session["transactionList"] = transactionItems;
                ComputeTransaction();
            }
            
            
        }
        protected void LoadPictures()
        {

            Image1.ImageUrl = "StoreLogo.jpg";


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
           
            Label productPrice = e.Item.FindControl("Label2") as Label;
            Label totalPrice = e.Item.FindControl("Label3") as Label;
            DropDownList chosenQuantity = e.Item.FindControl("itemQuantity") as DropDownList;
            Label productTags = e.Item.FindControl("Label4") as Label;
            LinkButton productNamee = e.Item.FindControl("LinkButton1") as LinkButton;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                productImage.ImageUrl = "data:image/jpg;base64," + transactionItem.TransactionItem.ProductPic;
               
                productNamee.Text = transactionItem.TransactionItem.ProductName;
                productPrice.Text = transactionItem.TransactionItem.ProductPrice.ToString();
                totalPrice.Text = transactionItem.TransactionPrice.ToString();
                productTags.Text = productTags.Text + transactionItem.TransactionItem.ProductCategoryA + ", " + transactionItem.TransactionItem.ProductCategoryB + ", " + transactionItem.TransactionItem.ProductCategoryC;
                int stock;
                for (int i=0; i<transactionItem.TransactionItem.ProductQuantity;i++)
                {
                    stock = i + 1;
                    chosenQuantity.Items.Add(stock.ToString());
                }
                int selectedIndex = transactionItem.TransactionQuantity - 1;
                chosenQuantity.SelectedIndex = selectedIndex;
            }
        }

        protected void itemQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
           
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
            ComputeTransaction();
        }
        protected void productDetailView(object sender, EventArgs e)
        {
            var pdv = (LinkButton)sender;
            var item = (ListViewItem)pdv.NamingContainer;
            var index = item.DataItemIndex;
            string productName = pdv.Text;
            Session["ViewedProduct"] = productName;
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('WebForm8.aspx','_newtab');", true);
        }
        protected void transactionComputeButton_Click(object sender, EventArgs e)
        {
            try { 
            double cash = Convert.ToDouble(transactionCash.Text);
            double change = cash-totalPayable;
            transactionDetails.TransactionCash = cash;
            transactionDetails.TransactionChange = change;
            transactionChangeLabel.Text = transactionChangeLabel.Text + change.ToString();
            }
            catch(Exception)
            {
                return;
            }
        }
        private void clearTransaction()
        {
            for (int i = 0; i < transactionItems.Count; i++)
            {
                transactionItems.RemoveAt(i);
            }
            Session["transactionID"] = null;
            Session["transactionList"] = null;

            Response.Redirect("WebForm7.aspx");
        }

        protected void transactionCancelButton_Click(object sender, EventArgs e)
        {
            clearTransaction();
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            var dbx = (Button)sender;
            var item = (ListViewItem)dbx.NamingContainer;
            var index = item.DataItemIndex;
            transactionItems.RemoveAt(index);
            LoadTransaction();
            Response.Redirect("WebForm7.aspx");
        }

        protected void transactionConfirmButton_Click(object sender, EventArgs e)
        {
           foreach(Transaction t in transactionItems)
            {
                t.UserID = user.Id;
                data.ConfirmTransaction(t);
            }
            data.ConfirmTransactionDetails(transactionDetails);
            transactionStatus.Visible = true;
            transactionStatus.Text = "Transaction Complete";
            Delivery delivery = new Delivery();
            delivery.ParcelType = "Transaction";
            delivery.ParcelID = transactionDetails.TransactionID;
            delivery.UserID = user.Id;
            delivery.DeliveryStatus = "Pending";
            Session["Delivery"] = delivery;
            Session["ParcelDetails"] = transactionDetails;
            Response.Redirect("WebForm10.aspx");
          

        }
    }
}