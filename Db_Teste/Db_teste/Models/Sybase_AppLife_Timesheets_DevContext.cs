using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Db_teste.Models
{
    public partial class Sybase_AppLife_Timesheets_DevContext : DbContext
    {
        public Sybase_AppLife_Timesheets_DevContext()
        {
        }

        public Sybase_AppLife_Timesheets_DevContext(DbContextOptions<Sybase_AppLife_Timesheets_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IrsCalculator> IrsCalculator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=23.102.32.185;Database=Sybase_AppLife_Timesheets_Dev;user=timesheet_dev;password=timesheet_dev;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrsCalculator>(entity =>
            {
                entity.ToTable("IRS_Calculator");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseSalaryGrossMonth19)
                    .HasColumnName("BaseSalaryGrossMonth_19")
                    .HasColumnType("money");

                entity.Property(e => e.BaseSalaryGrossYear21)
                    .HasColumnName("BaseSalaryGrossYear_21")
                    .HasColumnType("money");

                entity.Property(e => e.BaseSalaryNetMonth20)
                    .HasColumnName("BaseSalaryNetMonth_20")
                    .HasColumnType("money");

                entity.Property(e => e.BaseSalaryNetYear22)
                    .HasColumnName("BaseSalaryNetYear_22")
                    .HasColumnType("money");

                entity.Property(e => e.BaseSalaryTotal23)
                    .HasColumnName("BaseSalaryTotal_23")
                    .HasColumnType("money");

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasColumnType("money");

                entity.Property(e => e.BonusGrossMonth59)
                    .HasColumnName("BonusGrossMonth_59")
                    .HasColumnType("money");

                entity.Property(e => e.BonusNetMonth60)
                    .HasColumnName("BonusNetMonth_60")
                    .HasColumnType("money");

                entity.Property(e => e.BonusNetYear62)
                    .HasColumnName("BonusNetYear_62")
                    .HasColumnType("money");

                entity.Property(e => e.BonusTotal63)
                    .HasColumnName("BonusTotal_63")
                    .HasColumnType("money");

                entity.Property(e => e.CarExpenses)
                    .HasColumnName("car_expenses")
                    .HasColumnType("money");

                entity.Property(e => e.CarExpensesGrossYear46)
                    .HasColumnName("CarExpensesGrossYear_46")
                    .HasColumnType("money");

                entity.Property(e => e.CarExpensesNetMonth45)
                    .HasColumnName("CarExpensesNetMonth_45")
                    .HasColumnType("money");

                entity.Property(e => e.CarExpensesNetYear47)
                    .HasColumnName("CarExpensesNetYear_47")
                    .HasColumnType("money");

                entity.Property(e => e.CarExpensesTotal48)
                    .HasColumnName("CarExpensesTotal_48")
                    .HasColumnType("money");

                entity.Property(e => e.CarFuel)
                    .HasColumnName("car_fuel")
                    .HasColumnType("money");

                entity.Property(e => e.CarFuelGrossYear51)
                    .HasColumnName("CarFuelGrossYear_51")
                    .HasColumnType("money");

                entity.Property(e => e.CarFuelNetMonth50)
                    .HasColumnName("CarFuelNetMonth_50")
                    .HasColumnType("money");

                entity.Property(e => e.CarFuelNetYear52)
                    .HasColumnName("CarFuelNetYear_52")
                    .HasColumnType("money");

                entity.Property(e => e.CarFuelTotal53)
                    .HasColumnName("CarFuelTotal_53")
                    .HasColumnType("money");

                entity.Property(e => e.CarGrossMonth39)
                    .HasColumnName("CarGrossMonth_39")
                    .HasColumnType("money");

                entity.Property(e => e.CarGrossYear41)
                    .HasColumnName("CarGrossYear_41")
                    .HasColumnType("money");

                entity.Property(e => e.CarNetMonth40)
                    .HasColumnName("CarNetMonth_40")
                    .HasColumnType("money");

                entity.Property(e => e.CarNetYear42)
                    .HasColumnName("CarNetYear_42")
                    .HasColumnType("money");

                entity.Property(e => e.CarTotal43)
                    .HasColumnName("CarTotal_43")
                    .HasColumnType("money");

                entity.Property(e => e.CarTotalValue)
                    .HasColumnName("car_total_value")
                    .HasColumnType("money");

                entity.Property(e => e.CarType).HasColumnName("car_type");

                entity.Property(e => e.CostDayWithBonus75)
                    .HasColumnName("CostDayWithBonus_75")
                    .HasColumnType("money");

                entity.Property(e => e.CostDayWithoutBonus76)
                    .HasColumnName("CostDayWithoutBonus_76")
                    .HasColumnType("money");

                entity.Property(e => e.CostMonthWithBonus73)
                    .HasColumnName("CostMonthWithBonus_73")
                    .HasColumnType("money");

                entity.Property(e => e.CostMonthWithoutBonus74)
                    .HasColumnName("CostMonthWithoutBonus_74")
                    .HasColumnType("money");

                entity.Property(e => e.DayTargetMargWithoutBonus79)
                    .HasColumnName("DayTargetMargWithoutBonus_79")
                    .HasColumnType("money");

                entity.Property(e => e.DayTargetMargWithoutBonus80)
                    .HasColumnName("DayTargetMargWithoutBonus_80")
                    .HasColumnType("money");

                entity.Property(e => e.DependentsId).HasColumnName("dependents_id");

                entity.Property(e => e.EmployeeExtraTax15)
                    .HasColumnName("EmployeeExtraTax_15")
                    .HasColumnType("money");

                entity.Property(e => e.EmployeeIrs13)
                    .HasColumnName("EmployeeIRS_13")
                    .HasColumnType("money");

                entity.Property(e => e.EmployeeSs14)
                    .HasColumnName("EmployeeSS_14")
                    .HasColumnType("money");

                entity.Property(e => e.ExpensesGrossYear36)
                    .HasColumnName("ExpensesGrossYear_36")
                    .HasColumnType("money");

                entity.Property(e => e.ExpensesNetMonth35)
                    .HasColumnName("ExpensesNetMonth_35")
                    .HasColumnType("money");

                entity.Property(e => e.ExpensesNetYear37)
                    .HasColumnName("ExpensesNetYear_37")
                    .HasColumnType("money");

                entity.Property(e => e.ExpensesTotal38)
                    .HasColumnName("ExpensesTotal_38")
                    .HasColumnType("money");

                entity.Property(e => e.ExtraTax12)
                    .HasColumnName("ExtraTax_12")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IhtgrossMonth24)
                    .HasColumnName("IHTGrossMonth_24")
                    .HasColumnType("money");

                entity.Property(e => e.IhtgrossYear26)
                    .HasColumnName("IHTGrossYear_26")
                    .HasColumnType("money");

                entity.Property(e => e.IhtnetMonth25)
                    .HasColumnName("IHTNetMonth_25")
                    .HasColumnType("money");

                entity.Property(e => e.IhtnetYear27)
                    .HasColumnName("IHTNetYear_27")
                    .HasColumnType("money");

                entity.Property(e => e.Ihttotal28)
                    .HasColumnName("IHTTotal_28")
                    .HasColumnType("money");

                entity.Property(e => e.IrsCalcDate)
                    .HasColumnName("irs_calc_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Irstax11)
                    .HasColumnName("IRSTax_11")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.JustifiedExpenses)
                    .HasColumnName("justified_expenses")
                    .HasColumnType("money");

                entity.Property(e => e.MarginWithBonus82)
                    .HasColumnName("MarginWithBonus_82")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MarginWithoutBonus84)
                    .HasColumnName("MarginWithoutBonus_84")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaritalStatusId).HasColumnName("marital_status_id");

                entity.Property(e => e.MonthTargetMargWithBonus77)
                    .HasColumnName("MonthTargetMargWithBonus_77")
                    .HasColumnType("money");

                entity.Property(e => e.MonthTargetMargWithoutBonus78)
                    .HasColumnName("MonthTargetMargWithoutBonus_78")
                    .HasColumnType("money");

                entity.Property(e => e.NewLevel5)
                    .HasColumnName("NewLevel_5")
                    .HasMaxLength(30);

                entity.Property(e => e.NumDaysMonth).HasColumnName("num_days_month");

                entity.Property(e => e.NumMonths).HasColumnName("num_months");

                entity.Property(e => e.OldLevel6)
                    .HasColumnName("OldLevel_6")
                    .HasMaxLength(30);

                entity.Property(e => e.PickArea).HasColumnName("pick_area");

                entity.Property(e => e.PickLevel).HasColumnName("pick_level");

                entity.Property(e => e.ProposedDailyRate)
                    .HasColumnName("proposed_daily_rate")
                    .HasColumnType("money");

                entity.Property(e => e.ProposedHourRate83)
                    .HasColumnName("ProposedHourRate_83")
                    .HasColumnType("money");

                entity.Property(e => e.SubRefGrossMonth29)
                    .HasColumnName("SubRefGrossMonth_29")
                    .HasColumnType("money");

                entity.Property(e => e.SubRefGrossYear31)
                    .HasColumnName("SubRefGrossYear_31")
                    .HasColumnType("money");

                entity.Property(e => e.SubRefNetMonth30)
                    .HasColumnName("SubRefNetMonth_30")
                    .HasColumnType("money");

                entity.Property(e => e.SubRefNetYear32)
                    .HasColumnName("SubRefNetYear_32")
                    .HasColumnType("money");

                entity.Property(e => e.SubRefTotal33)
                    .HasColumnName("SubRefTotal_33")
                    .HasColumnType("money");

                entity.Property(e => e.TargetMargin).HasColumnName("target_margin");

                entity.Property(e => e.TotalGrossMonth64)
                    .HasColumnName("TotalGrossMonth_64")
                    .HasColumnType("money");

                entity.Property(e => e.TotalGrossYear66)
                    .HasColumnName("TotalGrossYear_66")
                    .HasColumnType("money");

                entity.Property(e => e.TotalNetAfterExtraTaxwithBonusNetMonth69)
                    .HasColumnName("TotalNetAfterExtraTaxwithBonusNetMonth_69")
                    .HasColumnType("money");

                entity.Property(e => e.TotalNetAfterExtraTaxwithBonusNetYear70)
                    .HasColumnName("TotalNetAfterExtraTaxwithBonusNetYear_70")
                    .HasColumnType("money");

                entity.Property(e => e.TotalNetAfterExtraTaxwithoutBonusNetMonth71)
                    .HasColumnName("TotalNetAfterExtraTaxwithoutBonusNetMonth_71")
                    .HasColumnType("money");

                entity.Property(e => e.TotalNetAfterExtraTaxwithoutBonusNetYear72)
                    .HasColumnName("TotalNetAfterExtraTaxwithoutBonusNetYear_72")
                    .HasColumnType("money");

                entity.Property(e => e.TotalNetMonth65)
                    .HasColumnName("TotalNetMonth_65")
                    .HasColumnType("money");

                entity.Property(e => e.TotalNetYear67)
                    .HasColumnName("TotalNetYear_67")
                    .HasColumnType("money");

                entity.Property(e => e.TotalTotal68)
                    .HasColumnName("TotalTotal_68")
                    .HasColumnType("money");

                entity.Property(e => e.Tta10)
                    .HasColumnName("TTA_10")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VariableValue)
                    .HasColumnName("variable_value")
                    .HasColumnType("money");

                entity.Property(e => e.VariableValueGrossYear56)
                    .HasColumnName("VariableValueGrossYear_56")
                    .HasColumnType("money");

                entity.Property(e => e.VariableValueNetMonth55)
                    .HasColumnName("VariableValueNetMonth_55")
                    .HasColumnType("money");

                entity.Property(e => e.VariableValueNetYear57)
                    .HasColumnName("VariableValueNetYear_57")
                    .HasColumnType("money");

                entity.Property(e => e.VariableValueTotal58)
                    .HasColumnName("VariableValueTotal_58")
                    .HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
