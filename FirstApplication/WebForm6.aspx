<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="FirstApplication.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buy</title>
    <style type="text/css">
        
        #Button1 {
            width: 173px;
            margin-left: 1px;
        }
        #Button2 {
            width: 125px;
            margin-left: 1px;
            text-align: left;
        }
        .top
        {
            overflow:hidden;
           z-index:3;
           top:0;
            height: 101px;
            position:fixed;
             background-color: blue;
            left: 0px;
            width: 2000px;
        }
        .menubar {
            overflow:hidden;
             background-color: blue;
             position: fixed; 
    top: 45px; 
    width: 49%;
            left: 152px;
            z-index:3;
            right: 516px;
        }

.menubar a {
    float: left;
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
            
        }
.menubar a:hover {
    background: #ddd;
    color: deepskyblue;
}


        #form1 {
           
            margin-top: 98px; 
            height: 1000px;
          
           
        }


        .bottom {
            top: 907px;
            left: -2px;
             width: 2014px;
            height: 204px;
        }
       
        .auto-style1 {}
       
        </style>
</head>
<body style="overflow-x:hidden;">
    <form id="form1" runat="server">
     <div class="top" runat="server">
         <a href="WebForm1.aspx"><asp:Image ID="Image1" runat="server" style=" position:fixed; margin-top:0; top: 12px; left: 10px; height: 75px; width: 137px; " /></a>
   
        <div class="menubar" id="menu" runat="server">
        <a href="Webform6.aspx">Buy</a>
        <a href="Webform5.aspx">Sell</a>
         <a href="#about">About Us</a>
        <a href="Webform4.aspx">Account</a>
             <a href="Webform7.aspx">Cart[<asp:Label ID="cartCount" runat="server" Text="0"></asp:Label>]</a>

                 </div>
         <div class="UserBox" style="border: thick double #FFFFFF; position: fixed; height: 70px; top: 9px; width: 228px; color:white; background-color:blue; right: 42px;" runat="server" visible="true">
            
             <asp:Label ID="UName" runat="server"></asp:Label>
                <asp:Button ID="LogInButton1" runat="server" OnClick="LogInButton1_Click" Text="Log In" style="position:fixed; top: 45px; left: 1078px; width: 57px; "/>
                        
             <asp:Button ID="SignUpButton1" runat="server" Text="Sign Up" style="position:fixed; top: 45px; left: 1158px; width: 58px; right: 618px;" OnClick="SignUpButton1_Click"/>
               <asp:Button ID="LogOutButton1" runat="server" Text="Log Out" style="position:fixed; top: 44px; left: 1218px;" visible="false" OnClick="LogOutButton1_Click"/>

            
         </div>
      </div>
        
        <div class="bottom" style="position: absolute; background-color: #000000; color: #FFFFFF;">
       
            <asp:Label ID="CopyrightLabel" runat="server" style="position:absolute; top: 101px; left: 543px;"></asp:Label>
       
        </div>
        <div id="tagFilter" style="position:absolute; background-color:blue; color:white; top: 135px; left: 30px; width: 236px; height: 574px;">
            <asp:Label ID="Label1" runat="server" Text="Tags" style="position:absolute; font-size:larger; top: 19px; left: 37px; width: 73px;"></asp:Label>
            <asp:CheckBoxList ID="tagList" runat="server" style="position:absolute; top: 58px; left: 21px; height: 412px; width: 176px;">
            </asp:CheckBoxList>
            <asp:Button ID="tagFilterButton" runat="server" Text="Filter" style="position:absolute; top: 499px; left: 20px; width: 185px;" OnClick="tagFilterButton_Click"/>
        </div>
        <div id="productBox" style="position: absolute; background-color: blue; color: white; top: 136px; left: 336px; width: 730px; height: 746px;">
            <asp:TextBox ID="Searchbox" runat="server" style="position:absolute; top: 57px; left: 135px; width: 424px;"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" Text="Search" style="position:absolute; margin-left: 20px; top: 57px; left: 559px; height: 24px;" Width="83px" OnClick="Button5_Click"/>
            <asp:DropDownList ID="searchOptionList" runat="server" style="position:absolute; top: 58px; left: 37px;">
                <asp:ListItem>Products</asp:ListItem>
                <asp:ListItem>Seller</asp:ListItem>
            </asp:DropDownList>
             <asp:DropDownList ID="sortList" runat="server" style="position:absolute; top: 88px; left: 404px;" >
                <asp:ListItem>Date: Oldest to Newest</asp:ListItem>
                <asp:ListItem>Date: Newest to Oldest</asp:ListItem>
                 <asp:ListItem>Name: Ascending</asp:ListItem>
                <asp:ListItem>Name: Descending</asp:ListItem>
                 <asp:ListItem>Quantity: Ascending</asp:ListItem>
                <asp:ListItem>Quantity: Descending</asp:ListItem>
                 <asp:ListItem>Price: Ascending</asp:ListItem>
                <asp:ListItem>Price: Descending</asp:ListItem>
                 <asp:ListItem>Seller: Ascending</asp:ListItem>
                <asp:ListItem>Seller: Descending</asp:ListItem>
            </asp:DropDownList>
             <asp:Button ID="sortProductsButton" runat="server" Text="Sort" style="position:absolute; top: 89px; left: 581px; width: 78px; height: 20px;" OnClick="sortProductsButton_Click"/>  
            <asp:Label ID="productBoxlabel" runat="server" Text="All Products" style="position:absolute; top: 20px; left: 42px; height: 31px; width: 378px; font-size:large;"></asp:Label>
            <div id="productContainer" runat="server" style="position:absolute; background-color:white; color:blue; top: 118px; left: 40px; height: 606px;">
                <asp:ListView ID="productList" runat="server" OnItemDataBound="productList_ItemDataBound"  OnPagePropertiesChanging="OnPagePropertiesChanging">
                    <layouttemplate>
                        <table >
                           
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                <tr>
                    
                 <td >
                    <asp:DataPager ID="productDataPager" runat="server" PagedControlID="productList" PageSize="4">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" />
                            <asp:NumericPagerField ButtonType="Link" />
                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false"
                                ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                        </td>
                    </tr>
          

                        </table>
                        </layouttemplate>
                   
                    <itemTemplate>
                        
                            <tr>
                                <td rowspan="3">
                                    <asp:Image ID="Image2" runat="server" style="height:80px; width:70px;"/></td>
                                <td ><%# Eval("ProductName")%></td>
                                
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>

                                </tr>
                              <tr>
                                  <td>Sold By: <%#Eval("UserID") %> </td>
                              </tr>
                              <tr>
                                  <td >
                                 Tags: <%#Eval("ProductCategoryA") %>, <%#Eval("ProductCategoryB") %> , and <%#Eval("ProductCategoryC") %>
                              </td>
                                      </tr>
                              <tr >
                                  <td >Quantity: <%# Eval("ProductQuantity") %> </td>
                                  <td>Price: <%#Eval("ProductPrice") %></td>
                                  <td><asp:Button ID="Button2" runat="server" onclick="Button1_Click" Text="Add" style="height:20px;"/></td>
                                  <td>
                                      <asp:Label ID="Label4" runat="server" Text="" Visible="false"></asp:Label></td>
                                </tr>
                        <tr>
                            <td colspan="4">
                            <div style="height:3px; background-color:blue; width:610px;"></div>
                            </td>
                                </tr>
                               
                        
                        </itemTemplate>
                </asp:ListView>
            </div>
            
        </div>
    </form>
</body>
</html>
