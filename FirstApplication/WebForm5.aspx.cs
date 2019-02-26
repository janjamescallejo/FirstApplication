using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace FirstApplication
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        
        List<string> chosenTags = new List<string>();
        static List<Tag> tags;
        List<string> displayTags = new List<string>();
        UserAccount user;
        Database data = new Database();
        Random random = new Random();
        static string productPic;
        static Product prod;
        static string editKey;
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
        protected void LoadTags()
        {
            tags = data.readTags();
            foreach (Tag t in tags)
            {
                displayTags.Add(t.TagName);
            }
            tagList.DataSource = displayTags;
            tagList.DataBind();
          
           
                
              

        }
        protected void ShowTransaction()
        {
            if (Session["transactionList"] != null)
            {
                transactionItems = (List<Transaction>)Session["transactionList"];
                cartCount.Text = transactionItems.Count.ToString();
            }
        }
        protected void EditMode()
        {
            try {
                editKey = Session["EditMode"].ToString();
            }
            catch(Exception)
            {
                return;
            }
            if (editKey.Equals("SoldProducts"))
            {
                createTag.Visible = false;
                productUpload.Text = "Edit Product";
                prod = (Product)Session["EditValue"];
                productID.Text = prod.ProductID;
                productName.Text=prod.ProductName;
                productDescription.Text=prod.ProductDescription;
                productPic=prod.ProductPic;
                productQuantity.Text = prod.ProductQuantity.ToString();
                productPrice.Text = prod.ProductPrice.ToString();
                uploadedPicture.ImageUrl = "data:image/jpg;base64," + prod.ProductPic;
                productDate.Text = prod.ProductDate.ToString("yyyy-MM-dd");
                tags = data.readTags();
                string[] chosenTags = new string[3];
                foreach (Tag t in tags)
                {
                    if (t.TagID.Equals(prod.ProductCategoryA))
                    {
                        chosenTags[0] = t.TagName;
                    }
                    if (t.TagID.Equals(prod.ProductCategoryB))
                    {
                        chosenTags[1] = t.TagName;
                    }
                    if (t.TagID.Equals(prod.ProductCategoryC))
                    {
                        chosenTags[2] = t.TagName;
                    }
                }
                foreach (ListItem item in tagList.Items)
                {
                  
                    
                    if (item.Text.Equals(chosenTags[0]))
                    {
                        item.Selected = true;
                    }
                    if (item.Text.Equals(chosenTags[1]))
                    {
                        item.Selected = true;
                    }
                    if (item.Text.Equals(chosenTags[2]))
                    {
                        item.Selected = true;
                    }
                }

            }
            else if(editKey.Equals("Tag"))
            {
                UploadProduct.Visible = false;
            }
            else
            {
                return;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            credentialCheck();

            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";

          
            LoadPictures();
            productDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            productID.Text = "PRODUCT" + generateID(5);
            TagID.Text = "TAG" + generateID(9);
            
            if(!IsPostBack)
            {
               
                LoadTags();
                ShowTransaction();
                EditMode();
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

        protected void uploadPicture_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Files/");
            
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            
            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

            uploadedPicture.ImageUrl = "~/Files/" + Path.GetFileName(FileUpload1.FileName);
            productPic = folderPath + Path.GetFileName(FileUpload1.FileName);

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void submitProductButton_Click(object sender, EventArgs e)
        {
            int[] chosenIndex = new int[3];
            int i=0;
            int j = 0;
            foreach (ListItem item in tagList.Items)
            {
                
                if (item.Selected)
                {
                    chosenIndex[j] = i;
                    chosenTags.Add(item.ToString());
                    j++;
                }
                i++;
            }
           if(chosenTags.Count>3)
            {
                Chosen.Text = "Please Choose Again";
            }
           else
            {
                string[] chosenIDs=new string[3];
                Chosen.Text = "Chosen Tags are";
                int h=0;
                foreach(string ch in chosenTags)
                {
                    Chosen.Text = Chosen.Text + " " + ch;
                    if (ch.Equals(tags.ElementAt(chosenIndex[h]).TagName))
                    {
                        chosenIDs[h] = tags.ElementAt(chosenIndex[h]).TagID;
                        h++;
                    }
                }
                prod = new Product();
                prod.ProductID = productID.Text;
                prod.ProductName = productName.Text;
                prod.ProductDescription = productDescription.Text;
                prod.ProductPic = productPic;
                prod.ProductQuantity = Convert.ToInt32(productQuantity.Text);
                prod.ProductPrice = Convert.ToDouble(productPrice.Text);
                prod.ProductCategoryA = chosenIDs[0];
                prod.ProductCategoryB = chosenIDs[1];
                prod.ProductCategoryC = chosenIDs[2];
                prod.UserID = user.Id;
                prod.ProductDate = DateTime.Now;
                data.sellProduct(prod);

            }
        }

        protected void clearProductButton_Click(object sender, EventArgs e)
        {
            productDescription.Text = "";
            productName.Text = "";
            productPrice.Text = "";
            productQuantity.Text = "";
            uploadedPicture.ImageUrl = "";
            foreach(ListItem li in tagList.Items)
            {
                if(li.Selected)
                {
                    li.Selected = false;
                }
            }
        }

        protected void tagSubmitButton_Click(object sender, EventArgs e)
        {
            Tag t = new Tag();
            t.UserID = user.Id;
            t.TagID = TagID.Text;
            t.TagName = TagName.Text;
            t.TagDescription = TagDescription.Text;
            t.TagDate = DateTime.Now;
            data.uploadTag(t);
            LoadTags();
        }

        protected void tagClearButton_Click(object sender, EventArgs e)
        {
            TagName.Text = "";
            TagDescription.Text = "";
           
        }
    }
}