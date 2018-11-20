<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FirstApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Store</title>
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
            width: 100;
           
        }


        .auto-style1 {}


        .auto-style3 {}


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
<body style="background-color:white; ">

    <form id="form1" runat="server" >        
     
   
    <div class="top" runat="server">
         <a href="WebForm1.aspx"><asp:Image ID="Image1" runat="server" style=" position:fixed; margin-top:0; top: 12px; left: 10px; height: 75px; width: 137px; " /></a>
   
        <div class="menubar" id="menu" runat="server">
        <a href="#Buy">Buy</a>
        <a href="#Sell">Sell</a>
         <a href="#about">About Us</a>
        <a href="Webform2.aspx">Account</a>
                 </div>
         <div class="UserBox" style="border: thick double #FFFFFF; position: fixed; height: 70px; top: 9px; width: 228px; color:white; background-color:blue; right: 42px;" runat="server" visible="true" >
            
             <asp:Label ID="UName" runat="server"></asp:Label>
          
             <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Log In" style="position:fixed; top: 45px; left: 1078px; width: 57px; "/>
                        
             <asp:Button ID="Button4" runat="server" Text="Sign Up" style="position:fixed; top: 45px; left: 1158px; width: 58px; right: 618px;" OnClick="Button4_Click"/>

             <asp:Button ID="Button6" runat="server" Text="Log Out" style="position:fixed; top: 44px; left: 1218px;" visible="false" OnClick="Button6_Click"/>
            
                        
         </div>
      </div>
 
   
<div runat="server"  id="LoginForm" style="border: thick double #000000; position: absolute; padding: inherit; background-color: #0000FF; margin-left: inherit; margin-right: inherit; margin-top: 0px; margin-bottom: inherit; top: 154px; color: #FFFFFF; right: 48px;" >
    <p style="color: #FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp; Log In</p>
    <p style="color: #FFFFFF" >&nbsp;&nbsp; Username:</p>
    <asp:TextBox runat="server" id="Username" style="margin-left: 16px" /> 
    <br /><br />
    &nbsp;&nbsp;
    <p style="color: #FFFFFF" >&nbsp;&nbsp;&nbsp; Password:</p>
    <asp:TextBox runat="server" id="Password" style="margin-left: 15px" /> 
    <br /><br />
    <br /><br />
    <asp:Button runat="server" id="Submit" text="Submit" OnClick="Submit_Click" style="margin-left: 15px" />
    <asp:Button runat="server" id="Register" text="Register" OnClick="Register_Click" style="margin-left: 30px" Width="73px" />
    <br /><br />
    <asp:Label ID="Combined" runat="server" ForeColor="White" style="margin-left: 18px" Width="165px"></asp:Label>
    
</div>
   

         

        
      
       
       


         
        
       
       
       


         

        
      
       
       


         
        
        
       
       


         

        
      
       
       


         
        
        <div class="featured" style="position: absolute; width: 938px; top: 149px; left: 45px; height: 434px; background-color:blue;">
             <asp:Image ID="Image2" runat="server" CssClass="auto-style3" style="position:absolute; top: 26px; left: 58px; width: 265px; height: 80px;"/>
            <div runat="server" id="Product1" style="border-color: white; border-style: solid; width: 257px; position: absolute; left: 73px; height: 284px; background-color: blue; margin-top: 0px; top: 125px; color:white; ">
        
           
     
       
        
           
     
            <asp:Label ID="ItemName1" runat="server" style="position:absolute; top: 29px; left: 26px; height: 22px; width: 186px;"></asp:Label>
        
           
     
       
        
     
     
              <asp:Label ID="ItemPrize1" runat="server" style="position:absolute; top: 240px; left: 33px; width: 158px; height: 23px;"></asp:Label>
           
     
       
        
           
     
            <asp:Label ID="ItemQuantity1" runat="server" style="position:absolute; top: 201px; left: 29px; height: 24px; width: 167px;"></asp:Label>
        
           
     
       
        
     
     
            <asp:Image ID="ProductImage1" runat="server" style="position:absolute; top: 64px; left: 26px; height: 114px; width: 181px;"/>
        
           
     
           
     
        </div>



        
   
        
         <div id="Product2" runat="server" style="border-color: white; position: absolute; background-color:blue; color:white; border-style: solid; width: 238px; top: 128px; left: 365px; height: 278px;">
    
             <asp:Image ID="ProductImage2" runat="server" style="position:absolute; top: 56px; left: 18px; height: 114px; width: 192px;"/>
    
             <asp:Label ID="ItemName2" runat="server" style="position:absolute; top: 24px; left: 19px; width: 205px;"></asp:Label>
    
             <asp:Label ID="ItemQuantity2" runat="server" Text="" style="position:absolute; top: 191px; left: 17px; width: 193px;"></asp:Label>
    
             <asp:Label ID="ItemPrize2" runat="server" style="position:absolute; top: 225px; left: 18px; width: 191px;"></asp:Label>
    
         </div>

     
        
        <div id="Product3" runat="server" style="border-style: solid; border-color: white; position:absolute; background-color: #0000FF; color: #FFFFFF; top: 130px; left: 641px; width: 252px; height: 275px;">
            <asp:Image ID="ProductImage3" runat="server" CssClass="auto-style1" style="position:absolute; top: 61px; left: 23px; width: 208px; height: 106px;" />
            <asp:Label ID="ItemName3" runat="server" style="position:absolute; top: 29px; left: 22px;"></asp:Label>
            <asp:Label ID="ItemQuantity3" runat="server" Text="" style="position:absolute; top: 184px; left: 18px; width: 216px;"></asp:Label>
            <asp:Label ID="ItemPrize3" runat="server" Text="" style="position:absolute; top: 220px; left: 22px; width: 160px;"></asp:Label>
        </div>
       
       

        </div>
       
       


         

        
      
       
       


         
        
        
       
       


         

        
      
       
       


         
        
        <div class="auto-style4" style="position: absolute; background-color: #0000FF; color: #FFFFFF;">
            <asp:TextBox ID="Searchbox" runat="server" style="position:absolute; top: 94px; left: 167px; width: 542px;"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" Text="Search" style="position:absolute; margin-left: 20px; top: 94px; left: 710px; height: 24px;" Width="83px"/>
            <asp:DropDownList ID="DropDownList1" runat="server" style="position:absolute; top: 97px; left: 78px;">
                <asp:ListItem>Products</asp:ListItem>
                <asp:ListItem>Seller</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Search Products" style="position:absolute; top: 15px; left: 28px; height: 47px; width: 406px; font-size:60px"></asp:Label>
        </div>
       
       


         

        
      
       
       


         
        
        
       
       


         

        
      
       
       


         
        
        <div class="bottom" style="position: absolute; background-color: #000000; color: #FFFFFF;">
       
            <asp:Label ID="CopyrightLabel" runat="server" style="position:absolute; top: 101px; left: 543px;"></asp:Label>
       
        </div>
       
       


         

        
      
       
       


         
        
        
       
       


         

        
      
       
       


         
        
   </form>
        
 
   
    
    </body>
</html>
