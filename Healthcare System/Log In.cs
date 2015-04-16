using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Healthcare_System
{
    public partial class Log_In : Form
    {
        public Log_In()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadToEnd();
                sr.Close();
                fs.Close();

                string[] item = line.Split('\t');
                string email = item[1];
                string password = item[2];
                string position = item[3];

                if (email == textBox1.Text && password == textBox2.Text)
                {
                    if (position == "User")
                    {
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        Main_HP mainhcp = new Main_HP();
                        mainhcp.Show();
                        this.Hide();
                    }
                }
                else
                {
                    if (MessageBox.Show("Email or Password is Incorrect", "Error", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        textBox1.Text = null;
                        textBox2.Text = null;
                    }
                }
            }
            catch
            {
                MessageBox.Show("You have not sign up", "Error", MessageBoxButtons.OK);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadToEnd();
                sr.Close();
                fs.Close();

                string[] item = line.Split('\t');
                string email = item[1];
                string password = item[2];

                if (textBox1.Text == email)
                {
                    MessageBox.Show(String.Format("Your password is: {0}", password), "Retrieved", MessageBoxButtons.OK);
                }
                else
                {
                    if (MessageBox.Show("Email Address Does Not Exist", "Error", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        textBox1.Text = null;
                        textBox2.Text = null;
                    }
                }
            }
            catch
            {
                MessageBox.Show("You have not sign up", "Error", MessageBoxButtons.OK);
            }
        }
    }
}