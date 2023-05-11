using System;
using System.Collections.Generic;

namespace DbFirstNorthwind.Models
{
    public partial class EnPahalıÜrünler
    {
        public string CategoryName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
