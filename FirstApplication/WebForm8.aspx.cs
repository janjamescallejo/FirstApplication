using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        UserAccount user;
        static List<Transaction> transactionItems = new List<Transaction>();
        static string productName;
        Database data = new Database();
        Product product = new Product();
        static List<Comment> comments;
        Random random = new Random();
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
        protected string generateID(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            credentialCheck();
            CopyrightLabel.Text = "©" + DateTime.Now.ToString("yyyy") + " Jan James Callejo All Rights Reserved";
           
            LoadPictures();
            productName = Session["ViewedProduct"].ToString();
            product = data.showProduct(productName);
            LoadProduct();
            this.Title = productName;
            if (!IsPostBack)
            {
                ShowTransaction();
                LoadComments();
            }
        }
        protected void LoadProduct()
        {
            productLabel.Text = product.ProductName;
            productQuantity.Text = productQuantity.Text + product.ProductQuantity;
            productPrice.Text = productPrice.Text + product.ProductPrice;
            productDescription.Text = product.ProductDescription;
            productDate.Text = productDate.Text + product.ProductDate.ToString("MMMM dd, yyyy");
            productImage.ImageUrl = "data:image/jpg;base64," + product.ProductPic;
            showTags();
        }
        protected void LoadComments()
        {
            comments = data.readComments(product.ProductID);
            showComments();
        }
        protected void showTags()
        {
            List<Tag> tags = new List<Tag>();
            tags = data.readTags();
            foreach(Tag t in tags)
            {
                if(t.TagID.Equals(product.ProductCategoryA))
                {
                    productTags.Text = productTags.Text +t.TagName+ ", ";
                    product.ProductCategoryA = t.TagName;
                }
                if (t.TagID.Equals(product.ProductCategoryB))
                {
                    productTags.Text = productTags.Text + t.TagName + ", ";
                    product.ProductCategoryB = t.TagName;
                }
                if (t.TagID.Equals(product.ProductCategoryC))
                {
                    productTags.Text = productTags.Text +"and "+ t.TagName;
                    product.ProductCategoryC = t.TagName;
                }
            }
            showSeller();
        }
        protected void showSeller()
        {
            UserAccount seller = data.ShowAccount(product.UserID);
            productSeller.Text = productSeller.Text + seller.UName;
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string[] searchInputs = new string[2];
            searchInputs[0] = "Purple";
            searchInputs[1] = "Products";
            Session["searchInputs"]=searchInputs;
            Page.ClientScript.RegisterStartupScript(
this.GetType(), "OpenWindow", "window.open('WebForm6.aspx','_newtab');", true);

        }

        protected void cartButton_Click(object sender, EventArgs e)
        {
            Session["chosenProduct"] = product;
            Response.Redirect("WebForm7.aspx");
        }
        protected void commentList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            /*
            var produ = (Product)e.Item.DataItem;
            Image productImage = e.Item.FindControl("Image2") as Image;
            Label dateLabel = e.Item.FindControl("Label6") as Label;
            LinkButton productName = e.Item.FindControl("LinkButton1") as LinkButton;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                productImage.ImageUrl = "data:image/jpg;base64," + produ.ProductPic;
                dateLabel.Text = produ.ProductDate.ToString("yyyy-MM-dd");
                productName.Text = produ.ProductName;
            }*/
        }
        protected void showComments()
        {
            commentList.DataSource = comments;
            commentList.DataBind();
        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (commentList.FindControl("commentDataPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            showComments();
           
        }

        protected void commentClear_Click(object sender, EventArgs e)
        {
            commentContent.Text = "";
        }

        protected void commentSend_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment();
            comment.CommentID = "COMMENT" + generateID(5);
            comment.CommentContent = commentContent.Text;
            comment.ProductID = product.ProductID;
            comment.UserID = user.Id;
            comment.Upvotes = 0;
            comment.Downvotes = 0;
            comment.Datecreated = DateTime.Now;
            data.insertComment(comment);
        }
        protected void Upvote_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            var index = item.DataItemIndex;
            int ind = Convert.ToInt32(index);
            Comment ucom = comments.ElementAt(ind);
            ucom.Upvotes = ucom.Upvotes+1;
            data.upvoteComment(ucom);
            showComments();
        
        }
        protected void Downvote_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            var index = item.DataItemIndex;
            int ind = Convert.ToInt32(index);
            Comment dcom = comments.ElementAt(ind);
            dcom.Downvotes = dcom.Downvotes + 1;
            data.downvoteComment(dcom);
            showComments();

        }
    }
}