using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Healthcare_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewForm newform = new NewForm();
            this.Hide();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sign_Up signup = new Sign_Up();
            this.Hide();
            signup.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"firefox.exe", "http:@www." + "facebook" + ".com/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteAccount deleteaccount = new DeleteAccount();
            this.Hide();
            deleteaccount.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback();
            this.Hide();
            feedback.Show();
        }
    }
}
