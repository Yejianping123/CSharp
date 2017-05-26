<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Celicus ----&gt; Fahrenheit Conversion"></asp:Label>
    </p>
    <asp:Panel ID="Panel1" runat="server">
        <asp:TextBox ID="celciusValue" runat="server" ToolTip="Only Numeric"></asp:TextBox>
        <asp:Button ID="c2fConvert" runat="server" Text="Convert" OnClick="c2fConvert_Click" />
        <asp:TextBox ID="fahrenheitResult" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" ForeColor="#CC0000"></asp:Label>
    </asp:Panel>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Fahrenheit ----&gt; Celicus Conversion"></asp:Label>
        <br />
    </p>
    <asp:Panel ID="Panel2" runat="server">
        <asp:TextBox ID="fahrenheitValue" runat="server" ToolTip="Only Numeric"></asp:TextBox>
        <asp:Button ID="f2cConvert" runat="server" Text="Convert" OnClick="f2cConvert_Click" />
        <asp:TextBox ID="celciusResult" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" ForeColor="#CC0000"></asp:Label>
    </asp:Panel>

</asp:Content>
