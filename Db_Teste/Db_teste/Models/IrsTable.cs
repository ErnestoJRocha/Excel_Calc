using System;
using System.Collections.Generic;

namespace Db_teste.Models
{
    public partial class IrsTable
    {
        public int IdRow { get; set; }
        public int IdIrsTable { get; set; }
        public string IrsTableName { get; set; }
        public decimal Salary { get; set; }
        public int NumDep { get; set; }
        public string MarriedStatus { get; set; }
        public string FiscalYear { get; set; }
        public decimal IrsTax { get; set; }
    }
}
