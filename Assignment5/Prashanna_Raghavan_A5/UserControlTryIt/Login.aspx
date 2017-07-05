<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style type="text/css">
.tg  {border-collapse:collapse;border-spacing:0;}
.tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 20px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
.tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 20px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
.tg .tg-yw4l{vertical-align:top}
</style>
<table class="tg">
  <tr>
    <th class="tg-yw4l" colspan="5"><strong>AIRLINE RESERVATION SYSTEM</strong></th>
  </tr>
  <tr>
    <td class="tg-yw4l" colspan="5">Login Page</td>
  </tr>
   <tr>
    <td class="tg-yw4l" colspan="5">
        <form id="form1" runat="server">
        <div>
         <asp:Label ID="Label" runat="server" Text="Username"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1"  runat="server" Width="233px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Password" ></asp:Label>
    
            &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="232px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="Button1_Click" />
         <br />
         <br />
         <asp:Label ID="Label2" runat="server" Text="Status : "></asp:Label>
    </div>
</form>
    </td>
  </tr>
</table>
</body>
</html>
