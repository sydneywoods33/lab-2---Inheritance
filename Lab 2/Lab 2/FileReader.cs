using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class FileReader
    {
        const string FileName = @"C:\Users\sydne\Desktop\cprg 211\lab 2\res\employees.txt";

        public static string ReadAllEmployeesBulk()
        {
            try
            {
                return File.ReadAllText(FileName);
            }
            catch
            {
                Console.WriteLine("File not found");
            }
            return null;
        }

        public static string[] ReadAllEmployeesByLine()
        {
            try
            {
                return File.ReadAllLines(FileName);
            }
            catch
            {
                Console.WriteLine("File not found");
            }
            return null;
        }
    }
}
