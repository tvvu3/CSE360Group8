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
    public partial class NewForm : Form
    {
        string condition1 = null;
        string condition2 = null;
        string condition3 = null;
        string condition4 = null;

        public NewForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
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
            ConditionValue();

            string from = textBox5.Text;
            string to = "cse360_hcp@hotmail.com";
            string subject = "Form";
            string smtp = null;
            int clientport = 0;
            string email = textBox5.Text;
            string password = textBox6.Text;

            string body = string.Format("Subject: {0} \n User Email: {1} \n Pain/Symptoms(1): {2} Level: {3} \n Pain/Symptoms(2): {4} Level: {5} \n Pain/Symptoms(3): {6} Level: {7} \n Pain/Symptoms(4): {8} Level: {9} \n Comments: {10}", subject, from, textBox1.Text, condition1, textBox2.Text, condition2, textBox3.Text, condition3, textBox4.Text, condition4, richTextBox1.Text);
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
                if (MessageBox.Show("Either your e-mail or password incorrect.", "Error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    textBox1.Text = null;
                    groupBox1.Visible = false;

                    textBox2.Text = null;
                    groupBox2.Visible = false;

                    textBox3.Text = null;
                    groupBox3.Visible = false;

                    textBox4.Text = null;
                    groupBox4.Visible = false;

                    richTextBox1.Text = null;
                    comboBox1.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;                    
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            radioButton1.Checked = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            radioButton4.Checked = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            radioButton7.Checked = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            radioButton10.Checked = true;
        }

        private void ConditionValue()
        {
            if (radioButton1.Checked == true)
            {
                condition1 = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                condition1 = radioButton2.Text;
            }
            else
            {
                condition1 = radioButton3.Text;
            }
            if (radioButton4.Checked == true)
            {
                condition2 = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                condition2 = radioButton5.Text;
            }
            else
            {
                condition2 = radioButton6.Text;
            }
            if (radioButton7.Checked == true)
            {
                condition3 = radioButton7.Text;
            }
            else if (radioButton8.Checked == true)
            {
                condition3 = radioButton8.Text;
            }
            else
            {
                condition3 = radioButton9.Text;
            }
            if (radioButton10.Checked == true)
            {
                condition4 = radioButton10.Text;
            }
            else if (radioButton11.Checked == true)
            {
                condition4 = radioButton11.Text;
            }
            else
            {
                condition4 = radioButton12.Text;
            }
        }
    }
}
