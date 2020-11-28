using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using prjCardDashboardWebAPI.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using prjCardDashboardWebAPI.ViewModels;
using System.Data.Entity;


namespace prjCardDashboardWebAPI.Controllers
{
    public class OTPController : ApiController
    {
        private FinanceEntities db = new FinanceEntities();

        [HttpGet]
        [Route("api/OTP/VerifyEmail")]
        public IHttpActionResult VerifyEmail(string email)
        {
            var isValidEmail = db.ConsumerTables.Where(w => w.Email == email).FirstOrDefault();
            if (isValidEmail != null)
            {
                GetOtp(email);
                return Ok("Success");
            }
            else
                return Ok("InvalidUser");
        }
        [Route("api/OTP/GetOtp")]
        private async Task<int> GetOtp(string email)
        {
            var user = db.ConsumerTables.Where(w => w.Email == email).FirstOrDefault();

            var otpData = db.OTP_Validation.Where(w => w.UserName == user.UserName).FirstOrDefault();
            if (otpData != null)
            {
                db.OTP_Validation.Remove(otpData);
                db.SaveChanges();
            }

            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            OTP_Validation otp = new OTP_Validation();
            otp.UserName = user.UserName;
            otp.OTP_Sent = r;
            db.OTP_Validation.Add(otp);
            db.SaveChanges();

            SmtpClient smtp = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("gladiatorfinance@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Forgot Password";
            mailMessage.Body = "Dear User,Please use the given OTP to Login " + r;
            await Task.Run(() => smtp.SendAsync(mailMessage, null));
            return r;
        }
        [Route("api/OTP/ResendOtp")]
        private async Task ResendOtp(string email)
        {
            var user = db.ConsumerTables.Where(w => w.Email == email).FirstOrDefault();
            var otpData = db.OTP_Validation.Where(w => w.UserName == user.UserName).FirstOrDefault();

            SmtpClient smtp = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("gladiatorfinance@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Forgot Password";
            mailMessage.Body = "Dear User,Please use the given OTP to Login " + otpData.OTP_Sent;
            await Task.Run(() => smtp.SendAsync(mailMessage, null));
        }

        [HttpPost]
        [Route("api/OTP/ChangePassword")]
        public IHttpActionResult ChangePassword(ChangePassword changePassword)
        {
            var user = db.ConsumerTables.Where(w => w.Email == changePassword.Email).FirstOrDefault();
            if (user != null)
            {
                var isOtpValid = db.OTP_Validation.Where(w => w.OTP_Sent == changePassword.OTP && w.UserName == user.UserName).FirstOrDefault();
                if (isOtpValid != null)
                {
                    user.Password = changePassword.Password;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    var otpData = db.OTP_Validation.Where(w => w.UserName == user.UserName && w.OTP_Sent == changePassword.OTP).FirstOrDefault();
                    if (otpData != null)
                    {
                        db.OTP_Validation.Remove(otpData);
                        db.SaveChanges();
                    }
                    return Ok("Success");
                }
                else
                {
                    return Ok("Invalid OTP.");
                }
            }
            else
                return Ok("Error occured in updating password! Please try again later.");

        }
       
    }
}
