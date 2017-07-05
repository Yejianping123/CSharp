<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validate.aspx.cs" Inherits="Validate" %>
<%@ Register TagPrefix = "Logout" TagName="logout" src="Logout.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="AIRLINE RESERVATION SYSTEM"></asp:Label>
               <br />
               <br />
               <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Validate Credit Card"></asp:Label>
               <br />
               <asp:Label ID="Label11" runat="server" Text="This is a try it page deployed to validate a credit card information"></asp:Label>
               <br />
            <br />
        <br />
        CreditCard No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 36px"></asp:TextBox>
        <br />
        Expiry Date<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 85px"></asp:TextBox>
        <br />
        Name on Card&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 36px"></asp:TextBox>
        <br />
        CVV<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 121px"></asp:TextBox>
        <br />
&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 143px" Text="Check " />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Status :"></asp:Label>
        <br />
        <br />
    
    </div>
        <Logout:logout runat ="server"/>
    </form>
</body>
</html>
