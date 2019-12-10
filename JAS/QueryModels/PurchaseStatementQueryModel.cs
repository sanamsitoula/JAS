using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JAS.QueryModels
{
    public sealed class PurchaseStatementQueryModel
    {
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }

        public string PostedBy { get; set; }
    }
}