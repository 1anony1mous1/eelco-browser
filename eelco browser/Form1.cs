using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eelco_browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                webBrowser1.Navigate("https://www.google.com");
                this.Text = webBrowser1.DocumentTitle;
            }
            else
            {
                webBrowser1.Navigate(textBox1.Text);
                this.Text = webBrowser1.DocumentTitle;
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        public void button4_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
        public void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            this.Text = webBrowser1.DocumentTitle;
            timer1.Start();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle;
            
        }
        public void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        // Updates the URL in TextBoxAddress upon navigation.
        public void webBrowser1_Navigated(object sender,
            WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        public void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
        }

        public void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        public void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.GoSearch();
        }
    }
}
