using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_2
{
    public class Wage : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }

        public Wage(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
            : base(id, name, address, phone, sin, dob, dept)
        {
            Rate = rate;
            Hours = hours;
        }

        public decimal WageCalculatePayroll()
        {
            if (Hours <= 40)
            {
                return (decimal)(Rate * Hours);
            }
            else
            {
                return (decimal)(Rate * 40 + Rate * 2.5 * (Hours - 40));
            }
        }
    }
}
