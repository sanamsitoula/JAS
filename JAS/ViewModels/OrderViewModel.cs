using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class OrderViewModel
    {
        public int Order_ID { get; set; }

        public string Order_Name { get; set; }

        public DateTimeOffset Order_Date { get; set; }

        public int Item_ID { get; set; }

        public int? Category_ID { get; set; }

        public bool Order_Status { get; set; }

        public int? Group_ID { get; set; }

        public int User_ID { get; set; }

        //change into not nullable
        public int? Check_Out_By_ID { get; set; }

    }
}