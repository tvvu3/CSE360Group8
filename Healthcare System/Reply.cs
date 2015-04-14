using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Net.Mail;

namespace Healthcare_System
{
    public partial class Reply : Form
    {
        public Reply()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Main_HCP)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    textBox7.Text = Convert.ToString(x);
                    break;
                }
                else
                {
                    textBox7.Text = null;
                    check = "Does not exist";
                }
            }
            textBox8.Text = check;

            string[] items2 = users[position].Split('\t');
            if (textBox8.Text == "Exist")
            {
                textBox9.Text = items2[1];
                label2.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = false;
                textBox1.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Email does not exist", "Error", MessageBoxButtons.OK);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != null)
            {
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            textBox2.Text = null;
            comboBox2.Text = "null";
            textBox3.Text = null;
            comboBox3.Text = "null";
            textBox4.Text = null;
            comboBox4.Text = "null";
            textBox5.Text = null;
            comboBox5.Text = "null";

            if (comboBox1.Text == "1")
            {
                textBox2.Visible = true;
                comboBox2.Visible = false;
                textBox3.Visible = false;
                comboBox3.Visible = false;
                textBox4.Visible = false;
                comboBox4.Visible = false;
                textBox5.Visible = false;
                comboBox5.Visible = false;
            }
            else if (comboBox1.Text == "2")
            {
                textBox2.Visible = true;
                comboBox2.Visible = false;
                textBox3.Visible = true;
                comboBox3.Visible = false;
                textBox4.Visible = false;
                comboBox4.Visible = false;
                textBox5.Visible = false;
                comboBox5.Visible = false;
            }
            else if (comboBox1.Text == "3")
            {
                textBox2.Visible = true;
                comboBox2.Visible = false;
                textBox3.Visible = true;
                comboBox3.Visible = false;
                textBox4.Visible = true;
                comboBox4.Visible = false;
                textBox5.Visible = false;
                comboBox5.Visible = false;
            }
            else
            {
                textBox2.Visible = true;
                comboBox2.Visible = false;
                textBox3.Visible = true;
                comboBox3.Visible = false;
                textBox4.Visible = true;
                comboBox4.Visible = false;
                textBox5.Visible = true;
                comboBox5.Visible = false;
            }

            label5.Visible = true;
            textBox6.Visible = true;
            label6.Visible = true;
            richTextBox1.Visible = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button5.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            comboBox5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string from = "cse360_hcp@hotmail.com";
            string to = textBox1.Text;
            string subject = textBox6.Text;
            string smtp = "smtp.live.com"; ;
            int clientport = 587;
            string email = "cse360_hcp@hotmail.com";
            string password = "Qwerty78";
            string body = string.Format("Hi {0},\nRegarding your pain/symptoms:\n1){1}\tLevel of pain:{2}\n2){3}\tLevel of pain:{4}\n3){5}\tLevel of pain:{6}\n4){7}\tLevel of pain:{8}\nWe strongly recommend that:{9}\n\nRegards,\nHealthcare Provider", textBox9.Text, textBox2.Text, comboBox2.Text, textBox3.Text, comboBox3.Text, textBox4.Text, comboBox4.Text, textBox5.Text, comboBox5.Text, richTextBox1.Text);

              try
            {
                MailMessage mail = new MailMessage(from, to, subject, body);
                SmtpClient client = new SmtpClient(smtp);
                client.Port = clientport;
                client.Credentials = new System.Net.NetworkCredential(email, password);
                client.EnableSsl = true;
                client.Send(mail);

                if (MessageBox.Show("Your message has been successfully sent.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Main_HCP)
                        {
                            form.Show();
                            break;
                        }
                    }
                    this.Close();
                }
            }

            catch (Exception)
            {
                if (MessageBox.Show("There seems to be an error.\nPlease send a feedback to maintainance.", "Error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Main_HCP)
                        {
                            form.Show();
                            break;
                        }
                    }
                    this.Close();
                }
            }
        }
    }
}