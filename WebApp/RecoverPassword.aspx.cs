using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;
using System.Web.Security;
using BLL;
using DAL;

namespace WebApp
{
    public partial class Recover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            LecturerHandler lecturerHandler = new LecturerHandler();
            Lecturer lecturer = null;
            BusinessHandler businessHandler = null;
            Business business = null;

            string destinationEmail = txtEmail.Value;

            //check email exists
            if (lecturerHandler.ValidateEmail(destinationEmail) == false)
            {
                //email doesn't exist in DB
                litAlert.Text = "<div class='alert alert-danger'>Invalid Email Address</div>";
            }

            else
            {
                //get business email and password
                string name, email, password, emailServer, newPassword;
                int port;

                businessHandler = new BusinessHandler();
                business = new Business();
                business = businessHandler.GetBusinessDetails();

                name = business.Name;
                email = business.Email;
                password = business.EmailPassword;
                emailServer = business.EmailServer;
                port = business.EmailPort;

                //generate new password
                newPassword = Membership.GeneratePassword(7, 0);

                //update database
                lecturer = new Lecturer();
                lecturer.Email = destinationEmail;
                lecturer.Password = newPassword;

                //send email
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient(emailServer);
                    mail.From = new MailAddress(email);
                    mail.To.Add(destinationEmail);
                    mail.Subject = name + " Password Reset";
                    mail.Body = "Your password has been reset. Please use the following phrase as your new password when you log in: " + newPassword;

                    //code to include an attatchment
                    //System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment("attatchment.jpg");
                    //mail.Attachments.Add(attachment);

                    smtpClient.Port = port;
                    smtpClient.Credentials = new NetworkCredential(email, password);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail);
                    lecturerHandler.UpdateLecturerPassword(lecturer);

                    litAlert.Text = "<div class='alert alert-success'>An email was sent, check you email for your new password.</div>";

                    //delay redirect to alert user of page change
                    /*lblRedirect.Text = "Redirecting to log in, in 5 seconds.";
                    Response.Write("<script type=\"text/javascript\">setTimeout(function () { window.location.href = \"Login.aspx\"; }, 5000);</script>");*/
                }
                catch (Exception)
                {
                    litAlert.Text = "<div class='alert alert-warning'>Failed to send an email</div>";
                }
            }
        }
    }
}