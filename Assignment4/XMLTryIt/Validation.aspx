<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validation.aspx.cs" Inherits="Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="XML Validation"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="This is a try it page to check whether a given XML is well formed based on given XSD  "></asp:Label>
        <br />
        <br />
        XML URL&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="635px"></asp:TextBox>
        <br />
        XSD URL&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="632px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check" />
        <br />
        <br />
            <asp:TextBox ID="TextBox3" runat="server" Height="256px" Width="717px" style="margin-left: 0px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
