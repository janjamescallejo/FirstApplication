<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="FirstApplication.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In and Sign Up Page</title>
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
<body style="background-color:white; overflow-x:hidden">
    <form id="form1" runat="server">
        
        <div id="Registration" style="position: absolute; background-color: #0000FF; color: #FFFFFF; top: 171px; left: 485px; width: 320px; height: 471px;" runat="server">
            <asp:Label ID="Label5" runat="server" Text="User ID: " style="position:absolute; top: 77px; left: 40px;"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Register" style="position:absolute; top: 28px; left: 35px; width: 255px; height: 35px;" Font-Size="XX-Large"></asp:Label>
            <asp:Label ID="RegUserID" runat="server" style="position:absolute; top: 76px; left: 120px;"></asp:Label>
            <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="Username" style="position:absolute; top: 113px; left: 42px;"></asp:Label>
            <asp:TextBox ID="RUsername" runat="server" style="position:absolute; top: 144px; left: 41px; width: 168px;"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Password" style="position:absolute; top: 184px; left: 44px; width: 130px; height: 25px;" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="RPassword" runat="server" style="position:absolute; top: 220px; left: 42px; width: 164px;" TextMode="Password"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Confirm Password" style="position:absolute; top: 267px; left: 49px; width: 175px; height: 30px;" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="RConfirmPassword" runat="server" style="position:absolute; top: 302px; left: 43px; width: 163px;" TextMode="Password"></asp:TextBox>
            <asp:CheckBox ID="RAgreeToTerms" runat="server" style="position:absolute; top: 351px; left: 43px;"/><p id="RAgreeStatement" style="position:absolute; top: 334px; left: 68px; width: 165px; ">Agree to <a href="WebForm3.aspx" style="color:yellow;" runat="server" onclick="OpenTerms">Terms</a></p> 
            <asp:Button ID="LogInButton3" runat="server" Text="Clear" style="position:absolute; top: 387px; left: 45px; width: 89px;" OnClick="LogInButton3_Click"/>
            <asp:Button ID="LogInButton2" runat="server" Text="Submit" style="position:absolute; top: 388px; left: 175px; width: 77px;" OnClick="LogInButton2_Click"/>
            <asp:Label ID="RWarning" runat="server" ForeColor="Yellow" style="position:absolute; top: 436px; left: 53px;" Visible="false"></asp:Label>
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
       
        <div class="SignIn" style="position: absolute; top: 171px; left: 75px; height: 360px; width: 301px; background-color: #0000FF; color: #FFFFFF;" runat="server">
            <asp:Label ID="SignInLabel1" runat="server" Text="Sign In " style="position:absolute; top: 23px; left: 30px; width: 251px; height: 54px;" Font-Size="XX-Large"></asp:Label>
            <asp:Label ID="SignInLabel2" runat="server" Text="Username" style="position:absolute; top: 96px; left: 38px; width: 130px; height: 33px;" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="SIUsername" runat="server" style="position:absolute; top: 132px; left: 43px; width: 208px; height: 20px;"></asp:TextBox>
            <asp:Label ID="SignInLabel3" runat="server" Text="Password" style="position:absolute; top: 177px; left: 42px; width: 98px;" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="SIPassword" runat="server" style="position:absolute; top: 211px; left: 46px; width: 207px;" TextMode="Password"></asp:TextBox>
            <asp:Button ID="SignInButton3" runat="server" Text="Clear" style="position:absolute; top: 261px; left: 48px; width: 79px; right: 174px;" OnClick="SignInButton3_Click"/>
            <asp:Button ID="SignInButton2" runat="server" Text="Submit" style="position:absolute; top: 260px; left: 167px; width: 78px;" OnClick="SignInButton2_Click"/>
            <asp:Label ID="SIWarning" runat="server" style="position:absolute; top: 300px; left: 24px; width: 266px;" Visible="False" ForeColor="Yellow"></asp:Label>
        </div>
       
      
       
      
       
    </form>
</body>
</html>
