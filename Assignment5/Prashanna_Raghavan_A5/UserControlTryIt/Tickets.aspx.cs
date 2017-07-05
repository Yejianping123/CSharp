using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Tickets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * Member, support staff and admin only page
         */ 
        HttpCookie httpCookie = Request.Cookies["userCookie"];
        if (httpCookie == null || httpCookie["username"] == "") { Response.Redirect("Login.aspx"); }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * A event handler to check tickets using the given values
         */

        string date = TextBox1.Text;
        string from = TextBox2.Text;
        string to = TextBox3.Text;
        int noOfTickets = Convert.ToInt32(TextBox4.Text);
        string start = null;
        string end = null;
        
        /*
         * Check if the ticket is available for given date,source,destination,nooftickets
         */ 
        AirlineSVCReference.Service1Client client = new AirlineSVCReference.Service1Client();
        bool isTicketsAvailable = client.isTicketAvailable(date, from, to, noOfTickets, start, end);
        string[] availableFlightsInfo = client.MatchingFlights(date, from, to, noOfTickets);
        
        if (isTicketsAvailable == true)
        {
            Label5.Text = "Tickets Available";        
            StringBuilder sb = new StringBuilder("<table border = '1'>");
            /*
                 * Header for table
                 */
            sb.AppendFormat("<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>", "Date", "Source", "Destination", "Start", "End");
            foreach (string flight in availableFlightsInfo)
            {
                string[] array = flight.Split(' ');
                /*
                 * Information for table
                 */ 
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>", array[0], array[1], array[2], array[3], array[4]);
            }

            sb.Append("</table>");

            /*
             * Get the details and populate it in the placeholder
             */ 
            var table = sb.ToString();
            PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });
        }
        else
        {
            Label5.Text = "Tickets Unavailable";
        }
    }
}