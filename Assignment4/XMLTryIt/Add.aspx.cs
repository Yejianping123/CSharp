using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add : System.Web.UI.Page
{
    /*
     * Initialize the service reference.
     */ 
    XMLServiceReference.ServiceClient xmlServiceReference = new XMLServiceReference.ServiceClient();
    CryptoServiceReference.ServiceClient cryptoServiceReference = new CryptoServiceReference.ServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*
     * Allow only one radio button at a time
     */ 
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        No.Checked = false;
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Yes.Checked = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string encryption = null;
        string password = null;

        /*
         * If yes is check call encryption function to encrypt the field the store the password
         * as an encrypted field
         */ 
        if (!No.Checked)
        {
            encryption = "Yes";
            password = cryptoServiceReference.Encrypt(passwordText.Text);
        }
        /*
         * Else write as it is
         */ 
        else
        {
            encryption = "No";
            password = passwordText.Text;
        }

        /*
         * Combine the values into one string and send it to the service
         */ 
        string addString = firstText.Text + "," + lastText.Text + "," + idText.Text
            + "," + password + "," + encryption + "," + workText.Text + "," + cellText.Text
            + "," + categoryText.Text + "," + providerText.Text;

        Label1.Text = xmlServiceReference.AddNewPerson(addString);
    }
}