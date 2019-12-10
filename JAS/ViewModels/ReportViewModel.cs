using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.ViewModels
{
    public partial class GLedgerReportViewModel
    {
       public int gl_id { get; set; }
        public int Debit_Amount { get; set; }
        public int Credit_Amount { get; set; }
        public string gl_name { get; set; }
      
       
    }

   
}