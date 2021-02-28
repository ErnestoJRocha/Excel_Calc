using System;
using System.Collections.Generic;

namespace Db_teste.Models
{
    public partial class TaxablePerson
    {
        public int Id { get; set; }
        public decimal GrossWage { get; set; }
        public int Tax { get; set; }
        public int? PersonTypeId { get; set; }
    }
}
