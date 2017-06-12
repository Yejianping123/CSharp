using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    WordFilterSVCReference.ServiceClient localServiceClient = new WordFilterSVCReference.ServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        descriptionLabel.Text = "For analyzing a web page please prepend http:// to the website address";
    }

    /*
     * call the service hosted in localhost
     */
    public string getWordFilters(string URL)
    {
        return localServiceClient.WordFilter(URL);
    }


    /*
     * Top word filter button click handler
     */
    protected void wordFilterButton_Click(object sender, EventArgs e)
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
                 * Get filtered words from the service and display accordingly in the text box
                 */
                string words = getWordFilters(urlTextBox.Text);
                displayText.Text = words; 
            }
        }

        catch (Exception exception)
        {
            descriptionLabel.Text = exception.Message + "Something went wrong. Please check the link that you entered and try again later";
        }
    }
}