using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Validation : System.Web.UI.Page
{
    /*
     * Initialize the Service Reference
     */ 
    XMLServiceReference.ServiceClient xmlServiceClient = new XMLServiceReference.ServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * A function to handle the event of validating an xml using an xsd
         */ 
        String output = xmlServiceClient.XMLValidation(TextBox1.Text, TextBox2.Text);

        /*
         * Display the contents if it is valid
         * or split the error message using the delimiter '.'
         * and display each error in a new line 
         */
        string[] errors = output.Split('.');
        string errorMessage = null;
        foreach (string str in errors)
        {
            errorMessage = errorMessage + "\n" + str;
        }
        TextBox3.Text = errorMessage;
        TextBox3.Text.Replace(Environment.NewLine, "<br />");
    }
}