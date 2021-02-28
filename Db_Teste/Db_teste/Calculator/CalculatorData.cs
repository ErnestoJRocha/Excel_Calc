using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Db_teste.Model;
using Db_teste.Auxiliar;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Db_teste.Models
{
    public partial class CalculatorData : IrsCalculatorOLD

    {
        public readonly syfidbContext _context;
        public readonly Timesheet_DevDbContext _timesheetContext;

        public CalculatorData() { }
        public CalculatorData(IrsCalculatorOLD irsCalculator, syfidbContext context, Timesheet_DevDbContext timesheetContext) 
        {
            Id = irsCalculator.Id;
            Bonus = irsCalculator.Bonus;
            CarExpenses = irsCalculator.CarExpenses;
            CarFuel = irsCalculator.CarFuel;
            CarType = irsCalculator.CarType;
            CarTotalValue = irsCalculator.CarTotalValue;
            DependentsId = irsCalculator.DependentsId;
            JustifiedExpenses = irsCalculator.JustifiedExpenses; //C16
            MaritalStatusId = irsCalculator.MaritalStatusId;
            NumDaysMonth = irsCalculator.NumDaysMonth;
            NumMonths = irsCalculator.NumMonths;
            PickArea = irsCalculator.PickArea;
            PickLevel = irsCalculator.PickLevel;
            TargetMargin = irsCalculator.TargetMargin;
            VariableValue = irsCalculator.VariableValue;
            ProposedDailyRate = irsCalculator.ProposedDailyRate;

            _context = context;
            _timesheetContext = timesheetContext;

            //CalculaDados(_context, _timesheetContext);
            CalculaDados();

        }
        public CalculatorData(syfidbContext context, Timesheet_DevDbContext timesheetContext)
        {
            _context = context;
            _timesheetContext = timesheetContext;
        }

        public string NewLevel_5 { get; set; }
        public string OldLevel_6 { get; set; }
        public decimal TTA_10 { get; set; }
        public decimal IRSTax_11 { get; set; } 
        public decimal ExtraTax_12 { get; set; }
        public double EmployeeIRS_13 { get; set; }
        public double EmployeeSS_14 { get; set; }
        public double EmployeeExtraTax_15 { get; set; }
        public double BaseSalaryGrossMonth_19 { get; set; }
        public double BaseSalaryNetMonth_20 { get; set; }
        public double BaseSalaryGrossYear_21 { get; set; }
        public double BaseSalaryNetYear_22 { get; set; }
        public double BaseSalaryTotal_23 { get; set; }

        public double IHTGrossMonth_24 { get; set; }
        public double IHTNetMonth_25 { get; set; }
        public double IHTGrossYear_26 { get; set; }
        public double IHTNetYear_27 { get; set; }
        public double IHTTotal_28 { get; set; }

        public double SubRefGrossMonth_29 { get; set; }
        public double SubRefNetMonth_30 { get; set; }
        public double SubRefGrossYear_31 { get; set; }
        public double SubRefNetYear_32 { get; set; }
        public double SubRefTotal_33 { get; set; }

        //public double ExpensesGrossMonth_34 { get; set; }
        public double ExpensesNetMonth_35 { get; set; }
        public double ExpensesGrossYear_36 { get; set; }
        public double ExpensesNetYear_37 { get; set; }
        public double ExpensesTotal_38 { get; set; }

        public double CarGrossMonth_39 { get; set; }
        public double CarNetMonth_40 { get; set; }
        public double CarGrossYear_41 { get; set; }
        public double CarNetYear_42 { get; set; }
        public double CarTotal_43 { get; set; }

        //public double CarExpensesGrossMonth_44 { get; set; }
        public double CarExpensesNetMonth_45 { get; set; }
        public double CarExpensesGrossYear_46 { get; set; }
        public double CarExpensesNetYear_47 { get; set; }
        public double CarExpensesTotal_48 { get; set; }

        //public double CarFuelGrossMonth_49 { get; set; }
        public double CarFuelNetMonth_50 { get; set; }
        public double CarFuelGrossYear_51 { get; set; }
        public double CarFuelNetYear_52 { get; set; }
        public double CarFuelTotal_53 { get; set; }

        //public double VariableValueGrossMonth_54 { get; set; }
        public double VariableValueNetMonth_55 { get; set; }
        public double VariableValueGrossYear_56 { get; set; }
        public double VariableValueNetYear_57 { get; set; }
        public double VariableValueTotal_58 { get; set; }

        public double BonusGrossMonth_59 { get; set; }
        public double BonusNetMonth_60 { get; set; }
        //public double BonusGrossYear_61 { get; set; }
        public double BonusNetYear_62 { get; set; }
        public double BonusTotal_63 { get; set; }

        public double TotalGrossMonth_64 { get; set; }
        public double TotalNetMonth_65 { get; set; }
        public double TotalGrossYear_66 { get; set; }
        public double TotalNetYear_67 { get; set; }
        public double TotalTotal_68 { get; set; }

        public double TotalNetAfterExtraTaxwithBonusNetMonth_69 { get; set; }
        public double TotalNetAfterExtraTaxwithBonusNetYear_70 { get; set; }
        public double TotalNetAfterExtraTaxwithoutBonusNetMonth_71 { get; set; }
        public double TotalNetAfterExtraTaxwithoutBonusNetYear_72 { get; set; }

        public double CostMonthWithBonus_73 { get; set; }
        public double CostMonthWithoutBonus_74 { get; set; }
        public double CostDayWithBonus_75 { get; set; }
        public double CostDayWithoutBonus_76 { get; set; }
        public double MonthTargetMargWithBonus_77 { get; set; }
        public double MonthTargetMargWithoutBonus_78 { get; set; }
        public double DayTargetMargWithoutBonus_79 { get; set; }
        public double DayTargetMargWithoutBonus_80 { get; set; }
        public double ProposedDailyRate_81 { get; set; }
        public double MarginWithBonus_82 { get; set; }
        public double ProposedHourRate_83 { get; set; }
        public double MarginWithoutBonus_84 { get; set; }
       


        //public void CalculaDados(syfidbContext context, Timesheet_DevDbContext timesheetContext) //, Timesheet_DevDbContext _timesheetContext)
        public void CalculaDados() 
        {
            //CalculatorData cd = new CalculatorData();
            /* 
             * *************
             * Calcula dados - Início
             * *************
            */

            // NewLevel (5)
            NewLevel_5 = _timesheetContext.Nivel.Where(n => n.Nivelid == PickLevel).Select(n => n.Shortdesc).First();

            // OldLevel (6)
            OldLevel_6 = NewLevel_5;

            // TTA_10
            switch (CarType)
            {
                case 1:  // Carro Normal
                    if (CarTotalValue < 25000)
                        // Taxes.Id = 7 (ou Taxes.tax_name='TTA Car Normal -25K')
                        TTA_10 = _context.Taxes.Where(t => t.Id == 7).Select(t => t.TaxValue).First();
                    else if (CarTotalValue < 35000)
                        // Taxes.Id = 8 (ou Taxes.tax_name='TTA Car Normal -35K')
                        TTA_10 = _context.Taxes.Where(t => t.Id == 8).Select(t => t.TaxValue).First();
                    else
                        // Taxes.Id = 9 (ou Taxes.tax_name='TTA Car Normal +35K')
                        TTA_10 = _context.Taxes.Where(t => t.Id == 9).Select(t => t.TaxValue).First();
                    break;
                case 2:     // Carro Plug-In
                    if (CarTotalValue < 25000)
                        // Taxes.Id = 10 (ou Taxes.tax_name='TTA Car Normal -25K')
                        TTA_10 = _context.Taxes.Where(t => t.Id == 10).Select(t => t.TaxValue).First();
                    else if (CarTotalValue < 35000)
                        // Taxes.Id = 11 (ou Taxes.tax_name='TTA Car Normal -35K')
                        TTA_10 = _context.Taxes.Where(t => t.Id == 11).Select(t => t.TaxValue).First();
                    else
                        // Taxes.Id = 12 (ou Taxes.tax_name='TTA Car Normal -50K')
                        TTA_10 = _context.Taxes.Where(t => t.Id == 12).Select(t => t.TaxValue).First();
                    break;

            }

            // BaseSalaryGrossMonth_19 = INDEX(INDIRECT(CONCATENATE(B3;"_table"));MATCH(B6;INDIRECT(B3);0);4)
            // Procura o Salário Base Bruto Mensal correspondente ao Nivel de carreira indicado na tabela de Nivel 
            BaseSalaryGrossMonth_19 = (double)_timesheetContext.Nivel.Where(n => n.Nivelid == PickLevel).Select(v => v.Vencimento).First();


            // IHTGrossMonth_24 = INDEX(INDIRECT(CONCATENATE(B3;"_table"));MATCH(B6;INDIRECT(B3);0);5) 
            // Procura o Subs de Isenção de Horário de Trabalho Bruto Mensal correspondente ao Nivel de carreira indicado na tabela de Nivel 
            
            IHTGrossMonth_24 = (double)_timesheetContext.Nivel.Where(n => n.Nivelid == PickLevel).Select(i => i.Abonos).First();



            // *** Taxa de IRS do colaborador ***
            // Auxiliares
            
            //Salário bruto mensal (SB + IHT) =C13+C14 //:
            double TotalGrossSalary = BaseSalaryGrossMonth_19 + IHTGrossMonth_24;

            // Verificar qual a tabela de IRS que se aplica:
            int irstable= _context.Status.Where(s => s.Id == MaritalStatusId).Select(s => s.IrsTable).First();

            int numdep = _context.Dependents.Where(nd => nd.Id == DependentsId).Select(nd => nd.DependentsNum).SingleOrDefault();
            /* OK: var itax = (from ms in _context.Status
                        join irs in _context.IrsTable on ms.IrsTable equals irs.IdIrsTable
                        where irs.IdIrsTable == irstable
                        where irs.Salary <= (decimal)TotalGrossSalary
                        where irs.NumDep == numdep
                        orderby irs.Salary descending
                        select new { irs.IrsTax }).Single(); */

            // Taxa IRS (11) -> Depende de BaseSalaryGrossMonth_19 e IHTGrossMonth_24  //F9
            // = @INDEX(INDIRECT(CONCATENATE(E9;"_table"));MATCH(C13+C14;INDIRECT(E9);1)+1;3+C9)) 
            IRSTax_11 = _context.IrsTable
                            .Where(itx => itx.IdIrsTable == irstable)
                            .Where(itx => itx.Salary <= (decimal)TotalGrossSalary)
                            .Where(itx => itx.NumDep == numdep)
                            .OrderByDescending (itx => itx.Salary)
                            .Select(itx => itx.IrsTax)
                            .FirstOrDefault();

            //Taxa extra IRS
            // Verificar qual o registo da tabela de IRS Extra que se aplica:
            int extrairs = _context.Status.Where(s => s.Id == MaritalStatusId).Select(s => s.Extra).First();

            // =@IF(ISNA(@INDEX(INDIRECT(CONCATENATE(E8;"_table"));MATCH(C13+C14;INDIRECT(E8);1)+1;2));0%;INDEX(INDIRECT(CONCATENATE(E8;"_table"));MATCH(C13+C14;INDIRECT(E8);1)+1;2))
            // G9
            ExtraTax_12 = _context.TaxablePerson
                            .Where(etx => etx.PersonTypeId == extrairs)
                            .Where(etx => etx.GrossWage <= (decimal)TotalGrossSalary)
                            .OrderByDescending(etx => etx.GrossWage)
                            .Select(etx => etx.Tax)
                            .FirstOrDefault();

            // Salário base liquido mensal:
            // BaseSalaryNetMonth_20 =  BaseSalaryGrossMonth_19 * (1 - REFERENCE_TABLES!K2 - IRSTax_11)

            decimal EmpSocSec = _context.Taxes.Where(t => t.Id == 1).Select(t => t.TaxValue).FirstOrDefault(); //REFERENCE_TABLES!K2
            BaseSalaryNetMonth_20 = BaseSalaryGrossMonth_19 * (double)(1 - (EmpSocSec/100) - (IRSTax_11/100));


            // Calcula o Subs de Isenção de Horário de Trabalho Liquido Mensal correspondente ao Nivel de carreira indicado na tabela de Nivel 
            // =C14*(1-REFERENCE_TABLES!K2-F9)
            IHTNetMonth_25 = IHTGrossMonth_24 * (double)(1 - (EmpSocSec / 100) - (IRSTax_11 / 100));





            // *** Calculos dos Valores Anuais e totais ***
            // Salário base bruto anual (BaseSalaryGrossYear_21)
            // BaseSalaryGrossYear_21 - 
            BaseSalaryGrossYear_21 = BaseSalaryGrossMonth_19 * 14;

            // Salário base bruto anual (BaseSalaryGrossYear_21)
            // BaseSalaryGrossYear_21 -
            BaseSalaryNetYear_22 = BaseSalaryNetMonth_20 * 14;

            // Salário base Total Empresa (BaseSalaryTotal_23)
            decimal CompSocSec = _context.Taxes.Where(t => t.Id == 2).Select(t => t.TaxValue).FirstOrDefault(); //K3
            BaseSalaryTotal_23 = BaseSalaryGrossYear_21 * (double)(1 + (CompSocSec/100));

            // * Subs Isenção Horário de Trabalho *
            // Subs Isenção Horário de Trabalho Bruto Anual (IHTGrossYear_26)
            IHTGrossYear_26 = IHTGrossMonth_24 * 14;

            // Subs Isenção Horário de Trabalho Liquido Anua (IHTNetYear_27)
            IHTNetYear_27 = IHTNetMonth_25 * 14;

            // Subs Isenção Horário de Trabalho Empresa (IHTTotal_28) 
            IHTTotal_28 = IHTGrossYear_26 * (double)(1 + (CompSocSec / 100));

            // * Sub. Refeição *
            // Sub. Refeição Bruto Mensal (SubRefGrossMonth_29) //C15
            SubRefGrossMonth_29 = (double)_timesheetContext.Nivel.Where(n => n.Nivelid == PickLevel).Select(v => v.Subsrefeicao).First();


            // Sub. Refeição Liquido Mensal (SubRefNetMonth_30)  //D15
            SubRefNetMonth_30 = SubRefGrossMonth_29;

            // Sub. Refeição Bruto Anual (SubRefGrossYear_31)   //E15
            SubRefGrossYear_31 = SubRefGrossMonth_29 * 11;

            // Sub. Refeição Liquido Anual (SubRefNetYear_32)   //F15
            SubRefNetYear_32 = SubRefGrossYear_31;

            //  Sub. Refeição Total Empresa (SubRefTotal_33)
            decimal ALaCard = _context.Taxes.Where(t => t.Id == 5).Select(t => t.TaxValue).FirstOrDefault(); //K6
            SubRefTotal_33 = SubRefGrossYear_31 * (double)(1 + (ALaCard / 100));

            // * Despesas *
            // Despesas Liquidas Mensais (ExpensesNetMonth_35) //D16
            //ExpensesGrossMonth_34 = JustifiedExpenses
            if (JustifiedExpenses != null)
            {
                ExpensesNetMonth_35 = (double)JustifiedExpenses;


                // Despesas Brutas Anuais (ExpensesGrossYear_36) //E16

                ExpensesGrossYear_36 = (double)JustifiedExpenses * 12;

                // Despesas Liquidas Anuais (ExpensesNetYear_37)  //F16

                ExpensesNetYear_37 = ExpensesNetMonth_35 * 12;

                // Despesas Totais Empresa (ExpensesTotal_38)   //
                // =E16*(1+REFERENCE_TABLES!K7)
                decimal TTAKMs = _context.Taxes.Where(t => t.Id == 6).Select(t => t.TaxValue).FirstOrDefault(); //K7
                ExpensesTotal_38 = ExpensesGrossYear_36 * (double)(1 + (TTAKMs / 100));
            }




            // * Carro *

            // Carro - valor bruto mensal (CarGrossMonth_39) //C17
            // =G6/REFERENCE_TABLES!K14
            if (CarTotalValue != null)
            {
                double CarAmortizationMonths = (double)_context.Taxes.Where(t => t.Id == 13).Select(t => t.TaxValue).FirstOrDefault();
                CarGrossMonth_39 = ((double)CarTotalValue / (CarAmortizationMonths));

                // Carro - valor liquido mensal (CarNetMonth_40) =C17  //D17
                CarNetMonth_40 = CarGrossMonth_39;

                //Carro - valor bruto anual (CarGrossYear_41) =C17 * 12  //E17
                CarGrossYear_41 = CarGrossMonth_39 * 12;

                //Carro -  valor liquido anual (CarNetYear_42) =E17  //F17
                CarNetYear_42 = CarGrossYear_41;


                //Carro -  valor total Empresa (CarTotal_43) =E17 * (1 + H6) //G17
                CarTotal_43 = CarGrossYear_41 * (double)(1 + (TTA_10/100));
            }
            // IRS a pagar pelo colaborador (EmployeeIRS_13) =(C13+C14)*(F9)  //K6
            EmployeeIRS_13 = TotalGrossSalary * (double)(IRSTax_11/100);

            // SegSoc a pagar pelo colaborador (EmployeeSS_14) =(C13+C14)*(REFERENCE_TABLES!K2) //K7
            EmployeeSS_14 = TotalGrossSalary * (double)EmpSocSec;



            //
            /* ***************************************************************************************************************
             * **** Ernesto
             * ***************************************************************************************************************
             * */

            if (CarExpenses != null)
            {
                CarExpensesNetMonth_45 = (double)CarExpenses;

                CarExpensesGrossYear_46 = CarExpensesNetMonth_45 * 12;

                CarExpensesNetYear_47 = CarExpensesGrossYear_46;


                CarExpensesTotal_48 = CarExpensesGrossYear_46 * (double)(1 + (TTA_10 / 100));
            }

            if (CarFuel != null)
            {
                CarFuelNetMonth_50 = (double)CarFuel;


                CarFuelGrossYear_51 = (double)CarFuel * 12;

                CarFuelNetYear_52 = CarFuelGrossYear_51;


                CarFuelTotal_53 = CarFuelGrossYear_51 * (double)(1 + (TTA_10 / 100));
            }


            if (VariableValue != null)
            {
                VariableValueNetMonth_55 = (double)VariableValue * (double)(1 - (IRSTax_11 / 100));

                VariableValueGrossYear_56 = (double)VariableValue * 12;

                VariableValueNetYear_57 = VariableValueNetMonth_55 * 12;

                VariableValueTotal_58 = VariableValueGrossYear_56;
            }

            if (Bonus != null)
            {
                BonusGrossMonth_59 = (double)Bonus / 12;


                BonusNetMonth_60 = BonusNetYear_62 / 12;

                BonusNetYear_62 = (double)Bonus * (double)(1 - (IRSTax_11/100));

                BonusTotal_63 = (double)Bonus;
            }

            //Total
            TotalNetAfterExtraTaxwithoutBonusNetMonth_71 = TotalNetAfterExtraTaxwithBonusNetMonth_69 - EmployeeExtraTax_15;
            TotalNetAfterExtraTaxwithoutBonusNetYear_72 = TotalNetAfterExtraTaxwithBonusNetYear_70 - (EmployeeExtraTax_15 * 14);

            TotalNetAfterExtraTaxwithoutBonusNetMonth_71 = TotalNetAfterExtraTaxwithoutBonusNetMonth_71 - BonusNetMonth_60;
            TotalNetAfterExtraTaxwithoutBonusNetYear_72 = TotalNetAfterExtraTaxwithoutBonusNetYear_72 - (EmployeeExtraTax_15 - BonusNetYear_62);


            CostMonthWithBonus_73 = TotalTotal_68 / (double)NumMonths;
            CostMonthWithoutBonus_74 = (TotalTotal_68 - BonusTotal_63) / (double)NumMonths;
            CostDayWithBonus_75 = CostDayWithBonus_75 / (double)NumDaysMonth;
            CostDayWithoutBonus_76 = CostMonthWithoutBonus_74 / (double)NumDaysMonth;
            MonthTargetMargWithBonus_77 = CostMonthWithBonus_73 / (1 - (double)(TargetMargin / 100));
            MonthTargetMargWithoutBonus_78 = CostMonthWithoutBonus_74/(1- (double)(TargetMargin / 100));
            DayTargetMargWithoutBonus_79 =  CostDayWithBonus_75/(1- (double)(TargetMargin / 100));
            DayTargetMargWithoutBonus_80 = CostDayWithoutBonus_76 / (1 - (double)(TargetMargin / 100));


            if(ProposedDailyRate != null)
            {
                ProposedDailyRate_81  =  (double)ProposedDailyRate;
                ProposedHourRate_83 = ProposedDailyRate_81 / 8;
                MarginWithBonus_82 = (ProposedDailyRate_81 - CostDayWithBonus_75) / ProposedDailyRate_81;
                MarginWithoutBonus_84 = (ProposedDailyRate_81 - CostDayWithBonus_75) / ProposedDailyRate_81;
            }

            // Taxa extra a pagar pelo colaborador (EmployeeExtraTax_15) 
            // = (D22 - D15 - D16 - D17 - D18 - D19 - REFERENCE_TABLES!K5)*G9
            decimal MinWage = _context.Taxes.Where(t => t.Id == 4).Select(t => t.TaxValue).FirstOrDefault(); //K5 //Salário minimo

            EmployeeExtraTax_15 = (TotalNetMonth_65 - SubRefNetMonth_30 - ExpensesNetMonth_35 - CarNetMonth_40
                - CarExpensesNetMonth_45 - CarFuelNetMonth_50 - (double)MinWage) * (double)ExtraTax_12;













            // *** Calcula dados  - Fim ***
        }
        public Decimal TaxaIRS()
        {
            var taxa = 0; // _context.IrsCalculator.



            return taxa;
        }
    }
}
