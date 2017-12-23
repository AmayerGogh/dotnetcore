using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(Run1);
            //thread.Start();

            //while (true)
            //{
            //    Console.WriteLine("子线程" + DateTime.Now);
            //    //txt.Text += "主线程" + DateTime.Now + "\r\n";
            //}

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread((j) =>
                {
                    Console.WriteLine($"i={j}");
                });
                thread.Start(i);
            }
        }

        private void Run1()
        {
            while (true)
            {
                Console.WriteLine("子线程" + DateTime.Now);
                //txt.Text += "子线程" + DateTime.Now + "\r\n";
            }
        }
    }
}
