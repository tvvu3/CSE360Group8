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


namespace Healthcare_System
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string from = textBox1.Text;
            string to = "leon_ken92@hotmail.com";
            string subject = "Feedback";
            string smtp = null;
            int clientport = 0;
            string email = textBox1.Text;
            string password = textBox2.Text;

            string body = string.Format("Subject: {0} \n User Email: {1} \n Questions/Feedbacks: {2}",subject, textBox1.Text, richTextBox1.Text);
            if (comboBox1.Text == "Yahoo")
            {
                smtp = "smtp.mail.yahoo.com";
                clientport = 465;
            }
            else if (comboBox1.Text == "Gmail")
            {
                smtp = "smtp.gmail.com";
                clientport = 465;
            }
            else
            {
                smtp = "smtp.live.com";
                clientport = 587;
            }
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
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Either your e-mail or password incorrect.", "Error", MessageBoxButtons.OK);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
        }
    }
}
