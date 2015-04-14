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
    public partial class Main_HCP : Form
    {
        public Main_HCP()
        {
            InitializeComponent();
        }

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Text = null;
            textBox2.Visible = true;
            textBox2.Text = null;
            textBox3.Visible = true;
            textBox3.Text = null;
            textBox4.Visible = true;
            textBox4.Text = null;
            textBox5.Visible = true;
            textBox5.Text = null;
            textBox6.Visible = true;
            textBox6.Text = null;
            textBox7.Visible = true;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
        }

        private void editInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Text = null;
            textBox2.Visible = false;
            textBox2.Text = null;
            textBox3.Visible = false;
            textBox3.Text = null;
            textBox4.Visible = false;
            textBox4.Text = null;
            textBox5.Visible = false;
            textBox5.Text = null;
            textBox6.Visible = false;
            textBox6.Text = null;
            textBox7.Visible = true;
            textBox8.Text = null;
            textBox9.Text = "Edit";
            textBox10.Text = null;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = true;
        }

        private void deleteInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Text = null;
            textBox2.Visible = false;
            textBox2.Text = null;
            textBox3.Visible = false;
            textBox3.Text = null;
            textBox4.Visible = false;
            textBox4.Text = null;
            textBox5.Visible = false;
            textBox5.Text = null;
            textBox6.Visible = false;
            textBox6.Text = null;
            textBox7.Visible = true;
            textBox8.Text = null;
            textBox9.Text = "Delete";
            textBox10.Text = null;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = true;
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox1.Text = null;
            textBox2.Visible = false;
            textBox2.Text = null;
            textBox3.Visible = false;
            textBox3.Text = null;
            textBox4.Visible = false;
            textBox4.Text = null;
            textBox5.Visible = false;
            textBox5.Text = null;
            textBox6.Visible = false;
            textBox6.Text = null;
            textBox7.Visible = false;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            Feedback feedback = new Feedback();
            this.Hide();
            feedback.Show();
        }

        private void replyFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox1.Text = null;
            textBox2.Visible = false;
            textBox2.Text = null;
            textBox3.Visible = false;
            textBox3.Text = null;
            textBox4.Visible = false;
            textBox4.Text = null;
            textBox5.Visible = false;
            textBox5.Text = null;
            textBox6.Visible = false;
            textBox6.Text = null;
            textBox7.Visible = false;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;

            Reply reply = new Reply();
            this.Hide();
            reply.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fsw = new FileStream(System.Environment.CurrentDirectory + @"Database.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsw);
            sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t", textBox1.Text, textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text);
            sw.Close();
            fsw.Close();
            if (MessageBox.Show("A new User has been added", "Success", MessageBoxButtons.OK) == DialogResult.OK)
            {
                textBox1.Visible = false;
                textBox1.Text = null;
                textBox2.Visible = false;
                textBox2.Text = null;
                textBox3.Visible = false;
                textBox3.Text = null;
                textBox4.Visible = false;
                textBox4.Text = null;
                textBox5.Visible = false;
                textBox5.Text = null;
                textBox6.Visible = false;
                textBox6.Text = null;
                textBox7.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Database.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            int position = 0;
            string[] users = line.Split('\n');
            for (int x = 0; x < users.Length; x++)
            {
                string[] items = users[x].Split('\t');
                if (items[0] == textBox1.Text)
                {
                    position = x;
                    break;
                }
            }

            users[position] = null;

            FileStream fsw = new FileStream(System.Environment.CurrentDirectory + @"Database.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsw);
            for (int x = 0; x < users.Length - 1; x++)
            {
                if (x == position)
                {
                    continue;
                }
                else
                {
                    sw.WriteLine(users[x]);
                }
            }
            sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t", textBox1.Text, textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text);
            sw.Close();
            fsw.Close();

            if (MessageBox.Show("User's information has been edited", "Success", MessageBoxButtons.OK) == DialogResult.OK)
            {
                textBox1.Visible = false;
                textBox1.Text = null;
                textBox2.Visible = false;
                textBox2.Text = null;
                textBox3.Visible = false;
                textBox3.Text = null;
                textBox4.Visible = false;
                textBox4.Text = null;
                textBox5.Visible = false;
                textBox5.Text = null;
                textBox6.Visible = false;
                textBox6.Text = null;
                textBox7.Visible = false;
                textBox8.Text = null;
                textBox9.Text = null;
                textBox10.Text = null;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Database.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            int position = 0;
            string[] users = line.Split('\n');
            for (int x = 0; x < users.Length; x++)
            {
                string[] items = users[x].Split('\t');
                if (items[0] == textBox1.Text)
                {
                    position = x;
                    break;
                }
            }

            users[position] = null;
  
            FileStream fsw = new FileStream(System.Environment.CurrentDirectory + @"Database.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsw);
            for (int x = 0; x < users.Length-1; x++)
            {
                if (x == position)
                {
                    continue;
                }
                else
                {
                    sw.WriteLine(users[x]);
                }
            }
            sw.Close();
            fsw.Close();

            if (MessageBox.Show("User's information has been deleted", "Success", MessageBoxButtons.OK) == DialogResult.OK)
            {
                textBox1.Visible = false;
                textBox1.Text = null;
                textBox2.Visible = false;
                textBox2.Text = null;
                textBox3.Visible = false;
                textBox3.Text = null;
                textBox4.Visible = false;
                textBox4.Text = null;
                textBox5.Visible = false;
                textBox5.Text = null;
                textBox6.Visible = false;
                textBox6.Text = null;
                textBox7.Visible = false;
                textBox8.Text = null;
                textBox9.Text = null;
                textBox10.Text = null;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Database.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            int position = 0;
            string check = null;
            string[] users = line.Split('\n');
            for (int x = 0; x < users.Length; x++)
            {
                string[] items = users[x].Split('\t');
                if (items[0] == textBox1.Text)
                {
                    check = "Exist";
                    position = x;
                    textBox8.Text = Convert.ToString(x);
                    break;
                }
                else
                {
                    textBox8.Text = null;
                    check = "Does not exist";
                }
            }
            textBox10.Text = check;

            string[] items2 = users[position].Split('\t');
            if (textBox10.Text == "Exist")
            {
                textBox2.Visible = true;
                textBox2.Text = items2[1];
                textBox3.Visible = true;
                textBox3.Text = items2[2];
                textBox4.Visible = true;
                textBox4.Text = items2[3];
                textBox5.Visible = true;
                textBox5.Text = items2[4];
                textBox6.Visible = true;
                textBox6.Text = items2[5];
                button1.Visible = false;
                if (textBox9.Text == "Edit")
                {
                    button2.Visible = true;
                    button3.Visible = false;
                }
                else
                {
                    button2.Visible = false;
                    button3.Visible = true;
                }
                button5.Visible = false;
            }
            else
            {
                if (MessageBox.Show("Email does not exist", "Error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    textBox1.Visible = false;
                    textBox1.Text = null;
                    textBox2.Visible = false;
                    textBox2.Text = null;
                    textBox3.Visible = false;
                    textBox3.Text = null;
                    textBox4.Visible = false;
                    textBox4.Text = null;
                    textBox5.Visible = false;
                    textBox5.Text = null;
                    textBox6.Visible = false;
                    textBox6.Text = null;
                    textBox7.Visible = false;
                    textBox8.Text = null;
                    textBox9.Text = null;
                    textBox10.Text = null;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button5.Visible = false;
                }
            }
        }
    }
}