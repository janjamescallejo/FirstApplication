<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="FirstApplication.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Accounts</title>
    <style type="text/css">
        
        #Button1 {
            width: 147px;
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
            width: 100;
           
        }


        .bottom {
            top: 907px;
            left: -2px;
             width: 2014px;
            height: 204px;
        }


        .auto-style5 {
            top: 171px;
            left: 485px;
            width: 320px;
            height: 471px;
        }

        .auto-style6 {
            top: 150px;
            left: 32px;
            height: 173px;
            width: 451px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="top" runat="server">
         <a href="WebForm1.aspx"><asp:Image ID="Image1" runat="server" style=" position:fixed; margin-top:0; top: 12px; left: 10px; height: 75px; width: 137px; " /></a>
   
        <div class="menubar" id="menu" runat="server">
        <a href="#Buy">Buy</a>
        <a href="#Sell">Sell</a>
         <a href="#about">About Us</a>
        <a href="Webform4.aspx">Account</a>
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
       
        <div id="AccountInfo" class="auto-style6" style="position: absolute; background-color: #0000FF; color: #FFFFFF;">
            <asp:Label ID="AccountInfo_AccountName" runat="server" style="position:absolute; top: 32px; left: 37px; height: 25px; width: 105px;"></asp:Label>
            <asp:Label ID="AccountInfo_AccountID" runat="server" Text="" style="position:absolute; top: 71px; left: 39px;"></asp:Label>
            <asp:Label ID="AccountInfo_AccountDate" runat="server" style="position:absolute; top: 116px; left: 36px;"></asp:Label>
        </div>
       
        <asp:Button ID="EditButton" runat="server" Text="Edit" style="position:absolute; top: 349px; left: 337px; width: 59px; height: 21px; right: 380px;" OnClick="EditButton_Click"/>
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" style="position:absolute; top: 344px; left: 426px;" OnClick="DeleteButton_Click"/>
       
       </form>
</body>
</html>
