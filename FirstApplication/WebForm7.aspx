<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="FirstApplication.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="shortcut icon" type="image/ico" href="/StoreLogoHead.png" />
    <title>Transaction</title>
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
        <asp:Label ID="transactionLabel" runat="server" Text="" style="position:absolute; color:blue; font-size:x-large; top: 124px; left: 100px; width: 200px; height: 35px;"></asp:Label>
        <div id="transactionBox" runat="server" style="position:absolute; background-color:blue; color:white; top: 179px; left: 105px; width: 615px; height: 703px;">
        <div id="transactionContainer" runat="server" style="background-color: white; color:blue; position:absolute; top: 108px; left: 35px; width: 545px; height: 570px;">
        <asp:ListView ID="transactionList" runat="server" OnItemDataBound="transactionList_ItemDataBound">
            <layouttemplate>
            <table border="1" style="border-collapse:collapse">
                <tr>
                    <th>Product Picture</th>
                    <th>Product Name</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Total Price</th>
                    <th>Action</th>

                    </tr>
                <tr>
                            <td>
                               <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                            <td>
                                </tr>
                <tr>
                    
                 <td >
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="transactionList" PageSize="5">
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
                    <td rowspan="2">
                        <asp:Image ID="Image2" runat="server" style="height:70px; width:60px"/></td>
                    <td>
                        
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="productDetailView"></asp:LinkButton>
                    </td>
                    <td><asp:DropDownList ID="itemQuantity" runat="server" OnSelectedIndexChanged="itemQuantity_SelectedIndexChanged" ></asp:DropDownList></td>
                    <td><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
                    <td>
                        <asp:Button ID="RemoveButton" runat="server" Text="Remove" OnClick="RemoveButton_Click"/></td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Tags: "></asp:Label></td>
                    <td>
                        <asp:Button ID="quantityButton" runat="server" Text="Quantify" onclick="quantityButton_Click"/></td>
                    </tr>
                
                
                </itemTemplate>
        </asp:ListView>
            </div>
            <asp:Label ID="transactionID" runat="server" Text="Transaction ID: " style="position:absolute; font-size:larger; top: 56px; left: 40px;"></asp:Label>
            </div>
        <div id ="transactionTotalBox" runat="server" style="position:absolute; top: 181px; left: 881px; height: 216px; width: 350px; background-color:blue; color:white;">
            <asp:Label ID="totalPriceLabel" runat="server" Text="Total Price" style="position:absolute; top: 29px; left: 35px; width: 248px;"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="Expected Cash: " style="position:absolute; top: 61px; left: 39px;"></asp:Label>
            <asp:TextBox ID="transactionCash" runat="server" style="position:absolute; top: 60px; left: 155px;" ></asp:TextBox>
            <asp:Label ID="transactionChangeLabel" runat="server" Text="Expected Change: " style="position:absolute; top: 95px; left: 38px; width: 244px;"></asp:Label>
            <asp:Button ID="transactionConfirmButton" runat="server" Text="Confirm" style="position:absolute; top: 136px; left: 236px; width: 75px;" OnClick="transactionConfirmButton_Click"/>
            <asp:Button ID="transactionCancelButton" runat="server" Text="Cancel" style="position:absolute; top: 134px; left: 36px; width: 65px;" OnClick="transactionCancelButton_Click" />
            <asp:Button ID="transactionComputeButton" runat="server" Text="Compute" style="position:absolute; top: 135px; left: 129px; width: 75px;" OnClick="transactionComputeButton_Click" />
            <asp:Label ID="transactionStatus" runat="server" Text="" style="position:absolute; top: 177px; left: 34px; width: 279px;" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
