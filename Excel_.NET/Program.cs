using System;
using System.IO;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using System.Data;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Data.Common;

/*using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;*/

namespace Excel_.NET
{
    class Program
    {
        static void Main(string[] args)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            
               // DateTime ano = DateTime.Now; 
                string fiscal_year = string.Format("{0:yyyy}", DateTime.Now);

            //DateTime ano = DateTime.Now;
            //DateTime? fiscal_year = ano;


            // SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["irs_calc"].ConnectionString);
            //SqlConnection myConn = new SqlConnection("Server=23.102.32.185;Database=Sybase_AppLife_Timesheets_Dev;user = timesheet_dev;password=timesheet_dev;MultipleActiveResultSets=true");
            SqlConnection myConn = new SqlConnection("Server=SBS-ERNROC;Database=Syfidb;Trusted_Connection=True;MultipleActiveResultSets=true");
           
            SqlCommand myCommand = new SqlCommand();


            int f;
            f = 0;
            int contador = 0;
            int ate = 0, superior = 0;

            // Registo tabela
            double salary = 0;
            int num_dep = 0;
            int np = 0;
            int id_irs_table = 0;
            string status = "";
            string irs_table_name = "";
            double irs_tax = 0;
            string table_name = "";
            string married_status = "";
            string married_status2 = "";


            using (var package = new ExcelPackage(new FileInfo(@"/estagio.xlsx")))
            {
                var firstSheet = package.Workbook.Worksheets["IRS"];

                Console.WriteLine("Sheet 1 Data");

                

                for (int k = ate + 1; k < 400; k++)
                {

                    if (firstSheet.Cells[k, 1].Text == "Euros")
                    {
                        ate = k + 1; // primeira linha dados


                        if (contador < 7)
                        {
                            table_name = firstSheet.Cells[k - 4, 1].Text;
                            married_status = firstSheet.Cells[k - 3, 1].Text;
                            status = married_status;

                        }
                        else
                        {
                            table_name = firstSheet.Cells[k - 3, 1].Text;
                            married_status = firstSheet.Cells[k - 1, 3].Text;
                            married_status2 = firstSheet.Cells[k - 1, 5].Text;


                        }
                        Console.WriteLine(ate);
                        Console.WriteLine(married_status);
                    }
                    if (firstSheet.Cells[k, 1].Text == "Superior a")
                    {

                        f = 1;
                        superior = k;
                        contador++;

                        Console.WriteLine(superior);


                    }
                    //while(ate < superior)
                    if (f == 1)
                    {


                        for (int i = ate; i <= superior; i++)
                        {

                            if (contador < 7)
                                Console.WriteLine("id_irs_table\tirs_table_name\t\t\tsalary\tNum_Dep IRS Tax\tMarried Status\tFiscal Year");
                            else
                                Console.WriteLine("id_irs_table\tirs_table_name\t\t\t\t\tsalary\tIRS Tax\tMarried Status\t\t\tFiscal Year");


                            for (int j = 2; j < 9; j++)
                            {

                                if (j == 2)
                                {
                                    salary = double.Parse(firstSheet.Cells[i, j].Text);
                                }
                                if (contador < 7)
                                {
                                    if (j > 2)
                                    {
                                        int tam = firstSheet.Cells[i, j].Text.Length - 1;
                                        string temp = firstSheet.Cells[i, j].Text.Substring(0, tam);
                                        irs_tax = double.Parse(temp);//, CultureInfo.InvariantCulture);
                                        np = num_dep;
                                        num_dep++;
                                        id_irs_table = contador;
                                        //fiscal_year = ano;
                                        irs_table_name = table_name;
                                        InserirDados();
                                        /*Console.WriteLine("id_irs_table: {0} irs_table_name: {1} salary: {2} Num_Dep: {3} IRS Tax: {4} Married Status: {5} Fiscal Year: {6}", 
                                            id_irs_table, irs_table_name, salary, np, irs_tax, status, fiscal_year);*/
                                        Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", id_irs_table, irs_table_name, salary, np, irs_tax, status, fiscal_year);
                                    }
                                }
                                else
                                {
                                    if (j == 4 || j == 6)
                                    {
                                        int tam = firstSheet.Cells[i, j].Text.Length - 1;
                                        string temp = firstSheet.Cells[i, j].Text.Substring(0, tam);
                                        irs_tax = double.Parse(temp);//, CultureInfo.InvariantCulture);
                                        np = 0;
                                        //np = null;
                                        //num_dep++;
                                        id_irs_table = contador;
                                       // fiscal_year = ano;
                                        irs_table_name = table_name;
                                        
                                        if (j == 4)
                                            //married_status = firstSheet.Cells[k - 3, 1].Text;
                                            status = married_status;
                                        else // j = 6
                                            status = married_status2;
                                        InserirDados();
                                        /*Console.WriteLine("id_irs_table: {0} irs_table_name: {1} salary: {2} Num_Dep: {3} IRS Tax: {4} Married Status: {5} Fiscal Year: {6}", 
                                            id_irs_table, irs_table_name, salary, np, irs_tax, status, fiscal_year);*/
                                        Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}", id_irs_table, irs_table_name, salary, irs_tax, status, fiscal_year);


                                    }
                                }

                                //Console.Write(firstSheet.Cells[i, j].Text + " ");
                                //'insert into 

                            }
                            num_dep = 0;

                            Console.WriteLine(contador);
                        }
                        f = 0;
                    }
                    //Console.WriteLine();
                }

                /*
             public override string ToString() 
             {
             return;
             }
             */


                // id_irs_table, irs_table_name, salary, irs_tax, status, fiscal_year



            }


            
             void InserirDados()
            {
                // myCommand.Parameters.AddWithValue("@utilizador", tb_utilizador.Text);
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@id_irs_table", id_irs_table);
                    myCommand.Parameters.AddWithValue("@irs_table_name", irs_table_name);
                    myCommand.Parameters.AddWithValue("@salary", salary);
                    myCommand.Parameters.AddWithValue("@num_dep", np);
                    myCommand.Parameters.AddWithValue("@status", status);
                    myCommand.Parameters.AddWithValue("@fiscal_year", fiscal_year);
                    myCommand.Parameters.AddWithValue("@irs_tax", irs_tax);

                    // myCommand.Parameters.AddWithValue("@pw", tb_pw.Text);

                    myCommand.CommandText = "insert irs_table(id_irs_table, irs_table_name, salary, num_dep, married_status, fiscal_year, irs_tax )values (@id_irs_table, @irs_table_name, @salary, @num_dep, @status, @fiscal_year, @irs_tax )";
                
                    myCommand.Connection = myConn;
                    try
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception m)
                    {
                    Console.WriteLine(m.Message);
                    }
                    finally
                    {
                        myConn.Close();
                    }

            }
                //Console.WriteLine(firstSheet.Cells[9, 3].Text);

                /*Console.WriteLine("Sheet 1 Data");
                Console.WriteLine("Cell A2 Value   : ", firstSheet.Cells["A2"].Text);
                Console.WriteLine($"Cell A2 Color   : {firstSheet.Cells["A2"].Style.Font.Color.LookupColor()}");
                Console.WriteLine($"Cell B2 Formula : {firstSheet.Cells["B2"].Formula}");
                Console.WriteLine($"Cell B2 Value   : {firstSheet.Cells["B2"].Text}");
                Console.WriteLine($"Cell B2 Border  : {firstSheet.Cells["B2"].Style.Border.Top.Style}");
                Console.WriteLine(""); */

                /* var secondSheet = package.Workbook.Worksheets["Second Sheet"];
                 Console.WriteLine($"Sheet 2 Data");
                 Console.WriteLine($"Cell A2 Formula : {secondSheet.Cells["A2"].Formula}");
                 Console.WriteLine($"Cell A2 Value   : {secondSheet.Cells["A2"].Text}");*/

                /*Excel.Worksheet workSheet;
                workSheet = (Excel.Worksheet)xlWorkBook.Worksheets["MASTER"];
                string result;
                string utterance = "apples";

                range1 = workSheet.Columns["B:B"] as Excel.Range;
                Excel.Range findRange
                findRange = range1.Find(utterance);
                result = (string)(range2.Cells[findRange1.Row, 2] as Excel.Range).Value2;*/



            
        }
    }
}
