using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrashannaWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * This function handles the event of opening the website that 
         * was entered in the text box
         */
        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text);
        }

        /*
         * This function handles the event of encrypting the input text
         * using the remote URL
         * http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionWcf/Service.svc
         */
        private void button1_Click(object sender, EventArgs e)
        {
            EncryptionService.ServiceClient myClient = new EncryptionService.ServiceClient();
       
            try { encryptedText.Text = myClient.Encrypt(plainText.Text); }
            catch (Exception ec) { encryptedText.Text = "Exception: " + ec.Message.ToString(); }
        }

        /*
         * This function handles the event of retrieving the stock quote
         * using the remote URL
         * http://neptune.fulton.ad.asu.edu/WSRepository/Services/Stockquote/Service.svc
         */

        private void button2_Click(object sender, EventArgs e)
        {
            StockQuoteService.ServiceClient stockQuote = new StockQuoteService.ServiceClient();

            try { stockQuoteText.Text = stockQuote.getStockquote(stockSymbolText.Text); }
            catch (Exception ec) { stockQuoteText.Text = "Exception: " + ec.Message.ToString(); }
        }

        /*
         * This function handles the event of decrypting the encrypted text
         * using the remote URL
         * http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionWcf/Service.svc
         */
        private void button3_Click(object sender, EventArgs e)
        {
            EncryptionService.ServiceClient myClient = new EncryptionService.ServiceClient();

            try { decryptedText.Text = myClient.Decrypt(encryptedText.Text); }
            catch (Exception ec) { decryptedText.Text = "Exception: " + ec.Message.ToString(); }
        }
    }
}
