using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleTreadForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WebClient wb = new WebClient();
            //string str = wb.DownloadString("http://www.bbc.com/");
            //this.textBox1.Text = str;

            //ThreadPool.QueueUserWorkItem(state =>
            //{
            //WebClient wb = new WebClient();
            //string str = wb.DownloadString("http://www.bbc.com/");
            //    textBox1.BeginInvoke(new Action(()=> {
            //        textBox1.Text = str;
            //    }));
            //});

            #region EAP风格
            WebClient wb = new WebClient();
            wb.DownloadStringCompleted += WB_DownStringCompleted;
            wb.DownloadStringAsync(new Uri("http://www.bbc.com/"));
            #endregion
        }

        private void WB_DownStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            textBox1.Text = e.Result;
        }
    }
}
