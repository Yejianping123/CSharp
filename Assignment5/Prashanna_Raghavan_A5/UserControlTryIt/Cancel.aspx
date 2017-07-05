<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cancel.aspx.cs" Inherits="Default2" %>
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
               <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Cancel Tickets"></asp:Label>
               <br />
               <asp:Label ID="Label11" runat="server" Text="This is a try it page deployed to cancel tickets"></asp:Label>
               <br />
            <br />
     <asp:Label ID="Label1" runat="server" Text="Ticket confirmation number"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="" Text="Cancel ticket" />
        <br />
        <br />
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
    </div>
        <Logout:logout runat ="server"/>

    </form>
</body>
</html>
