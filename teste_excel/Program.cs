using System;
using System.IO;
using OfficeOpenXml;


namespace teste_excel
{
    class Program
    {
        static void Main(string[] args)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var path = new ExcelPackage(new FileInfo(@"C:\Livro.xlsx")))
            {

                StreamReader sr = null;

                try
                {
                    sr = File.OpenText(path.ToString());
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (sr != null) sr.Close();
                }
            }
        }
    }
}
