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
            string email = item[0];
            string hcspassword = item[1];

            string from = email;
            string tohcp = "cse360_hcp@hotmail.com";
            string tomaintain = "cse360_maintain@hotmail.com";
            string subject = "Delete";
            string smtp = null;
            int clientport = 0;
            string body = string.Format("Subject: {0} \n User email: {1} \n Reason: {2}", subject, from, richTextBox1.Text);

            if (comboBox1.Text == "yahoo")
            {
                smtp = "smtp.mail.yahoo.com";
                clientport = 465;
            }
            else if (comboBox1.Text == "gmail")
            {
                smtp = "smtp.gmail.com";
                clientport = 465;
            }
            else
            {
                smtp = "smtp.live.com";
                clientport = 587;
            }

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
                        sw.Write("NULL" + "\t" + "NULL" + "\t" + "NULL");
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
            else
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