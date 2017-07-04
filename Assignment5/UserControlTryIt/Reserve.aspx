<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reserve.aspx.cs" Inherits="Reserve" %>

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
               <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Reserve Tickets"></asp:Label>
               <br />
               <asp:Label ID="Label11" runat="server" Text="This is a try it page deployed to reserve tickets for a flight on a given date between Source and Destination"></asp:Label>
               <br />
            <br />
        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 57px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Date(mm/dd/yyyy)"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 30px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Source"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 37px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Destination"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 54px"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Time of Journey"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 34px"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Destination Time"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" style="margin-left: 38px"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="No of Tickets"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox7" runat="server" style="margin-left: 17px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Reserve" OnClick="Button1_Click" style="margin-left: 101px" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="Status"></asp:Label>
        <br />
        <br />

    </div>
    </form>
</body>
</html>
