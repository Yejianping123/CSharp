using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    Top10SVCReference.ServiceClient localServiceClient = new Top10SVCReference.ServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        descriptionLabel.Text = "For analyzing a web page please prepend http:// to the website address";
    }


    /*
    * check if the url provided is indeed a valid URL
    */

    public Boolean isURL(string URL)
    {
        Boolean isURL = Uri.IsWellFormedUriString(URL, UriKind.Absolute);
        return isURL ? true : false;
    }

    /*
     * call the service hosted in localhost
     */ 
    public string[] getTop10Words(string URL)
    {
        return (isURL(URL)) ? localServiceClient.Top10Words(URL) : null;
    }

    /*
     * Top 10 words button click handler
     */ 
    protected void top10Button_Click(object sender, EventArgs e)
    {
        descriptionLabel.Text = "";
        displayText.Text = "";

        try
        {
            /*
             * check if the URL is not empty
             */ 
            if (urlTextBox.Text == null || urlTextBox.Text == "")
            {
                descriptionLabel.Text = "URL box cannot be blank";
            }

            else
            {
                /*
                 * Get top 10 words from the service and display accordingly in the text box
                 */ 
                string[] words = getTop10Words(urlTextBox.Text);
                string texttodisplay = "";
                int count = 1;

                foreach (string word in words)
                {
                    string s = "{0}-> {1}{2}";
                    texttodisplay += string.Format(s, count, word, Environment.NewLine);
                    count += 1;
                }
                displayText.Text = texttodisplay;
            }
        }

        catch (Exception exception)
        {
            descriptionLabel.Text = exception.Message + "Something went wrong. Please check the link that you entered and try again later";
        }
    }
}