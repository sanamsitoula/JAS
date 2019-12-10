using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class GroupViewModel
    {
        public int group_id { get; set; }
        public string group_name { get; set; }
        public string group_code { get; set; }
        public int user_id { get; set; }

        public DateTimeOffset created_on { get; set; }
    }
}