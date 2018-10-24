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
        .menubar {
   
    background-color: blue;
   
    top: 125px; 
    width: 98%;
            left: 12px;
            height: 51px;
        }

/* Links inside the navbar */
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
    color: black;
}


    </style>
</head>
<body style="background-color:white; height:1000px;overflow:auto;">

   <div id="above" style="position: sticky; background-color:blue; height: 164px; top:0px;">
   <asp:Image ID="Image1" runat="server" Width="187px" ImageAlign="Left" style="margin-top: 0px; top: 15px; left: 10px; height: 104px;" />
     <div class="menubar" id="menu" runat="server">
         
         <a href="Webform1.aspx">Home</a>
        <a href="#store">Store</a>
 <a href="#about">About US</a>
  <a href="Webform2.aspx">Account</a>
    </div>
       </div>
    
    <form id="form1" runat="server" >        
     
   
<div runat="server"  id="LoginForm" style="border: thick double #000000; position: fixed; padding: inherit; background-color: #0000FF; margin-left: inherit; margin-right: inherit; margin-top: 0px; margin-bottom: inherit; top: 208px; color: #FFFFFF; right: 10px;" >
    <p style="color: #FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp; Log In</p>
    <p style="color: #FFFFFF" >&nbsp;&nbsp; Username:</p>
    <asp:TextBox runat="server" id="Username" style="margin-left: 16px" /> 
    <br /><br/ >
    &nbsp;&nbsp;
    <p style="color: #FFFFFF" >&nbsp;&nbsp;&nbsp; Password:</p>
    <asp:TextBox runat="server" id="Password" style="margin-left: 15px" /> 
    <br /><br/ >
    <br /><br/ >
    <asp:Button runat="server" id="Submit" text="Submit" OnClick="Submit_Click" style="margin-left: 15px" />
    <asp:Button runat="server" id="Register" text="Register" OnClick="Register_Click" style="margin-left: 30px" Width="73px" />
    <br /><br/ >
    <asp:Label ID="Combined" runat="server" ForeColor="White" style="margin-left: 18px" Width="165px"></asp:Label>
    
</div>
   <div runat="server" id="Product1" style="border-color: black; border-style: solid; width: 353px; position: absolute; left: 87px; height: 184px; background-color: blue; margin-top: 0px; top: 200px; color:white; ">
        
           
     
       
        
           
     
            <asp:Label ID="ItemName1" runat="server" style="position:absolute; top: 18px; left: 100px; height: 22px; width: 239px;"></asp:Label>
        
           
     
       
        
     
     
              <asp:Label ID="ItemPrize1" runat="server" style="position:absolute; top: 159px; left: 239px; width: 110px; height: 23px;"></asp:Label>
           
     
       
        
           
     
       <asp:Label ID="ItemCat12" runat="server" style="position:absolute; top: 125px; left: 133px; height: 20px; width: 85px;"></asp:Label>
     
       
        
           
     
            <asp:Label ID="ItemQuantity1" runat="server" style="position:absolute; top: 157px; left: 12px; height: 24px; width: 205px;"></asp:Label>
        
           
     
       
        
            <asp:TextBox ID="ItemDescription1" runat="server" style="position:absolute; top: 45px; left: 106px; height: 57px; width: 204px; background-color: white; color: black; bottom: 76px;" Enabled="False" ></asp:TextBox>
           
     
       
        
           
     
     
            <asp:Image ID="ProductImage1" runat="server" style="position:absolute; top: 22px; left: 15px; height: 86px; width: 69px;"/>
        
           
     
       <asp:Label ID="ItemCat13" runat="server" style="position:absolute; top: 130px; left: 241px; height: 18px; width: 85px;"></asp:Label>
        
           
     
           
     
       <asp:Label ID="ItemCat11" runat="server" style="position:absolute; top: 127px; left: 16px; height: 22px; width: 79px;"></asp:Label>
     
       
        
           
     
        </div>



        
   
        
         <div id="Product2" runat="server" style="position: absolute;background-color:blue; color:black; border-style: solid; width: 344px; top: 412px; left: 91px; height: 180px;">
    
         </div>

        <asp:Button ID="Button1" runat="server" Text="Hide Products" OnClick="Button1_Click" style="position:absolute; top: 614px; left: 321px; height: 32px;"/>
       <asp:Button ID="Button2" runat="server" Text="Show Products" style="position:absolute; top: 614px; left: 158px; height: 32px;" OnClick="Button2_Click"/>
       
       


         

        
      
       
       


         

        
   </form>
        
</body>
</html>
