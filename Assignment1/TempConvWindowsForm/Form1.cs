using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempConvWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* 
            Handles the event of converting a temperature represented in 
            Celcius to Fahrenheit.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            fahrenheitResult.Text = "";

            TempConvService.Service1Client c2fService = new TempConvService.Service1Client();

            try
            {
                if (celciusValue.Text != null)
                {
                    int fahrenheit = c2fService.c2f(int.Parse(celciusValue.Text));
                    fahrenheitResult.Text = fahrenheit.ToString();
                }
            }
            
            catch(Exception exception)
            {
                label3.Text = "Exception: "+exception.Message;
            }
        }

        /* 
            Handles the event of converting a temperature represented in 
            Fahrenheit to Celcius.
        */
        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            celciusResult.Text = "";

            TempConvService.Service1Client f2cService = new TempConvService.Service1Client();

            try
            {
                if (celciusValue.Text != null)
                {
                    int celcius = f2cService.f2c(int.Parse(fahrenheitValue.Text));
                    celciusResult.Text = celcius.ToString();
                }
            }

            catch (Exception exception)
            {
                label4.Text = "Exception: " + exception.Message;
            }
        }
    }
}
