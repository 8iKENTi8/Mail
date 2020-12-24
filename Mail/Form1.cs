using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using MetroFramework.Forms;

namespace Mail
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient()
            {
                //Разрешить небезопастным предложения отправлять письма в гугл
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "roldugin.67@gmail.com",
                    Password = "H3yIybYJG"
                }
            };

            MailAddress mail = new MailAddress("roldugin.67@gmail.com",
                "Vladimir");

            MailAddress tomail = new MailAddress(emailtxt.Text,
                "Someone");

            MailMessage message = new MailMessage()
            {
                From = mail,
                Subject = textBox2.Text,
                Body = textBox3.Text,
            };

            message.To.Add(tomail);

            try
            {
                client.Send(message);
                MessageBox.Show("Сообщение отправлено");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }
    }
}
