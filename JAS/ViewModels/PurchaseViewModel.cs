using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class PurchaseViewModel
    {
        public int purchase_id { get; set; }
        public string purchase_name { get; set; }
        public int user_id { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public DateTimeOffset purchase_date { get; set; }

        public int transaction_id { get; set; }

        public  string transaction_name { get; set; }

        public int gl_id { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }

        public string transactions_type { get; set; }

       
    }

    public partial class SearchViewModel
    {
        public string SearchFrom { get; set; }
        public string SearchTo { get; set; }

    }
    public partial class ChartPurchaseViewModel
    {
        public string item_name { get; set; }
        public string quantity { get; set; }
    }

    public partial class ChartSalePurchaseViewModel
    {
        public string purchase_quantity { get; set; }
        public string sale_quantity { get; set; }

        public string item_name { get; set; }
    }
}