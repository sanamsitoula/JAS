using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface IUserServices
    {
        string UserRegistration(UserViewModel model);
        bool IsExistEmail(string email_id);

        string Confirm_Registration_Mail(string Activattion_code);
        UserViewModel GetUserById(int id);
        UserViewModel UpdateUser(UserViewModel model);
    }
}