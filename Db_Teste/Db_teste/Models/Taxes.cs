using System;
using System.Collections.Generic;

namespace Db_teste.Models
{
    public partial class Taxes
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public decimal TaxValue { get; set; }
    }
}
