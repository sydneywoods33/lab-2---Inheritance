using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class Salary : Employee
    {
        public Salary(string id, string name, string address, string phone, long sin, string dob, string dept, double annualpay) : base(id, name, address, phone, sin, dob, dept)
        {
            AnnualPay = annualpay;
        }

        public double AnnualPay { get; set; }

        public override decimal CalculatePayroll()
        {
            return (decimal)AnnualPay;
        }
    }
}

