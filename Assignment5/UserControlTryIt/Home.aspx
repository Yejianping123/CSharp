<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
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
    <form id="form1" runat="server">

<table class="tg">
    <tr>
    <th class="tg-yw4l" colspan="5"><strong>AIRLINE RESERVATION SYSTEM</strong></th>
  </tr>
  <tr>
    <td class="tg-yw4l" colspan="5">Airline ticket reservation system is a complete service-oriented computing system that let users to</br></br>
1. Check the all available ticket </br>
2. Check the ticket availability between two destinations</br>
2. Reserve a seat</br>
3. Cancel booked ticket</br>
4. Validate the user’s credit card information</br></br>
The system follows a 4-tier approach – Presentation, Application Logic, Service and Data Management Layer. </td>
  </tr>


  <tr>
    <th class="tg-yw4l" colspan="5">This page is deployed at: <a href="http://webstrar64.fulton.asu.edu/">http://webstrar64.fulton.asu.edu/</a></th>
  </tr>
  <tr>
    <td class="tg-yw4l" colspan="5">This project is developed by: Prashanna Raghavan</td>
  </tr>

  <tr>
    <td class="tg-yw4l">Provider name</td>
    <td class="tg-yw4l">Service name, with input and output types</td>
    <td class="tg-yw4l">TryIt link</td>
    <td class="tg-yw4l">Service description</td>
    <td class="tg-yw4l">Planned resources need to implement the service</td>
  </tr>
    <tr>
    <th class="tg-yw4l" colspan="5"><strong>PUBLIC PAGE</strong></th>
  </tr>
    <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Airline Reservation System : Check All Tickets </br> Input : NA </br> Output : All Available flights </td>
    <td class="tg-yw4l"><a href="AllTickets.aspx">AllTickets.aspx</a></td>
    <td class="tg-yw4l">A service to check flight tickets from the local text file</td>
    <td class="tg-yw4l">Require local text file to store the tickets</td>
  </tr> 
  <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Airline Reservation System : Check Tickets </br> Input : string date,source,destination,noOfTickets </br> Output : Available flights </td>
    <td class="tg-yw4l"><a href="Tickets.aspx">Tickets.aspx</a></td>
    <td class="tg-yw4l">A service to check flight tickets from the local text file</td>
    <td class="tg-yw4l">Require local text file to store the tickets</td>
  </tr>  
    <tr>
    <th class="tg-yw4l" colspan="5"><strong>MEMBER PAGE</strong></th>
  </tr>  
  <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Airline Reservation System : Reserve Tickets </br> Input : string username,date,source,destination,start,end,noOfTickets </br> Output : Booking status </td>
    <td class="tg-yw4l"><a href="Reserve.aspx">Reserve.aspx</a></td>
    <td class="tg-yw4l">A service to reserve flight on a given date and time between a source and destination</td>
    <td class="tg-yw4l">Require local text file to store the reserved tickets</td>
  </tr>
    <tr>
    <th class="tg-yw4l" colspan="5"><strong>STAFF PAGE(SUPPORT)</strong></th>
  </tr>
  <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Airline Reservation System : Validate Credit Card </br> Input : string cardNo,expirydate,cvv,name </br> Output : Validation status </td>
    <td class="tg-yw4l"><a href="Validate.aspx">Validate.aspx</a></td>
    <td class="tg-yw4l">A service to check the validaity of the credit card</td>
    <td class="tg-yw4l">Require local text file to compare the valid credit cards</td>
  </tr>
    <tr>
    <th class="tg-yw4l" colspan="5"><strong>STAFF PAGE(ADMIN)</strong></th>
  </tr>
  <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Airline Reservation System : Cancel Tickets </br> Input : string confirmationNumber </br> Output : Cancel status </td>
    <td class="tg-yw4l"><a href="Cancel.aspx">Cancel.aspx</a></td>
    <td class="tg-yw4l">A service to cancel flight using ticket confirmation number</td>
    <td class="tg-yw4l">Require local text file to store the reserved tickets</td>
  </tr>
</table>
<Logout:logout runat ="server"/>
</form>
</body>
</html>
