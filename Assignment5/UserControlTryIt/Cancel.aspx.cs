using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * Only Admin page
         */ 
        HttpCookie httpCookie = Request.Cookies["userCookie"];

        if (httpCookie == null || httpCookie["username"] == ""
            || httpCookie["role"] == "Member" || httpCookie["role"] == "Staff-Support")
        {
            Response.Redirect("Unauthorized.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * Get the local service reference
         */
        LocalServiceReference.Service1Client client = new LocalServiceReference.Service1Client();
        bool isCancellationSuccess = client.CancelTicket(TextBox1.Text);

        /*
         * Display appropriate message
         */ 
        if (isCancellationSuccess == true) { Label2.Text = "Status : Cancellation successful"; }
        else { Label2.Text = "Status : Cancellation failed"; }
    }
}