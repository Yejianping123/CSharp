<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tickets.aspx.cs" Inherits="Tickets" %>

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
               <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Check Tickets"></asp:Label>
               <br />
               <asp:Label ID="Label8" runat="server" Text="This is a try it page deployed to check the availability of flights on a given date between Source and Destination"></asp:Label>
               <br />
               <br />
               <asp:Label ID="Label1" runat="server" Text="Date(mm/dd/yyyy)"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 29px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Source"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 36px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Destination"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 50px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="No of Tickets"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 16px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 96px" Text="Check Ticket Availability" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Available Flights"></asp:Label>
        <br />
        <br />
    <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
    </div>
    </form>
</body>
</html>
