<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="FirstApplication.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="shortcut icon" type="image/ico" href="/StoreLogoHead.png" />
    <title>Terms and Conditions</title>

    <style type="text/css">
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

/* Change background on mouse-over */
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
<body style="background-color:white; overflow-x:hidden;">
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
       
        <asp:TextBox ID="TermsAndConditions" runat="server" style="position:absolute; top: 252px; left: 364px; width: 452px; height: 427px;" Enabled="False" TextMode="MultiLine"></asp:TextBox>
       
        <asp:Label ID="TaCBanner" runat="server" Text="Terms and Conditions" style="position:absolute; color:blue; top: 163px; left: 326px; width: 838px; height: 58px; font-size:60px; margin-top: 0px;"></asp:Label>
       
    </form>
</body>
</html>
