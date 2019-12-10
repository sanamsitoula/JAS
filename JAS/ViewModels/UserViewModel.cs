using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class UserViewModel
    {
        public int? user_id { get; set; }
    
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_id { get; set; }
        public DateTimeOffset? dateofbirth { get; set; }

        public string Password { get; set; }
        public bool isEmailVerified { get; set; }
        public string user_name { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string ConfirmPassword { get; set; }
        public bool? IsChecked { get; set; }
        public string role_name { get; set; }
       
    }

    public partial class RegisterViewModel
    {
        public int? user_id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_id { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string Password { get; set; }
        public bool isEmailVerified { get; set; }
        public bool? IsChecked { get; set; }
        public string user_name { get; set; }
    }
}