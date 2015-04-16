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
    public partial class Modify : Form
    {
        public Modify()
        {
            InitializeComponent();
            timer1.Start();

            FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            string[] item = line.Split('\t');
            string email = item[1];
            string password = item[2];
            string position = item[3];

            textBox2.Text = email;
            textBox7.Text = position;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from = textBox2.Text;
            string tohcp = "cse360_hcp@hotmail.com";
            string tomaintain = "cse360_maintain@hotmail.com";
            string subject = "Modify";
            string smtp = "smtp.live.com";
            int clientport = 587;
            string email = textBox2.Text;
            string password = textBox3.Text;

            string body = string.Format("Subject: {0} \n User Email: {1} \n User Name: {2} \n User Address: {3} \n User Password: {4} \n User Insurance: {5} \n Social Security Number: {6} \n Position: {7}", subject, from, textBox1.Text, richTextBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
           
            try
            {
                MailMessage mail1 = new MailMessage(from, tohcp, subject, body);
                MailMessage mail2 = new MailMessage(from, tomaintain, subject, body);
                SmtpClient client = new SmtpClient(smtp);
                client.Port = clientport;
                client.Credentials = new System.Net.NetworkCredential(email, password);
                client.EnableSsl = true;
                client.Send(mail1);
                client.Send(mail2);

                if (MessageBox.Show("Your message has been successfully sent.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    FileStream fsw = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fsw);
                    sw.Write(textBox1.Text + '\t' + textBox2.Text + '\t' + textBox4.Text + '\t' + textBox7.Text);
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

        private void button2_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox3.TextLength > 0 && textBox4.TextLength > 0 && textBox5.TextLength > 0 && textBox6.TextLength > 0)
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
