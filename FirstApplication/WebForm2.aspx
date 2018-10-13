<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="FirstApplication.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <style type="text/css">
        #form1 {
            height: 468px;
            margin-top: 63px;
        }
    </style>
</head>
<body style="background-color:cadetblue">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Registration Form for Store Account"></asp:Label>
        <p>
            &nbsp;</p>
        
            <asp:Label ID="Label2" runat="server" Text="Date Today: "></asp:Label> <asp:Label ID="Label3" runat="server"></asp:Label>
            <br /><br/ >
            <br /><br/ >
            <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
            <br /><br/ >
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br /><br/ >
            <br /><br/ >
            <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
            <br /><br/ >
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <br /><br/ >
            <br /><br/ >
            <asp:Label ID="Label6" runat="server" Text="Confirm Password"></asp:Label>
            <br /><br/ >
            <asp:TextBox ID="ConfirmPassword" runat="server"></asp:TextBox>
            <br /><br/ >
            <br /><br/ >
            <asp:Button ID="Register" runat="server" Height="24px" Text="Register" Width="85px" OnClick="Register_Click" />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server"></asp:Label>
    </form>
</body>
</html>
