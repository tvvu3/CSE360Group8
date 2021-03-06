﻿using System;
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
            string from = textBox2.Text;
            string to = "leon_ken92@hotmail.com";
            string subject = "Sign Up";
            string smtp = null;
            int clientport = 0;
            string email = textBox2.Text;
            string password = textBox3.Text;

            string body = string.Format("Subject: {0} \n User Email: {1} \n User Name: {2} \n User Address: {3} \n User Password: {4} \n User Insurance: {5} \n Social Security Number: {6} \n Position: {7}", subject, from, textBox1.Text, richTextBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text, position);
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
                    FileStream fsw = new FileStream(System.Environment.CurrentDirectory + @"Data.txt", FileMode.Create,FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fsw);
                    sw.Write(textBox2.Text + '\t' + textBox4.Text + '\t' + position);
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
                if (MessageBox.Show("Either your e-mail or password incorrect.", "Error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    textBox1.Text = null;
                    richTextBox1.Text = null;
                    textBox2.Text = null;
                    comboBox1.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;
                    button1.Visible = false;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            radioButton1.Checked = true;
            position = radioButton1.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            position = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            position = radioButton2.Text;
        }
    }
}
