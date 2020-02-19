using MvcEvent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MvcEvent.Controllers
{
    public class SignUpController : Controller
    {
        //
        // GET: /SignUp/
        SignUpDal SignUpDal = new SignUpDal();
        SMS objSMS = new SMS();
        string strmobileOtp = string.Empty, stremailotp = string.Empty;
        string strFromMail = WebConfigurationManager.AppSettings["FromMail"];
        string strpwd = WebConfigurationManager.AppSettings["Pwd"];
        string strPort = WebConfigurationManager.AppSettings["Port"];
        string strHost = WebConfigurationManager.AppSettings["Host"];
        string strresult = "false";
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult signup(SignUp signup)
        {
            try
            {
                strmobileOtp = CreateMobileOtp();
                stremailotp = CreateEmailOtp();

                string strsuccess = SignUpDal.CreateSignUp(0, signup.fullName, signup.email, signup.mobileNo, signup.pwd, signup.pwd, strmobileOtp, stremailotp, 1);
                if (strsuccess != string.Empty)
                {
                    SendActivationEmail(signup.email);
                    string strmsgsuccess = objSMS.SendSMS(signup.mobileNo, strmobileOtp);
                }

            }
            catch (Exception ex)
            {
                CreateErrorlog.WriteError(ex.Message.ToString() + "\r\n" + ex.StackTrace);
            }
            return Json(new { Success = strresult });
        }

        private static string CreateMobileOtp(int length = 6)
        {
            string validChars = "1234567890";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        private static string CreateEmailOtp(int length = 6)
        {
            string validChars = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }


        private void SendActivationEmail(string strToMail)
        {
            try
            {

                var credentials = new NetworkCredential(strFromMail, strpwd);
                var mail = new MailMessage()
                {
                    From = new MailAddress(strFromMail),
                    Subject = "Account Activation",
                    Body = "Hello  " + "<b>" + strToMail + "</b>" + "<br /><br />" + "<b>" + "Email Activation Code : " + "</b>" + "<b>" + stremailotp + "</b>" + "<br />",
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(strToMail));
                var client = new SmtpClient()
                {
                    Port = Convert.ToInt32(strPort),
                    Host = strHost,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
            }

            catch (Exception ex)
            {
                //CreateErrorlog.WriteError(this.Page, ex.Message.ToString() + "\r\n" + ex.StackTrace);
            }
        }

        public JsonResult GetSignUp(SignUp SignUp)
        {
            var signuplist = SignUpDal.ListAllSignUp();
            return Json(signuplist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult verifyMobileOTP(SignUp SignUp)
        {
            var result = new { Success = "false" };
            DataTable dt = SignUpDal.VerifyMobileOtp(SignUp.mobileNo, SignUp.mobileOtp);
            if (dt.Rows.Count > 0)
            {
                string strsuccess = SignUpDal.UpdMobileVerify(SignUp.mobileNo);
                if (strsuccess != string.Empty)
                {
                    result = new { Success = "true" };
                }
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult verifyEmailOTP(SignUp SignUp)
        {
            var result = new { Success = "false" };
            DataTable dt = SignUpDal.VerifyEmailOtp(SignUp.email, SignUp.emailOtp);
            if (dt.Rows.Count > 0)
            {
                string strsuccess = SignUpDal.UpdEmailVerify(SignUp.email);
                if (strsuccess != string.Empty)
                {
                    result = new { Success = "true" };
                }
            }

            return Json(result);
        }


    }
}
