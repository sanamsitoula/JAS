using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class SalesViewModel
    {
        public int sale_id { get; set; }
        public string sale_name { get; set; }
        public int user_id { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
        public int customer_id { get; set; }
        public int price { get; set; }

        public DateTimeOffset sale_date { get; set; }

        public int transaction_id { get; set; }

        public  string transaction_name { get; set; }

        public int gl_id { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }

        public string transactions_type { get; set; }

       
    }

   
    public partial class ChartSaleViewModel
    {
        public string item_name { get; set; }
        public string quantity { get; set; }
    }
}