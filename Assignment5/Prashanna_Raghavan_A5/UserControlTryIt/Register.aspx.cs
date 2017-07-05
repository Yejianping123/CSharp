using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * Check for the matching text from the image service
         */ 
        if (TextBox4.Text == "{NO0B}")
        {
            /*
             * Register user on successful image verification
             */ 
            UserControlServiceReference.ServiceClient client = new UserControlServiceReference.ServiceClient();
            Label3.Text = client.RegisterUser(TextBox1.Text, TextBox2.Text, TextBox3.Text);
        }
        else
        {
            /*
             * Return appropriate message in case of failure
             */
            Label3.Text = "Please enter a matching string for the image provided";
        }
    }
}