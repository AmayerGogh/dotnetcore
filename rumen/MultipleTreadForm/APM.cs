using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleTreadForm
{
    public partial class APM : Form
    {
        public APM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = File.OpenRead("1.txt"))
            {
                byte[] buffer = new byte[20];
                var result = fs.BeginRead(buffer, 0, buffer.Length, null, null);
                string s = "";
                //result.AsyncWaitHandle.WaitOne();
                while (result.AsyncWaitHandle.WaitOne())
                {
                    s += Encoding.UTF8.GetString(buffer);
                }
                this.textBox1.Text = s;
                fs.EndRead(result);
            }
        }
    }
}
