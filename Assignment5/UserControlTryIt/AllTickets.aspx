<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllTickets.aspx.cs" Inherits="AllTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
               <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="AIRLINE RESERVATION SYSTEM"></asp:Label>
               <br />
               <br />
               <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Check All Tickets"></asp:Label>
               <br />
               <asp:Label ID="Label8" runat="server" Text="This is a try it page deployed to check all available flights from the database"></asp:Label>
               <br />
        <br />
               <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="CheckAllTickets" />
        <br />
        <br />
    <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
    </div>
    </form>
</body>
</html>
