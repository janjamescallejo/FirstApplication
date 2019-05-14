<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="FirstApplication.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="shortcut icon" type="image/ico" href="/StoreLogoHead.png" />

    <title>About Us</title>
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

/* Change background on mouse-over */
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
<body>
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
 
       <div class="about us" style="position:absolute; top: 153px; left: 120px; width: 1091px; height: 122px; margin-top: 21px; background-color:blue; color:white;">
           <h1 class="aboutUsLabel" >ABOUT US</h1>
           <p class="aboutText" style="font-size:larger">This is the E-Commerce Site created solely by Jan James Callejo as a personal project to practice his skills and learn Web Development through ASP Webforms. This will cover a Cash-on-Delivery system of payment. In the future, we hope this evolves into a real e-commerce business operating 24/7.
           </p>
          
       </div>

        <div class="faq" style="position:absolute; top: 324px; left: 121px; height: 498px; width: 1085px; background-color:blue; color:white;">
        <h1 class="faqLabel">FAQ</h1>
         <h2>A. How to Buy</h2>
            <ol>
                <li>Click the Buy Menu</li>
                 <li>Choose an item by clicking Add</li>
                 <li>Click the Cart Menu</li>
                 <li>Click the Quantify Button</li>
                <li>Type the Cash Amount</li>
                <li>Click the Compute Amount Button</li>
                <li>Click the Compute Amount</li>
             </ol>
        </div>

        <div class="bottom" style="position: absolute; background-color: #000000; color: #FFFFFF;">
       
            <asp:Label ID="CopyrightLabel" runat="server" style="position:absolute; top: 101px; left: 543px;"></asp:Label>
       
        </div>
      
    </form>
</body>
</html>
