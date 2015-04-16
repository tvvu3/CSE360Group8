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
    public partial class NewForm : Form
    {
        string condition1 = null;
        string condition2 = null;
        string condition3 = null;
        string condition4 = null;
        string symptom1 = null;
        string symptom2 = null;
        string symptom3 = null;
        string symptom4 = null;

        public NewForm()
        {
            InitializeComponent();
            timer1.Start();

            FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            string[] item = line.Split('\t');
            textBox5.Text = item[1];
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
            Condition();

            string from = textBox5.Text;
            string to = "cse360_hcp@hotmail.com";
            string subject = "Form";
            string smtp = "smtp.live.com";
            int clientport = 587;
            string email = textBox5.Text;
            string password = textBox6.Text;

            string body = string.Format("Subject: {0} \n User Email: {1} \n Pain/Symptoms(1): {2} Level: {3} \n Pain/Symptoms(2): {4} Level: {5} \n Pain/Symptoms(3): {6} Level: {7} \n Pain/Symptoms(4): {8} Level: {9} \n Comments: {10}", subject, from, symptom1, condition1, symptom2, condition2, symptom3, condition3, symptom4, condition4, richTextBox1.Text);
            
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
                if (MessageBox.Show("Your password incorrect.", "Error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    condition1 = null;
                    condition2 = null;
                    condition3 = null;
                    condition4 = null;
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                condition1 = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                condition1 = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                condition1 = radioButton3.Text;
            }
            else
            {
                condition1 = "Null";
            }
            if (radioButton4.Checked == true)
            {
                condition2 = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                condition2 = radioButton5.Text;
            }
            else if (radioButton6.Checked == true)
            {
                condition2 = radioButton6.Text;
            }
            else
            {
                condition2 = "Null";
            }
            if (radioButton7.Checked == true)
            {
                condition3 = radioButton7.Text;
            }
            else if (radioButton8.Checked == true)
            {
                condition3 = radioButton8.Text;
            }
            else if (radioButton9.Checked == true)
            {
                condition3 = radioButton9.Text;
            }
            else
            {
                condition3 = "Null";
            }
            if (radioButton10.Checked == true)
            {
                condition4 = radioButton10.Text;
            }
            else if (radioButton11.Checked == true)
            {
                condition4 = radioButton11.Text;
            }
            else if (radioButton12.Checked == true)
            {
                condition4 = radioButton12.Text;
            }
            else
            {
                condition4 = "Null";
            }

            if (textBox1.TextLength < 1)
            {
                groupBox1.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
            }
            else
            {
                groupBox1.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
            }
            if (textBox2.TextLength < 1)
            {
                groupBox2.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
                radioButton6.Visible = false;
            }
            else
            {
                groupBox2.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                radioButton6.Visible = true;
            }
            if (textBox3.TextLength < 1)
            {
                groupBox3.Visible = false;
                radioButton7.Visible = false;
                radioButton8.Visible = false;
                radioButton9.Visible = false;
            }
            else
            {
                groupBox3.Visible = true;
                radioButton7.Visible = true;
                radioButton8.Visible = true;
                radioButton9.Visible = true;
            }
            if (textBox4.TextLength < 1)
            {
                groupBox4.Visible = false;
                radioButton10.Visible = false;
                radioButton11.Visible = false;
                radioButton12.Visible = false;
            }
            else
            {
                groupBox4.Visible = true;
                radioButton10.Visible = true;
                radioButton11.Visible = true;
                radioButton12.Visible = true;
            }
        }

        public void Condition()
        {
            if (textBox1.TextLength < 1)
            {
                symptom1 = "Null";
                condition1 = "Null";
            }
            else
            {
                symptom1 = textBox1.Text;
            }
            if (textBox2.TextLength < 1)
            {
                symptom2 = "Null";
                condition2 = "Null";
            }
            else
            {
                symptom2 = textBox2.Text;
            }
            if (textBox3.TextLength < 1)
            {
                symptom3 = "Null";
                condition3 = "Null";
            }
            else
            {
                symptom3 = textBox3.Text;
            }
            if (textBox4.TextLength < 1)
            {
                symptom4 = "Null";
                condition4 = "Null";
            }
            else
            {
                symptom4 = textBox4.Text;
            }
        }
    }
}
