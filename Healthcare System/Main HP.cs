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
    public partial class Main_HP : Form
    {
        public static string sendtext = "";

        public Main_HP()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback();
            this.Hide();
            feedback.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "add";
            sendtext = textBox1.Text;
            Main_HCP mainhcp = new Main_HCP();
            mainhcp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "edit";
            sendtext = textBox1.Text;
            Main_HCP mainhcp = new Main_HCP();
            mainhcp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "delete";
            sendtext = textBox1.Text;
            Main_HCP mainhcp = new Main_HCP();
            mainhcp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reply reply = new Reply();
            this.Hide();
            reply.Show();
        }
    }
}
