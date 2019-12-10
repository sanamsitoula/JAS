using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class JournalEntryViewModel
    {
        public int? journal_id { get; set; }
        public string journal_name { get; set; }
        public int? Debit_Amount { get; set; }
        public int? Credit_Amount { get; set; }

        public int? gl_id { get; set; }

        public string gl_name { get; set; }

        public string transaction_descriptions { get; set; }

        public DateTimeOffset  journal_date { get; set; }

        public string transactions_type { get; set; }
        public string user_name { get; set; }
     

       
    }

   
   

   
}