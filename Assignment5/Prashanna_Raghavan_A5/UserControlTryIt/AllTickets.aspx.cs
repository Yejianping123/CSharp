using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class AllTickets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        /*
         * Check if the ticket is available for given date,source,destination,nooftickets
         */

        AirlineSVCReference.Service1Client client = new AirlineSVCReference.Service1Client();
        string[] availableFlightsInfo = client.CompleteFlights();

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
}