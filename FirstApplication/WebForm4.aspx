﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="FirstApplication.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="shortcut icon" type="image/ico" href="/StoreLogoHead.png" />
    <title>Accounts</title>
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
        table, td, tr, th{

         border: 1px solid black;
         border-collapse:collapse;
        }

        </style>
</head>
<body style="overflow-x:hidden;">
    <form id="form1" runat="server">
        <div id="AccountsList" style="position:absolute;  top: 164px; left: 456px; width: 286px; height: 409px; background-color:blue; color:white;" runat="server">
        <asp:Label ID="ListName" runat="server" Text="" style="position:absolute; top: 15px; left: 29px;"></asp:Label>    
            <asp:ListBox ID="SelectedBox" runat="server" style="position:absolute; top: 47px; left: 25px; width: 231px; height: 332px;" OnSelectedIndexChanged="SelectedBox_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
        </div>
        
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
       
        <div id="AccountInfo"  style="position: absolute; background-color: #0000FF; color: #FFFFFF; top: 161px; left: 42px; height: 247px; width: 326px; margin-bottom: 3px;">
            <asp:Label ID="AccountInfo_AccountName" runat="server" style="position:absolute; top: 64px; left: 31px; height: 25px; width: 185px;"></asp:Label>
            <asp:Label ID="AccountInfo_AccountID" runat="server" Text="" style="position:absolute; top: 108px; left: 34px; width: 176px;"></asp:Label>
            <asp:Label ID="AccountInfo_AccountDate" runat="server" style="position:absolute; top: 147px; left: 37px;"></asp:Label>
       <asp:Button ID="EditButton" runat="server" Text="Edit" style="position:absolute; top: 196px; left: 34px; width: 59px; height: 21px; right: 233px;" OnClick="EditButton_Click"/>
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" style="position:absolute; top: 192px; left: 163px; margin-bottom: 0px;" OnClick="DeleteButton_Click"/>
        
            <asp:Label ID="Label1" runat="server" Text="User Information" style="position:absolute; top: 14px; left: 19px; width: 136px;"></asp:Label>
        
        </div>
       
        <div id="UserControls" style="position:absolute; background-color:blue; color:white; top: 454px; left: 39px; height: 277px; width: 306px;">
        
        <asp:Button ID="SBPButton" runat="server" Text="Check Bought Products" style="position:absolute; top: 122px; left: 49px; margin-top: 4px;"/>
        
        <asp:Button ID="SSPButton" runat="server" Text="Check Sold Products" style="position:absolute; top: 76px; left: 49px; width: 207px;" OnClick="SSPButton_Click"/>
        
        <asp:Button ID="SATButton" runat="server" Text="Check Your Tags" style="position:absolute; top: 166px; left: 48px; width: 210px; height: 26px; margin-top: 2px;" OnClick="SATButton_Click"/>
            <asp:Label ID="Label2" runat="server" Text="User Controls" style="position:absolute; top: 24px; left: 112px;"></asp:Label>
        
        <asp:Button ID="SACButton" runat="server" Text="Check Your Comments" style="position:absolute; top: 206px; left: 49px; width: 208px;" />
        
        </div>
        <div id="userChoice" runat="server" style="position:absolute; background-color:blue; color:white; top: 166px; left: 816px; height: 281px; width: 439px;">
            <asp:Button ID="chosenEdit" runat="server" Text="Edit" style="position:absolute; top: 239px; left: 382px;" OnClick="chosenEdit_Click"/>
            <div id="ProductTable" runat="server" style="position:absolute; top: 41px; left: 27px; height: 167px; width: 389px; background-color:white; color:blue;" Visible="false">
                <table style="width: 99%; height: 162px; " >
                    <tr>
                        <th colspan="6">Chosen Product</th>
                    </tr>
                     <tr>
                        <th>ID</th>
                        <td colspan="4"><asp:Label ID="chosenProductID" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        
                       <th>Image</th>
                        <th>Name</th>
                        <th>Tags</th>
                        <th>Quantity</th>
                        <th>Price</th>
                    </tr>
                   
                    <tr>

                        <td>
                            <asp:Image ID="chosenProductPicture" runat="server" style=" height: 60px; width: 54px;"/>
                            </td>
                        <td>
                            <asp:Label ID="chosenProductName" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="chosenProductTags" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="chosenProductQuantity" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="chosenProductPrice" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    </table>
            </div>
            <asp:Button ID="chosenDelete" runat="server" Text="Delete" style="position:absolute; top: 239px; left: 313px;"/>
            <div id="TagTable" runat="server" style="position:absolute; top: 41px; left: 27px; height: 167px; width: 389px; background-color:white; color:blue;" Visible="false">
            <table>
                <tr>
                    <th colspan="3">Chosen Tag</th>
                    </tr>
                <tr>
                    <th>Tag ID</th>
                    <th>Tag Name</th>
                    <th>Tag Description</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="chosenTagID" runat="server" Text="Label"></asp:Label></td>
                    <td>
                        <asp:Label ID="chosenTagName" runat="server" Text="Label"></asp:Label></td>
                    <td>
                        <asp:Label ID="chosenTagDescription" runat="server" Text="Label"></asp:Label></td>

                    </tr>
                </table>
            </div>
        </div>
        <div id="AdminControls" runat="server" style="position:absolute; background-color:blue; color:white; top: 506px; left: 828px; height: 290px; width: 239px;">
            <asp:Label ID="Label3" runat="server" Text="Admin Controls" style="position:absolute; top: 28px; left: 75px;"></asp:Label>
            <asp:Button ID="MAButton" runat="server" Text="Make Announcements" style="position:absolute; top: 68px; left: 40px; width: 173px;"/>
            <asp:Button ID="SAAButton" runat="server" Text="See All Accounts" style="position:absolute; top: 116px; left: 40px; width: 171px;"/>
            <asp:Button ID="SAPButton" runat="server" Text="See All Products" style="position:absolute; top: 170px; left: 44px; width: 166px;"/>
            <asp:Button ID="MAAButton" runat="server" Text="Make An Admin" style="position:absolute; top: 224px; left: 45px; width: 163px;"/>
        </div>
       </form>
</body>
</html>
