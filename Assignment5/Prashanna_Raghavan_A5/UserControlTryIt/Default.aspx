<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <th class="tg-yw4l" colspan="5"><strong>SERVICE REPOSITORY</strong></th>
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
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Login </br> Input: string username,password</br> Output: login status</td>
    <td class="tg-yw4l"><a href="Login.aspx">Login.aspx</a></td>
    <td class="tg-yw4l">A service to login to the airline reservation system</td>
    <td class="tg-yw4l">Require local XML file to authenticate the users</td>
  </tr>
    
    <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Register </br> Input: string username,password</br> Output: register status </td>
    <td class="tg-yw4l"><a href="Register.aspx">Register.aspx</a></td>
    <td class="tg-yw4l">A service to register to the airline reservation system</td>
    <td class="tg-yw4l">Require local XML file to store the users</td>
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
    <th class="tg-yw4l" colspan="5"><strong>MEMBER PAGE</strong></th>
  </tr>  
     <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Airline Reservation System : Check Tickets </br> Input : string date,source,destination,noOfTickets </br> Output : Available flights </td>
    <td class="tg-yw4l"><a href="Tickets.aspx">Tickets.aspx</a></td>
    <td class="tg-yw4l">A service to check flight tickets from the local text file</td>
    <td class="tg-yw4l">Require local text file to store the tickets</td>
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
    </tr>
    <tr>
    <th class="tg-yw4l" colspan="5"><strong>PUBLIC REMOTE SERVICE</strong></th>
  </tr>
    <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Get web content from a URL </br> Input : string URL </br> Output : string webcontent </td>
    <td class="tg-yw4l"><a href="Web2String.aspx">Web2String.aspx</a></td>
    <td class="tg-yw4l">A service to get web content in string format</td>
    <td class="tg-yw4l">WSRepository API : </br>Web2String SVC</td>
  </tr>
    <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Analyze Top 10 Words in a page </br> Input : string URL </br> Output : Top 10 Words </td>
    <td class="tg-yw4l"><a href="http://webstrar64.fulton.asu.edu/page1/Top10Words.aspx">Top10Words.aspx</a><br></td>
    <td class="tg-yw4l">A service to analyze top 10 words in a webpage</td>
    <td class="tg-yw4l">Require API : </br>Web2String SVC from WSRepository</td>
  </tr>
  <tr>
    <td class="tg-yw4l">Prashanna Raghavan</td>
    <td class="tg-yw4l">Filter Stop Words in a page </br> Input : string URL/String essay </br> Output : Filtered Words </td>
    <td class="tg-yw4l"><a href="http://webstrar64.fulton.asu.edu/page1/WordFilter.aspx">WordFilter.aspx</a></td>
    <td class="tg-yw4l">A service to filter stop words in a webpage or a given string</td>
    <td class="tg-yw4l">Require API : </br>Web2String SVC from WSRepository</td>
  </tr>
</table>
</body>
</html>
