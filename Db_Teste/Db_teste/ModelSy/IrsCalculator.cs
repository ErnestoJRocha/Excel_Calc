using System;
using System.Collections.Generic;

namespace Db_teste.Model
{
    public partial class IrsCalculator
    {
        public int Id { get; set; }
        public int? PickArea { get; set; }
        public int PickLevel { get; set; }
        public int? CarType { get; set; }
        public decimal? CarTotalValue { get; set; }
        public int MaritalStatusId { get; set; }
        public int DependentsId { get; set; }
        public int? NumMonths { get; set; }
        public int? NumDaysMonth { get; set; }
        public int? TargetMargin { get; set; }
        public decimal? JustifiedExpenses { get; set; }
        public decimal? CarExpenses { get; set; }
        public decimal? CarFuel { get; set; }
        public decimal? VariableValue { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? ProposedDailyRate { get; set; }
    }
}
