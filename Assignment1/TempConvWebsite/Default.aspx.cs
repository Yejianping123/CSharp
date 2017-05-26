using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /* 
     * This function handles the event of converting a temperature represented in
     * Celcius to Fahrenheit.  
     */
    protected void c2fConvert_Click(object sender, EventArgs e)
    {
        Label3.Text = "";
        TempConvService.Service1Client c2fService = new TempConvService.Service1Client();
        try
        {
            int fahrenheit = c2fService.c2f(int.Parse(celciusValue.Text));
            fahrenheitResult.Text = fahrenheit.ToString();
        }

        catch(Exception exception)
        {
            Label3.Text = "Exception: " + exception.Message;
        }
        
    }

    /* 
     * This function handles the event of converting a temperature represented in
     * Fahrenheit to Celcius.  
     */
    protected void f2cConvert_Click(object sender, EventArgs e)
    {
        Label4.Text = "";
        TempConvService.Service1Client f2cService = new TempConvService.Service1Client();
        try
        {
            int celcius = f2cService.f2c(int.Parse(fahrenheitValue.Text));
            celciusResult.Text = celcius.ToString();
        }

        catch (Exception exception)
        {
            Label4.Text = "Exception: " + exception.Message;
        }
        
    }
}