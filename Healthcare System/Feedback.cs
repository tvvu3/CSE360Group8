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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
            FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            string[] item = line.Split('\t');
            textBox1.Text = item[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Main)
                {
                    form.Show();
                    break;
                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            string from = textBox1.Text;
            string to = "cse360_maintain@hotmail.com";
            string subject = "Feedback";
            string smtp = "smtp.live.com";
            int clientport = 587;
            string email = textBox1.Text;
            string password = textBox2.Text;

            string body = string.Format("Subject: {0} \n User Email: {1} \n Questions/Feedbacks: {2}",subject, textBox1.Text, richTextBox1.Text);
           
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
                        if (form is Main)
                        {
                            form.Show();
                            break;
                        }                       
                    }
                    this.Close();
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
                MessageBox.Show("Your password incorrect.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
