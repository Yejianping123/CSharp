using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * Get the service reference
         */ 
        UserControlServiceReference.ServiceClient client = new UserControlServiceReference.ServiceClient();

        /*
         * See if the given credentials belong to an authorized user
         */ 
        string authorizedUser = client.AuthenticateUser(TextBox1.Text, TextBox2.Text);
        string[] output = authorizedUser.Split('-');

        /*
         * Create a cookie for the user if the validation is successful
         */ 
        if (output[0] == "Validation Successful")
        {
            HttpCookie httpCookie = new HttpCookie("userCookie");
            httpCookie["username"] = TextBox1.Text;
            httpCookie["role"] = output[1];
            httpCookie.Expires = DateTime.Now.AddMonths(6);
            Response.Cookies.Add(httpCookie);
            Response.Redirect("Home.aspx");
        }
        else
        {
            /*
             * Else return the status accordingly
             */ 
            Label2.Text = output[0];
        }
    }
}