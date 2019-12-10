using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class RolesViewModel
    {
        public int? user_role_assigned_id { get; set; }
        public int? user_id { get; set; }
        public int? role_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_id { get; set; }
        public DateTimeOffset? dateofbirth { get; set; }
        public bool? isEmailVerified { get; set; }
        public string role_name { get; set; }
        public string user_name { get; set; }

    }

    public partial class RoleNamesViewModel
    {
        public int role_id { get; set; }
        public string role_name { get; set; }
    }


    public partial class UpdateRolesViewModel
    {
        public int user_role_assigned_id { get; set; }
        public int user_id { get; set; }
        public int role_id { get; set; }
    }
}