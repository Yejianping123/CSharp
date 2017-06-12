<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="779px">
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Top 10 Words"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="This is a try-it page deployed to test the top 10 words from a webpage"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="URL : "></asp:Label>
    <asp:TextBox ID="urlTextBox" runat="server" Width="666px">http://</asp:TextBox>
        <br />
    <asp:Label ID="descriptionLabel" runat="server" ForeColor="#CC0000"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="top10Button" runat="server" OnClick="top10Button_Click" Text="Get Top 10 Words" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Result"></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="displayText" runat="server" Height="239px" Width="661px" TextMode="MultiLine"></asp:TextBox>
</asp:Panel>
</asp:Content>
