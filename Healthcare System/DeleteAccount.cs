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
    public partial class DeleteAccount : Form
    {
        public DeleteAccount()
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            string[] item = line.Split('\t');
            string email = item[1];
            string hcspassword = item[2];

            string from = email;
            string tohcp = "cse360_hcp@hotmail.com";
            string tomaintain = "cse360_maintain@hotmail.com";
            string subject = "Delete";
            string smtp = "smtp.live.com";
            int clientport = 587;
            string body = string.Format("Subject: {0} \n User email: {1} \n Reason: {2}", subject, from, richTextBox1.Text);

            if (email == textBox1.Text && hcspassword == textBox3.Text)
            {
                try
                {
                    MailMessage mail1 = new MailMessage(from, tohcp, subject, body);
                    MailMessage mail2 = new MailMessage(from, tomaintain, subject, body);
                    SmtpClient client = new SmtpClient(smtp);
                    client.Port = clientport;
                    client.Credentials = new System.Net.NetworkCredential(email, textBox2.Text);
                    client.EnableSsl = true;
                    client.Send(mail1);
                    client.Send(mail2);

                    if (MessageBox.Show("Your account has been deleted.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        FileStream fsw = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fsw);
                        sw.Write("");
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
                    MessageBox.Show("Either your email password or HCS password is incorrect.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Either your email password or HCS password is incorrect.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}