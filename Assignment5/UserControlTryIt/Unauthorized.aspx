<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Unauthorized.aspx.cs" Inherits="Unauthorized" %>
<%@ Register TagPrefix = "Logout" TagName="logout" src="Logout.ascx" %>

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
    <td class="tg-yw4l" colspan="5">Unauthorized page</td>
  </tr>
 <tr>
    <td class="tg-yw4l" colspan="5">You are not a authorized user to view this page. </td>
  </tr>
</table>
    <form id="form1" runat="server">
    <Logout:logout runat ="server"/>
</form>

</body>
</html>
