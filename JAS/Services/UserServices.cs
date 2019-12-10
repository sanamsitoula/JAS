using Dapper;
using JAS.Crypto;
using JAS.DAL;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace JAS.Services
{
    public class UserServices :IUserServices
    {
        protected DbConn db;
       // private RestClient restClient = new RestClient();
        string host= System.Web.HttpContext.Current.Request.Url.Host;
        string scheme = System.Web.HttpContext.Current.Request.Url.Scheme;

        string port = System.Web.HttpContext.Current.Request.Url.Port.ToString();
        public UserServices()
        {
            db = new DbConn();
        }

        public string UserRegistration(UserViewModel model)
        {


            var emailExist = IsExistEmail(model.email_id);

            if (!emailExist )
            {

                var user = new UserViewModel()
                {
                    user_name = model.user_name,
                    first_name = model.first_name,
                    last_name = model.last_name,
                    email_id = model.email_id,
                    //dateofbirth = model.dateofbirth,
                    Password = CryptoMethod.Hash(model.Password),
                ActivationCode= Guid.NewGuid(),
                isEmailVerified =model.isEmailVerified
            };



               string  FriendList = "insert into users(user_name,first_name,last_name,email_id,password,isEmailVerified,ActivationCode) select '" + model.user_name + "','" + model.first_name+"','"+model.last_name+"','"+model.email_id+"','"+ user.Password + "',0,'" + user.ActivationCode +"'";
                var conn = db.ConnStrg();

                int rowsAffected = conn.Execute(FriendList);

                if (rowsAffected > 0)
                {
                    SendVerificationLinkEmail(user.email_id, user.ActivationCode.ToString(),scheme,host,port);
                    return "Registration has been done,And Account activation link has been sent your email id:" +user.email_id ;
                }
                else
                {
                    return "Registration has been Faild";

                }

            }


            // model.ActivationCode = Guid.NewGuid();
            // model.IsEmailVerified = true; //TODO
            //verify.SendVerificationLinkEmail("ok", "ok");

            return "ok";
        }

        public bool IsExistEmail(string email_id)
        {

            var conn = db.ConnStrg();

            var hasEmail = conn.Execute("select email_id from users where email_id='" +email_id+"'");

            //int rowsAffected = conn.Execute(hasEmail);

            return false;
        }

        private void SendVerificationLinkEmail(string emailId, string activationcode, string scheme, string host, string port)
        {
            var varifyUrl = scheme + "://" + host + ":" + port + "/api/user/confirmemail?Activation_code=" + activationcode;
            var fromMail = new MailAddress("sanam.percoidit@gmail.com", "Jugad Accouting System");
            var toMail = new MailAddress(emailId);
            var frontEmailPassowrd = "sanambhai24#";
            string subject = "Your account is successfull created";
            string body = "<br/><br/>We are excited to tell you that your account is" +
        " successfully created. Please click on the below link to verify your account" +
        " <br/><br/><a href='" + varifyUrl + "'>" + varifyUrl + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, frontEmailPassowrd)

            };
            using (var message = new MailMessage(fromMail, toMail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
               
            try
            {
                    smtp.Send(message);
                }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            }
        }



         public string Confirm_Registration_Mail(string ActivationCode)
        {
            string str = "";
            var conn = db.ConnStrg();

            string sqlQuery = "update users set isEmailVerified = 1  where ActivationCode='"+ActivationCode+ "'";

            int rowsAffected = conn.Execute(sqlQuery);
            if (rowsAffected > 0)
            {
                
                str = "Dear user, Your email successfully activated now you can able to login";
            }
            else
            {
                str = "Dear user, Your email not activated";
            }

            return str;
        }


     

        public UserViewModel GetUserById(int id)
        {
            var conn = db.ConnStrg();
            UserViewModel _friend = new UserViewModel();

            _friend = conn.Query<UserViewModel>("Select * From users " +
                                   "WHERE user_id =" + id, new { id }).SingleOrDefault();

            return (_friend);
        }

        public UserViewModel UpdateUser(UserViewModel model)
        {
            throw new NotImplementedException();
        }


        public string  CreatePasswordCreatePas(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}