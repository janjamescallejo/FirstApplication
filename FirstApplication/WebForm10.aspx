<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="FirstApplication.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delivery Details</title>
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
<body>
    <form id="form1" runat="server">
    
    <div class="top" runat="server">
         <a href="WebForm1.aspx"><asp:Image ID="Image1" runat="server" style=" position:fixed; margin-top:0; top: 12px; left: 10px; height: 75px; width: 137px; " /></a>
   
        <div class="menubar" id="menu" runat="server">
        <a href="Webform6.aspx">Buy</a>
        <a href="Webform5.aspx">Sell</a>
         <a href="Webform9.aspx">About Us</a>
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
             

        <div id="deliveryDetails" runat="server" style="position:absolute; background-color:blue; color:white; top: 176px; left: 167px; height: 715px; width: 774px;">
            <asp:Button ID="deliveryConfirm" runat="server" Text="Confirm Delivery" style="position:absolute; top: 666px; left: 573px; width: 138px; height: 28px;" OnClick="deliveryConfirm_Click" />
            <asp:Button ID="deliveryCancel" runat="server" Text="Cancel Delivery" style="position:absolute; top: 665px; left: 55px; height: 29px; width: 132px;" />
            <asp:Label ID="deliveryBanner" runat="server" Text="Items to be Delivered" style="position:absolute; top: 26px; left: 43px; height: 37px; width: 228px; margin-bottom: 0px; font-size:x-large"></asp:Label>
            <asp:TextBox ID="deliveryAddress" runat="server" style="position:absolute; top: 502px; left: 55px; height: 68px; width: 642px;" TextMode="MultiLine"></asp:TextBox>
           <asp:Label ID="Label1" runat="server" Text="Delivery Address" style="position:absolute; top: 475px; left: 55px; margin-bottom: 0px;"></asp:Label>
            <asp:Label ID="deliveryItems" runat="server" alt="to be filled in" Text="" style="position:absolute; top: 67px; left: 53px; height: 366px; width: 661px;"></asp:Label>
            <asp:Button ID="clearAddress" runat="server" Text="Clear" style="position:absolute; top: 595px; left: 56px; width: 95px; height: 29px;" OnClick="clearAddress_Click"/>
             <hr style="position:absolute; top: 455px; left: 4px; height: 11px; margin-bottom: 1px;"/>
           <asp:Button ID="confirmAddress" runat="server" Text="Confirm" style="position:absolute; top: 593px; left: 625px; height: 30px; width: 78px;"/>
             <hr />
        </div>
             

        
             

    </form>
</body>
</html>
