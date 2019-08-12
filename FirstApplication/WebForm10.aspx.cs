using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm10 : System.Web.UI.Page
    {

        bool confirmAddress = false;
        UserAccount user;
        static List<Transaction> transactionItems = new List<Transaction>();
        Delivery delivery;
        Database data;
        protected void Page_Load(object sender, EventArgs e)
        {
            credentialCheck();
            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
            LoadPictures();
          
            if (!IsPostBack)
            {
                ShowTransaction();


            }
            deliveryContent();
            if (confirmAddress == false)
            {
                deliveryConfirm.Enabled = false;
            }
            else
            {
                deliveryConfirm.Enabled = true;
            }
        }
        private void deliveryContent()
        {
            
            String DeliveryContent;

            delivery = (Delivery)Session["Delivery"];
            DeliveryContent = "Delivery ID: " + delivery.DeliveryID + " Delivery Recipient: " + user.UName + " Delivery Status: "+delivery.DeliveryStatus;
          
            if (delivery.ParcelType.Equals("Transaction"))
            {
                double transactionTotal=0;
                DeliveryContent =DeliveryContent+"<br />"+" Transaction Name    QTY     Price";
                foreach (Transaction transact in transactionItems) {
                    transactionTotal = transact.TransactionPrice + transactionTotal;
                    DeliveryContent = DeliveryContent + "<br />"+transact.TransactionItem.ProductName+" "+transact.TransactionQuantity+" "+transact.TransactionPrice;
                }
                TransactionDetails td = (TransactionDetails)Session["ParcelDetails"];
                DeliveryContent = DeliveryContent+"<br />"+"Transaction Total " + transactionTotal + " Cash: " + td.TransactionCash + " Change: "  + td.TransactionChange ;
               
            }
            if (delivery.ParcelType.Equals("NewProduct"))
            {
                Product parcelProduct = (Product)Session["ParcelDetails"];
                DeliveryContent = DeliveryContent + "<br />" + "Product ID: "+parcelProduct.ProductID;
                DeliveryContent = DeliveryContent + "<br />" + "Product Name: " + parcelProduct.ProductName;
                DeliveryContent = DeliveryContent + "<br />" + "Product Quantity to be Sent: " + parcelProduct.ProductQuantity;
                DeliveryContent = DeliveryContent + "<br />" + "Product Price: " + parcelProduct.ProductPrice;
                DeliveryContent = DeliveryContent + "<br />" + "Product Date: " + parcelProduct.ProductDate;
                DeliveryContent = DeliveryContent + "<br />" + "Product Description: <br />" + parcelProduct.ProductDescription;
            }
            deliveryItems.Text = DeliveryContent;
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

        protected void deliveryConfirm_Click(object sender, EventArgs e)
        {
            //Something needs to be done here. 
        }

        protected void clearAddress_Click(object sender, EventArgs e)
        {
            deliveryAddress.Text = "";
        }
    }
}