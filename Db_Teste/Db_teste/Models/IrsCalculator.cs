using System;
using System.Collections.Generic;

namespace Db_teste.Models
{
    public partial class IrsCalculator
    {
        public int Id { get; set; }
        public int PickArea { get; set; }
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
        public DateTime? IrsCalcDate { get; set; }
        public string NewLevel5 { get; set; }
        public string OldLevel6 { get; set; }
        public decimal? Tta10 { get; set; }
        public decimal? Irstax11 { get; set; }
        public decimal? ExtraTax12 { get; set; }
        public decimal? EmployeeIrs13 { get; set; }
        public decimal? EmployeeSs14 { get; set; }
        public decimal? EmployeeExtraTax15 { get; set; }
        public decimal? BaseSalaryGrossMonth19 { get; set; }
        public decimal? BaseSalaryNetMonth20 { get; set; }
        public decimal? BaseSalaryGrossYear21 { get; set; }
        public decimal? BaseSalaryNetYear22 { get; set; }
        public decimal? BaseSalaryTotal23 { get; set; }
        public decimal? IhtgrossMonth24 { get; set; }
        public decimal? IhtnetMonth25 { get; set; }
        public decimal? IhtgrossYear26 { get; set; }
        public decimal? IhtnetYear27 { get; set; }
        public decimal? Ihttotal28 { get; set; }
        public decimal? SubRefGrossMonth29 { get; set; }
        public decimal? SubRefNetMonth30 { get; set; }
        public decimal? SubRefGrossYear31 { get; set; }
        public decimal? SubRefNetYear32 { get; set; }
        public decimal? SubRefTotal33 { get; set; }
        public decimal? ExpensesNetMonth35 { get; set; }
        public decimal? ExpensesGrossYear36 { get; set; }
        public decimal? ExpensesNetYear37 { get; set; }
        public decimal? ExpensesTotal38 { get; set; }
        public decimal? CarGrossMonth39 { get; set; }
        public decimal? CarNetMonth40 { get; set; }
        public decimal? CarGrossYear41 { get; set; }
        public decimal? CarNetYear42 { get; set; }
        public decimal? CarTotal43 { get; set; }
        public decimal? CarExpensesNetMonth45 { get; set; }
        public decimal? CarExpensesGrossYear46 { get; set; }
        public decimal? CarExpensesNetYear47 { get; set; }
        public decimal? CarExpensesTotal48 { get; set; }
        public decimal? CarFuelNetMonth50 { get; set; }
        public decimal? CarFuelGrossYear51 { get; set; }
        public decimal? CarFuelNetYear52 { get; set; }
        public decimal? CarFuelTotal53 { get; set; }
        public decimal? VariableValueNetMonth55 { get; set; }
        public decimal? VariableValueGrossYear56 { get; set; }
        public decimal? VariableValueNetYear57 { get; set; }
        public decimal? VariableValueTotal58 { get; set; }
        public decimal? BonusGrossMonth59 { get; set; }
        public decimal? BonusNetMonth60 { get; set; }
        public decimal? BonusNetYear62 { get; set; }
        public decimal? BonusTotal63 { get; set; }
        public decimal? TotalGrossMonth64 { get; set; }
        public decimal? TotalNetMonth65 { get; set; }
        public decimal? TotalGrossYear66 { get; set; }
        public decimal? TotalNetYear67 { get; set; }
        public decimal? TotalTotal68 { get; set; }
        public decimal? TotalNetAfterExtraTaxwithBonusNetMonth69 { get; set; }
        public decimal? TotalNetAfterExtraTaxwithBonusNetYear70 { get; set; }
        public decimal? TotalNetAfterExtraTaxwithoutBonusNetMonth71 { get; set; }
        public decimal? TotalNetAfterExtraTaxwithoutBonusNetYear72 { get; set; }
        public decimal? CostMonthWithBonus73 { get; set; }
        public decimal? CostMonthWithoutBonus74 { get; set; }
        public decimal? CostDayWithBonus75 { get; set; }
        public decimal? CostDayWithoutBonus76 { get; set; }
        public decimal? MonthTargetMargWithBonus77 { get; set; }
        public decimal? MonthTargetMargWithoutBonus78 { get; set; }
        public decimal? DayTargetMargWithoutBonus79 { get; set; }
        public decimal? DayTargetMargWithoutBonus80 { get; set; }
        public decimal? MarginWithBonus82 { get; set; }
        public decimal? ProposedHourRate83 { get; set; }
        public decimal? MarginWithoutBonus84 { get; set; }
    }
}
