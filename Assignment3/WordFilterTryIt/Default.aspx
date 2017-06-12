<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Panel ID="Panel1" runat="server" Width="779px">
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Word Filter"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="This is a try-it page deployed to test the word filter service from a webpage"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="URL/String : "></asp:Label>
    <asp:TextBox ID="urlTextBox" runat="server" Width="666px"></asp:TextBox>
        <br />
    <asp:Label ID="descriptionLabel" runat="server" ForeColor="#CC0000"></asp:Label>
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="wordFilterButton" runat="server" OnClick="wordFilterButton_Click" Text="Perform Word Filter" />
        <br />
        <br />
            &nbsp;<asp:Label ID="Label4" runat="server" Text="Result"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="displayText" runat="server" Height="239px" Width="661px" TextMode="MultiLine"></asp:TextBox>
</asp:Panel>

</asp:Content>
