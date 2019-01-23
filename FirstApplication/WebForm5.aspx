<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="FirstApplication.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sell</title>
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
        <div id="createTag" runat="server" style="position:absolute; background-color:blue; color:white; top: 156px; left: 890px; width: 245px; height: 379px;">

            <asp:Label ID="TagID" runat="server" Text="" style="position:absolute; top: 44px; left: 26px;"></asp:Label>
             <asp:Label ID="Label8" runat="server" Text="Tag Name" style="position:absolute; top: 74px; left: 24px;"></asp:Label>
            <asp:TextBox ID="TagName" runat="server" style="position:absolute; top: 103px; left: 25px;"></asp:TextBox>

           

            <asp:Label ID="Label9" runat="server" Text="Tag Description" style="position:absolute; top: 148px; left: 24px;"></asp:Label>

           

            <asp:TextBox ID="TagDescription" runat="server" style="position:absolute; top: 185px; left: 27px; height: 116px; width: 183px;" TextMode="MultiLine"></asp:TextBox>

           

            <asp:Button ID="tagClearButton" runat="server" Text="Clear" style="position:absolute; top: 331px; left: 33px; height: 26px;" OnClick="tagClearButton_Click"/>

           

            <asp:Button ID="tagSubmitButton" runat="server" Text="Submit" style="position:absolute; top: 336px; left: 164px; height: 20px; width: 54px;" OnClick="tagSubmitButton_Click"/>

           

            <asp:Label ID="tagLabel" runat="server" Text="Create Tag" style="position:absolute; font-size:large; top: 17px; left: 20px; width: 120px; height: 22px; bottom: 340px;"></asp:Label>

           

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
       
        <div id="UploadProduct" runat="server" style="position:absolute; background-color:blue; color:white; top: 154px; left: 58px; height: 684px; right: 589px; margin-right: 0px;">
            
            <asp:Label ID="productUpload" runat="server" Text="Upload Product" style="position:absolute; top: 14px; left: 52px; height: 38px; width: 257px; font-size:40px;"></asp:Label>

            <asp:Label ID="productDate" runat="server" Text="Date: " style="position:absolute; top: 98px; left: 32px; width: 269px; height: 26px; margin-bottom: 0px;"></asp:Label>

            <asp:Label ID="productID" runat="server" Text="" style="position:absolute; top: 78px; left: 27px; height: 19px; bottom: 587px;"></asp:Label>

            <asp:Label ID="Label1" runat="server" Text="Item Name:" style="position:absolute; top: 133px; left: 32px;"></asp:Label>

            <div id="UploadProductTags" runat="server" style="position:absolute; border-color: white; border-style:solid; top: 73px; left: 358px; width: 277px; height: 485px; right: 69px;">
            <asp:Label ID="Label4" runat="server" Text="Choose Tag" style="position:absolute; top: 18px; left: 17px;"></asp:Label>
                  <asp:CheckBoxList ID="tagList" runat="server" style="position:absolute; top: 48px; left: 16px; height: 201px; width: 212px;" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            </asp:CheckBoxList>

                <asp:Label ID="Chosen" runat="server" Text="" style="position:absolute; top: 284px; left: 24px;"></asp:Label>

            </div>

            <asp:TextBox ID="productName" runat="server" style="position:absolute; top: 135px; left: 123px; width: 181px;"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="Item Description" style="position:absolute; top: 346px; left: 36px;"></asp:Label>

            <asp:Label ID="Label3" runat="server" Text="Item Picture" style="position:absolute; top: 172px; left: 29px;"></asp:Label>

            <asp:TextBox ID="productDescription" runat="server" style="position:absolute; top: 385px; left: 28px; height: 128px; width: 282px;" TextMode="MultiLine"></asp:TextBox>


            <asp:FileUpload ID="FileUpload1" runat="server" style="position:absolute; top: 207px; left: 38px; width: 196px;"/>

            <asp:Button ID="uploadPicture" runat="server" Text="Upload" style="position:absolute; top: 206px; left: 258px; width: 54px;" OnClick="uploadPicture_Click"/>

            <asp:Image ID="uploadedPicture" runat="server" style="position:absolute; top: 243px; left: 34px; height: 93px; width: 279px;"/>

            
            <asp:Label ID="Label5" runat="server" Text="Item Quantity" style="position:absolute; top: 550px; left: 28px;"></asp:Label>

            <asp:TextBox ID="productQuantity" runat="server" style="position:absolute; top: 552px; left: 164px; width: 139px;"></asp:TextBox>

            <asp:Label ID="Label6" runat="server" Text="Item Price" style="position:absolute; top: 596px; left: 29px;"></asp:Label>

            <asp:TextBox ID="productPrice" runat="server" style="position:absolute; top: 597px; left: 164px; width: 140px;"></asp:TextBox>

            <asp:Button ID="clearProductButton" runat="server" Text="Clear" style="position:absolute; top: 641px; left: 34px; width: 49px; right: 580px;" OnClick="clearProductButton_Click"/>

            <asp:Button ID="submitProductButton" runat="server" Text="Submit" style="position:absolute; top: 642px; left: 246px; margin-bottom: 4px; height: 26px;" OnClick="submitProductButton_Click"/>
           

          
           

        </div>
       
    </form>
</body>
</html>
