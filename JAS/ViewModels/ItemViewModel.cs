using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class ItemViewModel
    {
        public int? item_id { get; set; }
        public string item_name { get; set; }

        public string item_code { get; set; }

        public string item_description { get; set; }

        public string photo { get; set; }
        public int? group_id { get; set; }
        public int? user_id { get; set; }

        public int? item_sp { get; set; }
        public int? item_cp { get; set; }
        public string item_unit { get; set; }
        public int? item_quantity { get;set;}
        public DateTimeOffset created_on { get; set; }
       public  string group_name { get; set; }
       public string user_name { get; set; }
     //   public Ifor MyImage { set; get; }
    }

    public partial class GroupNameViewModel
    {
        public int group_id { get; set; }
        public string group_name { get; set; }
    }
}