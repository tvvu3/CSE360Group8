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
        string symptom1 = null;
        string symptom2 = null;
        string symptom3 = null;
        string symptom4 = null;
        string condition1 = null;
        string condition2 = null;
        string condition3 = null;
        string condition4 = null;

        public Reply()
        {
            InitializeComponent();
            timer1.Start();
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
                textBox1.ReadOnly = true;
                button1.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                MessageBox.Show("Email does not exist", "Error", MessageBoxButtons.OK);
                textBox1.Text = null;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Main_HP)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string from = "cse360_hcp@hotmail.com";
            string to = textBox1.Text;
            string subject = textBox6.Text;
            string smtp = "smtp.live.com"; ;
            int clientport = 587;
            string email = "cse360_hcp@hotmail.com";
            string password = "Qwerty78";
            string body = string.Format("Hi {0},\nRegarding your pain/symptoms:\n1){1}\tLevel of pain:{2}\n2){3}\tLevel of pain:{4}\n3){5}\tLevel of pain:{6}\n4){7}\tLevel of pain:{8}\nWe strongly recommend that:{9}\n\nRegards,\nHealthcare Provider", textBox9.Text, symptom1, condition1, symptom2, condition2, symptom3, condition3, symptom4, condition4, richTextBox1.Text);

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
                        if (form is Main_HP)
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
                        if (form is Main_HP)
                        {
                            form.Show();
                            break;
                        }
                    }
                    this.Close();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 1)
            {
                symptom1 = "Null";
                condition1 = "Null";
            }
            else
            {
                symptom1 = textBox2.Text;
                condition1 = comboBox1.Text;
            }
            if (textBox3.TextLength < 1)
            {
                symptom2 = "Null";
                condition2 = "Null";
            }
            else
            {
                symptom2 = textBox3.Text;
                condition2 = comboBox2.Text;
            }
            if (textBox4.TextLength < 1)
            {
                symptom3 = "Null";
                condition3 = "Null";
            }
            else
            {
                symptom3 = textBox4.Text;
                condition3 = comboBox3.Text;
            }
            if (textBox5.TextLength < 1)
            {
                symptom4 = "Null";
                condition4 = "Null";
            }
            else
            {
                symptom4 = textBox5.Text;
                condition4 = comboBox4.Text;
            }
        }
    }
}