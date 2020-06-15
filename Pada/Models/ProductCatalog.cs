using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class ProductCatalog
    {
        public int ProductId { get; set; }
        public int? ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductValue { get; set; }
    }
}
