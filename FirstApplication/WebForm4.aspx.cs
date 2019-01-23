using System;
using System.Collections.Generic;
using System.Data;
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
        static List<string> productnames=new List<string>();
        static List<string> tagnames = new List<string>();
        static List<Product> products;
        static bool hasChosen = false;
        static List<Tag> userTags;
        static bool hasChosenProduct = false;
        static string choiceType;
        static List<Transaction> transactionItems = new List<Transaction>();
        static Product chosenProduct = new Product();
        static Tag chosenTag = new Tag();
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
        protected void LoadList()
        {
          if(hasChosen==false)
            {
                SelectedBox.Visible = false;
                ListName.Text = "Please Choose An Option to View";
            }
          else
            {
                SelectedBox.Visible = true;
                if (choiceType.Equals("SoldProducts"))
                {
                    products = data.readAccountProduct(user);

                    foreach (Product p in products)
                    {
                        productnames.Add(p.ProductName);
                    }
                    SelectedBox.DataSource = productnames;
                    SelectedBox.DataBind();
                    ListName.Text = user.UName + "'s Sold Products";
                }
                if (choiceType.Equals("Tags"))
                {

                    userTags = data.readTags();
                    userTags = userTags.Where(o => o.UserID.Contains(user.Id)).ToList();
                    foreach (Tag t in userTags)
                    {
                        tagnames.Add(t.TagName);
                    }
                    SelectedBox.DataSource = tagnames;
                    SelectedBox.DataBind();
                    ListName.Text = user.UName + "'s Created Tags";
                }

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
            
            pictures = data.readpics();
            LoadPictures();
            LoadAccount();
            if(!IsPostBack)
            {
                Hider();
                LoadList();
                ShowTransaction();
            }

            
        }
        protected void LoadProduct()
        {
            string[] displayTags = new string[3];
            List<Tag> tags = data.readTags();
            foreach(Tag t in tags)
            {
                if(chosenProduct.ProductCategoryA.Equals(t.TagID))
                {
                    displayTags[0] = t.TagName;
                }
                if (chosenProduct.ProductCategoryB.Equals(t.TagID))
                {
                    displayTags[1] = t.TagName;
                }
                if (chosenProduct.ProductCategoryC.Equals(t.TagID))
                {
                    displayTags[2] = t.TagName;
                }
            } 
            if(hasChosenProduct==true)
            {
                ProductTable.Visible = true;
                chosenProductID.Text = chosenProduct.ProductID;
                chosenProductPicture.ImageUrl = "data:image/jpg;base64," + chosenProduct.ProductPic;
                chosenProductName.Text = chosenProduct.ProductName;
                chosenProductTags.Text = displayTags[0] + ", " + displayTags[1] + ", " + displayTags[2];
                chosenProductQuantity.Text = chosenProduct.ProductQuantity.ToString();
                chosenProductPrice.Text = chosenProduct.ProductPrice.ToString();
            }
        }
       protected void LoadTag()
        {
            TagTable.Visible = true;
            chosenTagID.Text = chosenTag.TagID;
            chosenTagName.Text = chosenTag.TagName;
            chosenTagDescription.Text = chosenTag.TagDescription;
        }
        protected void LoadAccount()
        {
            AccountInfo_AccountName.Text = user.UName;
            AccountInfo_AccountID.Text = user.Id.ToString();
            //AccountInfo_AccountDate.Text = user.date.ToString("MMMM dd, yyyy");

        }
        protected void LoadPictures()
        {

            Image1.ImageUrl = "data:image/jpg;base64," + pictures.ElementAt(0);

           
        }
        protected void Hider()
        {
            hasChosen = false;
            userTags = null;
            products = null;
            int last= productnames.Count-1;
            if(last>0)
            {
                productnames.RemoveRange(0, last);
            }
           
            ProductTable.Visible = false;
            TagTable.Visible = false;
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

        protected void SSPButton_Click(object sender, EventArgs e)
        {
            Hider();
            hasChosen = true;
            choiceType = "SoldProducts";
          LoadList();
        }

        protected void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(choiceType.Equals("SoldProducts"))
            {
                string chosenProductName = SelectedBox.Text;
                hasChosenProduct = true;
                foreach (Product p in products)
                {
                    if (chosenProductName.Equals(p.ProductName))
                    {
                        chosenProduct = p;
                    }
                }
                LoadProduct();
            }
            if(choiceType.Equals("Tags"))
            {
                string chosenTagName = SelectedBox.Text;
                foreach (Tag t in userTags)
                {
                    if(chosenTagName.Equals(t.TagName))
                    {
                        chosenTag = t;
                    }
                }
                LoadTag();
            }
            
        }

        protected void SATButton_Click(object sender, EventArgs e)
        {
            Hider();
            hasChosen = true;
            choiceType = "Tags";
            LoadList();
        }

        protected void chosenEdit_Click(object sender, EventArgs e)
        {
            if(choiceType.Equals("Tags"))
            {
                Session["EditMode"] = "Tag";
                Session["EditValue"] = chosenTag;
                Response.Redirect("WebForm5.aspx");
            }
            if (choiceType.Equals("SoldProducts"))
            {
                Session["EditMode"] = "SoldProducts";
                Session["EditValue"] = chosenProduct;
                Response.Redirect("WebForm5.aspx");
            }
        }
    }
}