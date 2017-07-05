using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reserve : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * Member, Support staff and agent only page 
         */ 
        HttpCookie httpCookie = Request.Cookies["userCookie"];
        if (httpCookie == null || httpCookie["username"] == "") { Response.Redirect("Login.aspx"); }
        else { TextBox1.Text = httpCookie["username"]; }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * A event handler to reserve tickets using the given values
         */

        string username = TextBox1.Text;
        string date = TextBox2.Text;
        string from = TextBox3.Text;
        string to = TextBox4.Text;
        string start = TextBox5.Text;
        string end = TextBox6.Text;
        int noOfTickets = Convert.ToInt32(TextBox7.Text);

        /*
         * Send the values to the service and get back the response in boolean and 
         * display the status of the reservation accordingly
         */ 
        AirlineSVCReference.Service1Client client = new AirlineSVCReference.Service1Client();
        bool reserveTickets = client.ReserveTickets(username, date, from, to, start, end, noOfTickets);

        Label8.Text = (reserveTickets == true) ? "Status : Success" : "Status : Failed";
    }
}