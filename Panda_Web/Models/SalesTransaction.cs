using System;
using System.Collections.Generic;

namespace Panda_Web.Models
{
    public partial class SalesTransaction
    {
        public int TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Userid { get; set; }
        public int? ProductId { get; set; }
        public int? ProductType { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductValue { get; set; }
        public string ReceiptNo { get; set; }
    }
}
