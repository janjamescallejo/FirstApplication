<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FirstApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Store</title>
    <style type="text/css">
        #Button1 {
            width: 69px;
            margin-left: 31px;
        }
    </style>
</head>
<body style="background-color:cadetblue">
    
  
    <form id="form1" runat="server" align="right" style="text-align:left; height: 382px; width: 831px; background-color: cadetblue; margin-top: 13px; position: absolute; right: -85px; top: 12px;" submitdisabledcontrols="True" visible="True">
<div aria-hidden="False" style="padding: inherit; margin: inherit; border-width: thick; border-style: double; height: 307px; width: 206px; background-color: #0000FF; position: absolute; top: 2px; right: 100px;"color: #FFFFFF">
    <p style="color: #FFFFFF">Log In</p>
    <p style="color: #FFFFFF" >Username:</p>
    <asp:TextBox runat="server" id="Username" /> 
    <br /><br/ >
    <p style="color: #FFFFFF" >Password:</p>
    <asp:TextBox runat="server" id="Password" /> 
    <br /><br/ >
    <br /><br/ >
    <asp:Button runat="server" id="Submit" text="Submit" OnClick="Submit_Click" />
    <asp:Button runat="server" id="Register" text="Register" OnClick="Register_Click" style="margin-left: 30px" Width="65px" />
    <br /><br/ >
    <asp:Label runat="server" id="Combined" ForeColor="White"></asp:Label>
</div>
</form>
</body>
</html>
