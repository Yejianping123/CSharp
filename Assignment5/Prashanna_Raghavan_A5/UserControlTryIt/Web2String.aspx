<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Web2String.aspx.cs" Inherits="Web2String" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Web2String TryIt"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="This is a try it page created to consume Web2String service available in WSRepository"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="URL: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="477px">http://</asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go" />
        <br />
        <asp:Label ID="Label5" runat="server" ForeColor="#CC0000" Text="Please prepend http:// before the web address"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="362px" TextMode="MultiLine" Width="717px"></asp:TextBox>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
