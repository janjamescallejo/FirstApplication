using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        List<string> pictures;
        List<string> chosenTags = new List<string>();
        static List<Tag> tags;
        List<string> displayTags = new List<string>();
        static List<Product> products;
        UserAccount user;
        Database data = new Database();
        Random random = new Random();
        static List<UserAccount> accounts;
        static string[] searchInputs = new string[2];
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
               // Response.Redirect("Webform1.aspx");
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
        protected void LoadProducts()
        {
            accounts = data.readAccounts();
            products = data.readProduct();
            foreach (Product p in products)
            {
                foreach (Tag t in tags)
                {
                    if (t.TagID.Equals(p.ProductCategoryA))
                    {
                        p.ProductCategoryA = t.TagName;
                    }
                    if (t.TagID.Equals(p.ProductCategoryB))
                    {
                        p.ProductCategoryB = t.TagName;
                    }
                    if (t.TagID.Equals(p.ProductCategoryC))
                    {
                        p.ProductCategoryC = t.TagName;
                    }

                }
                foreach(UserAccount a in accounts)
                {
                    if(p.UserID.Equals(a.Id))
                    {
                        p.UserID = a.UName;
                    }
                }
            }
            showProduct();
            
        }
        protected void searchProduct(string SearchQuery, string SearchOption)
        {
            if (SearchOption.Equals("Products"))
            {
                products = products.Where(o => o.ProductName.Contains(SearchQuery)).ToList();

            }
            if (SearchOption.Equals("Seller"))
            {
                products = products.Where(o => o.UserID.Contains(SearchQuery)).ToList();
            }
            showProduct();
        }
        protected void showProduct()
        {
            productList.DataSource = products;
            productList.DataBind();
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
            searchInputs = (string[])Session["searchInputs"];
           

            if (!IsPostBack)
            {
                LoadTags();
                LoadProducts();
                ShowTransaction();

            }
            if (searchInputs!=null)
            {
                searchProduct(searchInputs[0], searchInputs[1]);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (ListViewItem)btn.NamingContainer;
            var index = item.DataItemIndex;
            Label transactionSign = item.FindControl("Label4") as Label;
            if(user==null)
            {
                transactionSign.Visible = true;
                transactionSign.Text = "Can't";

            }
            else
            {
                Product chosenProduct = products.ElementAt(index);
                Session["chosenProduct"] = chosenProduct;
                Response.Redirect("WebForm7.aspx");
            }
        }

        protected void productList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var produ = (Product)e.Item.DataItem;
            Image productImage = e.Item.FindControl("Image2") as Image;
            Label dateLabel = e.Item.FindControl("Label6") as Label;
           
            if (e.Item.ItemType == ListViewItemType.DataItem) 
            {
                productImage.ImageUrl= "data:image/jpg;base64," + produ.ProductPic;
                dateLabel.Text = produ.ProductDate.ToString("yyyy-MM-dd");
            }

        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (productList.FindControl("productDataPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            showProduct();
        }

        protected void sortProductsButton_Click(object sender, EventArgs e)
        {
            string sortOption = sortList.Text;
            if(sortOption.Equals("Date: Oldest to Newest"))
            {
                products = products.OrderBy(o => o.ProductDate).ToList();

            }
            if (sortOption.Equals("Date: Newest to Oldest"))
            {
                products = products.OrderByDescending(o => o.ProductDate).ToList();

            }
            if (sortOption.Equals("Name: Ascending"))
            {
                products = products.OrderBy(o => o.ProductName).ToList();

            }
            if (sortOption.Equals("Name: Descending"))
            {
                products = products.OrderByDescending(o => o.ProductName).ToList();

            }
            if (sortOption.Equals("Quantity: Ascending"))
            {
                products = products.OrderBy(o => o.ProductQuantity).ToList();

            }
            if (sortOption.Equals("Quantity: Ascending"))
            {
                products = products.OrderByDescending(o => o.ProductQuantity).ToList();

            }
            if (sortOption.Equals("Price: Ascending"))
            {
                products = products.OrderBy(o => o.ProductPrice).ToList();

            }
            if (sortOption.Equals("Price: Descending"))
            {
                products = products.OrderByDescending(o => o.ProductPrice).ToList();

            }
            if (sortOption.Equals("Seller: Ascending"))
            {
                products = products.OrderBy(o => o.UserID).ToList();

            }
            if (sortOption.Equals("Seller: Descending"))
            {
                products = products.OrderByDescending(o => o.UserID).ToList();

            }
            showProduct();
        }

        protected void tagFilterButton_Click(object sender, EventArgs e)
        {
            List<Product> temp=new List<Product>();
            List<Product> temp2=new List<Product>();

            foreach (ListItem item in tagList.Items)
            {
                
                if (item.Selected)
                {
                    
                    chosenTags.Add(item.ToString());
                   
                }
              
            }
            int count=0;
            foreach(string t in chosenTags)
            {
                temp = products.Where(o => o.ProductCategoryA.Contains(t)||o.ProductCategoryB.Contains(t)||o.ProductCategoryC.Contains(t)).ToList();
                temp2.InsertRange(count, temp);
                count = temp.Count;
            }

            //products = temp2.Distinct().ToList();
            products = temp2;
            showProduct();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string SearchOption = searchOptionList.Text;
            string SearchQuery = Searchbox.Text;
            searchProduct(SearchQuery, SearchOption);
        }
    }
}