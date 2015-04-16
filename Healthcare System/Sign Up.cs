using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;
using System.IO;

namespace Healthcare_System
{
    public partial class Sign_Up : Form
    {
        string position = null;

        public Sign_Up()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
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
            string from = textBox2.Text + textBox3.Text;
            string tohcp = "cse360_hcp@hotmail.com";
            string tomaintain = "cse360_maintain@hotmail.com";
            string subject = "Sign Up";
            string smtp = "smtp.live.com";
            int clientport = 587;
            string email = from;
            string password = textBox4.Text;

            string body = string.Format("Subject: {0} \n User Email: {1} \n User Name: {2} \n User Address: {3} \n User Password: {4} \n User Insurance: {5} \n Social Security Number: {6} \n Position: {7}", subject, from, textBox1.Text, richTextBox1.Text, textBox5.Text, textBox6.Text, textBox7.Text, position);

            try
            {
                MailMessage mail1 = new MailMessage(from, tohcp, subject, body);
                MailMessage mail2 = new MailMessage(from, tomaintain, subject, body);
                SmtpClient client = new SmtpClient(smtp);
                client.Port = clientport;
                client.Credentials = new System.Net.NetworkCredential(email, password);
                client.EnableSsl = true;
                if (position == "User")
                {
                    client.Send(mail1);
                    client.Send(mail2);
                }
                else
                {
                    client.Send(mail2);
                }

                if (MessageBox.Show("Your message has been successfully sent.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    FileStream fsw = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fsw);
                    sw.Write(textBox1.Text + '\t' + textBox2.Text+textBox3.Text + '\t' + textBox5.Text + '\t' + position);
                    sw.Close();
                    fsw.Close();

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
            }

            catch (Exception)
            {
                MessageBox.Show("Either your e-mail or password incorrect.", "Error", MessageBoxButtons.OK);

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            position = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            position = radioButton2.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox4.TextLength > 0 && textBox5.TextLength > 0 && textBox6.TextLength > 0 && textBox7.TextLength > 0 && (radioButton1.Checked == true || radioButton2.Checked == true))
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }
    }
}
