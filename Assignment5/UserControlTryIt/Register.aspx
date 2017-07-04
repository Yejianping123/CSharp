<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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
    <td class="tg-yw4l" colspan="5">Registration Page</td>
  </tr>
    <tr>
    <td class="tg-yw4l" colspan="5">
        <form id="form1" runat="server">
        <div>
    
        <asp:Label ID="Label" runat="server" Text="Username"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1"  runat="server" Width="170px"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Password" ></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="170px"></asp:TextBox>
        <br />
    
        <asp:Label ID="Label2" runat="server" Text="Confirm Password" ></asp:Label>
    
            &nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="170px"></asp:TextBox>
        <br />
        <br />


         <div>
        <img id="Image1" src="http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/{NO0B}" />        
        <span id="Label4">Image String Length = </span>
        <input name="txtBoxlength" type="text" value="6" id="txtBoxlength" style="width:24px;" />
        <br />
        <input type="submit" name="Button2" value="New captcha" id="Button2" style="width:289px;" />
        </div>
         <div>
         Captcha Text 
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;<br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
        <br />        
        <br />
       <span id="Label5"></span>
        </div>
        <asp:Label ID="Label3" runat="server" Text="Status : "></asp:Label>
        <br />
        <br />
        <a href="http://webstrar64.fulton.asu.edu/page9/Login.aspx"> Login </a>
    </div>
</form>
    </td>
  </tr>
  
</table>
</body>
</html>
