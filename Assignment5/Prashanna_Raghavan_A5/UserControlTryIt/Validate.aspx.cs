using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Runtime.Serialization;

public partial class Validate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * Staff only page - Support and Admin
         */ 
        HttpCookie httpCookie = Request.Cookies["userCookie"];
        if (httpCookie == null || httpCookie["username"] == "") { Response.Redirect("Login.aspx"); } 
        else if(httpCookie["role"] == "Member") { Response.Redirect("Unauthorized.aspx"); }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         * Get the credit card information that needs to be validated with 
         * the set of credit cards available in the local text file
         */ 
        string cardNo = TextBox1.Text;
        string date = TextBox2.Text;
        string name = TextBox4.Text;
        string cvv = TextBox3.Text;
 
        /*
         * Set the base URI of the service deployed in webstrar folder
         */ 
        Uri baseUri = new Uri("http://webstrar64.fulton.asu.edu/page4/Service1.svc");
        // Define UriTemplate for passing parameter
        UriTemplate myTemplate = new UriTemplate("validate?cardNo={cardNo}&expiry={date}&name={name}&cvv={cvv}");
        // Assign values to variable to obtain the complete URI
        Uri completeUri = myTemplate.BindByPosition(baseUri, cardNo, date, name, cvv);
        WebClient channel = new WebClient(); // create a channel
        byte[] abc = channel.DownloadData(completeUri); // return byte array
        Stream strm = new MemoryStream(abc); // convert to mem stream
        DataContractSerializer obj = new DataContractSerializer(typeof(string));
        string randString = obj.ReadObject(strm).ToString(); // convent to string
        Label1.Text = randString;
    }
}