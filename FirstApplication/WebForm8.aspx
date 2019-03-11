<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="FirstApplication.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        #Button1 {
            width: 104px;
            margin-left: 1px;
        }
        #Button2 {
            width: 125px;
            margin-left: 1px;
            text-align: left;
        }
        .top
        {
            overflow-y:hidden;
           z-index:3;
           top:0;
            height: 101px;
            position:fixed;
             background-color: blue;
            left: 0px;
            width: 2000px;
        }
        .menubar {
            overflow-y:hidden;
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



        .auto-style4 {
            top: 633px;
            left: 48px;
            width: 938px;
            height: 239px;
        }


        .bottom {
            top: 907px;
            left: -2px;
             width: 2014px;
            height: 204px;
        }


    </style>
</head>
<body style="background-color:white; overflow-x:hidden">
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
         <div class="UserBox" style="border: thick double #FFFFFF; position: fixed; height: 70px; top: 9px; width: 228px; color:white; background-color:blue; right: 42px;" runat="server" visible="true" >
            
             <asp:Label ID="UName" runat="server"></asp:Label>
          
             <asp:Button ID="LogInButton1" runat="server" OnClick="LogInButton1_Click" Text="Log In" style="position:fixed; top: 45px; left: 1078px; width: 57px; "/>
                        
             <asp:Button ID="SignUpButton1" runat="server" Text="Sign Up" style="position:fixed; top: 45px; left: 1158px; width: 58px; right: 618px;" OnClick="SignUpButton1_Click"/>

             <asp:Button ID="LogOutButton1" runat="server" Text="Log Out" style="position:fixed; top: 44px; left: 1218px;" visible="false" OnClick="LogOutButton1_Click"/>
            
                        
         </div>
      </div>
         <div class="bottom" style="position: absolute; background-color: #000000; color: #FFFFFF;">
       
            <asp:Label ID="CopyrightLabel" runat="server" style="position:absolute; top: 101px; left: 543px;"></asp:Label>
       
        </div>
        <div id="productBox" style="position:absolute; background-color:blue; color:white; top: 140px; left: 63px; height: 439px; width: 760px; margin-top: 0px;">
            
            <asp:Label ID="productLabel" runat="server" Text="Label" style="position:absolute; top: 38px; left: 287px; height: 40px; width: 436px; font-size:30px"></asp:Label>
            
            <asp:Label ID="productSeller" runat="server" Text="Sold By: " style="position:absolute; top: 84px; left: 287px; width: 200px; right: 273px;"></asp:Label>
            
            <asp:Image ID="productImage" runat="server" style="position:absolute; top: 48px; left: 44px; height: 296px; width: 228px;"/>
            
            <asp:TextBox ID="productDescription" runat="server" style="position:absolute; top: 138px; left: 288px; width: 421px; height: 178px;" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
            
            <asp:Label ID="productDate" runat="server" Text="Sold At: " style="position:absolute; top: 85px; left: 498px; width: 211px;"></asp:Label>
            
            <asp:Label ID="productQuantity" runat="server" Text="Quantity: " style="position:absolute; top: 348px; left: 291px; width: 144px;"></asp:Label>
            
            <asp:Label ID="productPrice" runat="server" Text="Price: " style="position:absolute; top: 349px; left: 469px; width: 199px;"></asp:Label>
            
            <asp:Button ID="cartButton" runat="server" Text="Add to Cart" style="position:absolute; top: 395px; left: 630px;" />
            
            <asp:Label ID="productTags" runat="server" Text="Tags: " style="position:absolute; top: 109px; left: 288px; right: 47px;"></asp:Label>
            
        </div>
    </form>
</body>
</html>
