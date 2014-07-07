using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HostingPsDemo
{
    public partial class Form1 : Form, IWrapper
    {
        delegate void Thing();
        delegate void Setter(string value);

        private Runner _host;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                PressButton1();
            });
        }

        private void PressButton1()
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = "You pressed button1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                PressButton2();
            });
        }

        private void PressButton2()
        {
            lblStatus.ForeColor = Color.BlueViolet;
            lblStatus.Text = "You pressed button2";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _host = new Runner(this);
        }

        public string Status
        {
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = value;
                });
            }
        }

        public string Output
        {
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblOutput.Text = value;
                });
            }
        }

        public void FirstButton()
        {
            button1_Click(null, null);
        }

        public void SecondButton()
        {
            button2_Click(null, null);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            _host.Execute(txtScript.Text);
        }
    }
}
