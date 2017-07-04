using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web2String : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * Get service reference and display the value in a textbox
         */ 
        Web2StringSVCReference.ServiceClient stringSVC = new Web2StringSVCReference.ServiceClient();
        TextBox2.Text = stringSVC.GetWebContent(TextBox1.Text);
    }
}