using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Db_teste.Model
{
    public partial class timesheetDbContext : DbContext
    {
        public timesheetDbContext()
        {
        }

        public timesheetDbContext(DbContextOptions<timesheetDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<CarType> CarType { get; set; }
        public virtual DbSet<Dependents> Dependents { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<IrsCalculator> IrsCalculator { get; set; }
        public virtual DbSet<IrsTable> IrsTable { get; set; }
        public virtual DbSet<LeavingSyone> LeavingSyone { get; set; }
        public virtual DbSet<PositionLevel> Position { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TaxablePerson> TaxablePerson { get; set; }
        public virtual DbSet<TaxablePersonType> TaxablePersonType { get; set; }
        public virtual DbSet<Taxes> Taxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=23.102.32.185;user=timesheet_dev;password=timesheet_dev;Database=Sybase_AppLife_Timesheets_Dev;Integrated Security=False;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasColumnName("area_name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("CAR_Type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cartype)
                    .IsRequired()
                    .HasColumnName("car_type")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Dependents>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DependentsNum).HasColumnName("dependents_num");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<IrsCalculator>(entity =>
            {
                entity.ToTable("IRS_Calculator");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasColumnType("money");

                entity.Property(e => e.CarExpenses)
                    .HasColumnName("car_expenses")
                    .HasColumnType("money");

                entity.Property(e => e.CarFuel)
                    .HasColumnName("car_fuel")
                    .HasColumnType("money");

                entity.Property(e => e.CarTotalValue)
                    .HasColumnName("car_total_value")
                    .HasColumnType("money");

                entity.Property(e => e.CarType).HasColumnName("car_type");

                entity.Property(e => e.DependentsId).HasColumnName("dependents_id");

                entity.Property(e => e.JustifiedExpenses)
                    .HasColumnName("justified_expenses")
                    .HasColumnType("money");

                entity.Property(e => e.MaritalStatusId).HasColumnName("marital_status_id");

                entity.Property(e => e.NumDaysMonth).HasColumnName("num_days_month");

                entity.Property(e => e.NumMonths).HasColumnName("num_months");

                entity.Property(e => e.PickArea).HasColumnName("pick_area");

                entity.Property(e => e.PickLevel).HasColumnName("pick_level");

                entity.Property(e => e.ProposedDailyRate)
                    .HasColumnName("proposed_daily_rate")
                    .HasColumnType("money");

                entity.Property(e => e.TargetMargin).HasColumnName("target_margin");

                entity.Property(e => e.VariableValue)
                    .HasColumnName("variable_value")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<IrsTable>(entity =>
            {
                entity.HasKey(e => e.IdRow)
                    .HasName("PK__IRS_Tabl__6ABCB5F5DD5A00B0");

                entity.ToTable("IRS_Table");

                entity.Property(e => e.IdRow).HasColumnName("id_row");

                entity.Property(e => e.FiscalYear)
                    .IsRequired()
                    .HasColumnName("fiscal_year")
                    .HasMaxLength(4);

                entity.Property(e => e.IdIrsTable).HasColumnName("id_irs_table");

                entity.Property(e => e.IrsTableName)
                    .IsRequired()
                    .HasColumnName("irs_table_name")
                    .HasMaxLength(50);

                entity.Property(e => e.IrsTax)
                    .HasColumnName("irs_tax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MarriedStatus)
                    .IsRequired()
                    .HasColumnName("married_status")
                    .HasMaxLength(50);

                entity.Property(e => e.NumDep).HasColumnName("num_dep");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<LeavingSyone>(entity =>
            {
                entity.ToTable("Leaving_Syone");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasColumnName("designation")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PositionLevel>(entity =>
            {
                entity.HasKey(e => e.NivelId)
                    .HasName("PK__Position__3213E83F7DA9F8BE");

                entity.ToTable("Position_Level");

                entity.Property(e => e.NivelId)
                    .HasColumnName("nivel_id")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.LevelName)
                    .HasColumnName("level_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PositionName)
                    .HasColumnName("position_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Extra).HasColumnName("extra");

                entity.Property(e => e.IrsTable).HasColumnName("irs_table");

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasColumnName("marital_status")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<TaxablePerson>(entity =>
            {
                entity.ToTable("Taxable_Person");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GrossWage)
                    .HasColumnName("gross_wage")
                    .HasColumnType("money");

                entity.Property(e => e.PersonTypeId).HasColumnName("person_type_id");

                entity.Property(e => e.Tax).HasColumnName("tax");
            });

            modelBuilder.Entity<TaxablePersonType>(entity =>
            {
                entity.ToTable("Taxable_Person_Type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PersonTypeDescription)
                    .IsRequired()
                    .HasColumnName("person_type_description")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Taxes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TaxName)
                    .IsRequired()
                    .HasColumnName("tax_name")
                    .HasMaxLength(30);

                entity.Property(e => e.TaxValue)
                    .HasColumnName("tax_value")
                    .HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
