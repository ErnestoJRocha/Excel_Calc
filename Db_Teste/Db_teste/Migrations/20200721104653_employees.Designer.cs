﻿// <auto-generated />
using System;
using Db_teste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Db_teste.Migrations
{
    [DbContext(typeof(syfidbContext))]
    [Migration("20200721104653_employees")]
    partial class employees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Db_teste.Models.Areas", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnName("area_name")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Db_teste.Models.CarType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Cartype")
                        .HasColumnName("car_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CAR_Type");
                });

            modelBuilder.Entity("Db_teste.Models.Dependents", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("DependentsNum")
                        .HasColumnName("dependents_num")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("Db_teste.Models.Employees", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Db_teste.Models.IrsCalculator", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<decimal?>("Bonus")
                        .HasColumnName("bonus")
                        .HasColumnType("money");

                    b.Property<decimal?>("CarExpenses")
                        .HasColumnName("car_expenses")
                        .HasColumnType("money");

                    b.Property<decimal?>("CarFuel")
                        .HasColumnName("car_fuel")
                        .HasColumnType("money");

                    b.Property<decimal?>("CarTotalValue")
                        .HasColumnName("car_total_value")
                        .HasColumnType("money");

                    b.Property<int?>("CarType")
                        .HasColumnName("car_type")
                        .HasColumnType("int");

                    b.Property<int>("DependentsId")
                        .HasColumnName("dependents_id")
                        .HasColumnType("int");

                    b.Property<decimal?>("JustifiedExpenses")
                        .HasColumnName("justified_expenses")
                        .HasColumnType("money");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnName("marital_status_id")
                        .HasColumnType("int");

                    b.Property<int?>("NumDaysMonth")
                        .HasColumnName("num_days_month")
                        .HasColumnType("int");

                    b.Property<int?>("NumMonths")
                        .HasColumnName("num_months")
                        .HasColumnType("int");

                    b.Property<int?>("PickArea")
                        .HasColumnName("pick_area")
                        .HasColumnType("int");

                    b.Property<int>("PickLevel")
                        .HasColumnName("pick_level")
                        .HasColumnType("int");

                    b.Property<decimal?>("ProposedDailyRate")
                        .HasColumnName("proposed_daily_rate")
                        .HasColumnType("money");

                    b.Property<int?>("TargetMargin")
                        .HasColumnName("target_margin")
                        .HasColumnType("int");

                    b.Property<int?>("TtaId")
                        .HasColumnName("tta_id")
                        .HasColumnType("int");

                    b.Property<decimal?>("VariableValue")
                        .HasColumnName("variable_value")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("IRS_Calculator");
                });

            modelBuilder.Entity("Db_teste.Models.IrsTable", b =>
                {
                    b.Property<int>("IdRow")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_row")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FiscalYear")
                        .HasColumnName("fiscal_year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<int>("IdIrsTable")
                        .HasColumnName("id_irs_table")
                        .HasColumnType("int");

                    b.Property<string>("IrsTableName")
                        .HasColumnName("irs_table_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("IrsTax")
                        .HasColumnName("irs_tax")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("MarriedStatus")
                        .HasColumnName("married_status")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("NumDep")
                        .HasColumnName("num_dep")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnName("salary")
                        .HasColumnType("money");

                    b.HasKey("IdRow")
                        .HasName("PK__IRS_Tabl__6ABCB5F5DF79B984");

                    b.ToTable("IRS_Table");
                });

            modelBuilder.Entity("Db_teste.Models.LeavingSyone", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnName("designation")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Leaving_Syone");
                });

            modelBuilder.Entity("Db_teste.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnName("position_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Db_teste.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Extra")
                        .HasColumnName("extra")
                        .HasColumnType("int");

                    b.Property<int>("IrsTable")
                        .HasColumnName("irs_table")
                        .HasColumnType("int");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnName("marital_status")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Db_teste.Models.TaxablePerson", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<decimal>("GrossWage")
                        .HasColumnName("gross_wage")
                        .HasColumnType("money");

                    b.Property<int?>("PersonTypeId")
                        .HasColumnName("person_type_id")
                        .HasColumnType("int");

                    b.Property<int>("Tax")
                        .HasColumnName("tax")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Taxable_Person");
                });

            modelBuilder.Entity("Db_teste.Models.TaxablePersonType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("PersonTypeDescription")
                        .IsRequired()
                        .HasColumnName("person_type_description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Taxable_Person_Type");
                });

            modelBuilder.Entity("Db_teste.Models.Taxes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("TaxName")
                        .IsRequired()
                        .HasColumnName("tax_name")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<decimal>("TaxValue")
                        .HasColumnName("tax_value")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Taxes");
                });
#pragma warning restore 612, 618
        }
    }
}
