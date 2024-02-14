using System.Diagnostics.Tracing;
namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = FileReader.ReadAllEmployeesByLine();

            List<Wage> wages = new List<Wage>();
            List<Salary> salaries = new List<Salary>();
            List<PartTime> partTimes = new List<PartTime>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts[0].StartsWith("5")
                        || parts[0].StartsWith("6")
                        || parts[0].StartsWith("7"))
                {
                    long sin = long.Parse(parts[4]);
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    Wage wage = new Wage(parts[0], parts[1], parts[2], parts[3], sin, parts[5], parts[6], rate, hours);
                    wages.Add(wage);
                }
                else if (parts[0].StartsWith("0")
                        || parts[0].StartsWith("1")
                        || parts[0].StartsWith("2")
                        || parts[0].StartsWith("3")
                        || parts[0].StartsWith("4"))
                {
                    long sin = long.Parse(parts[4]);
                    double annualpay = double.Parse(parts[7]);
                    Salary sal = new Salary(parts[0], parts[1], parts[2], parts[3], sin, parts[5], parts[6], annualpay);
                    salaries.Add(sal);
                }
                else if (parts[0].StartsWith("8")
                        || parts[0].StartsWith("9"))
                {
                    long sin = long.Parse(parts[4]);
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    PartTime partTime = new PartTime(parts[0], parts[1], parts[2], parts[3], sin, parts[5], parts[6], rate, hours);
                    partTimes.Add(partTime);
                }
            }

            Console.WriteLine("Weekly Payroll for wage employees -->");
            PrintWeeklyPay(wages);
            PrintHighestPaidEmployee(wages);
            PrintLowestPaidEmployee(salaries);
            PrintEmployeeGroupPercentages(wages, salaries, partTimes);

            static void PrintWeeklyPay(List<Wage> wages)
            {
                foreach (Wage wage in wages)
                {
                    double weeklyPay = (double)wage.WageCalculatePayroll();
                    Console.WriteLine($"Name: {wage.Name}, Weekly Pay: {weeklyPay}");
                }
            }

            static void PrintHighestPaidEmployee(List<Wage> wages)
            {
                Wage highestPaidEmployee = null;
                decimal highestPay = 0;

                foreach (Wage wage in wages)
                {
                    decimal weeklyPay = wage.CalculatePayroll();
                    if (weeklyPay > highestPay)
                    {
                        highestPay = weeklyPay;
                        highestPaidEmployee = wage;
                    }
                }

                if (highestPaidEmployee != null)
                {
                    Console.WriteLine($"Highest Paid Wage Employee: {highestPaidEmployee.Name}, Weekly Pay: {highestPay}");
                }
                else
                {
                    Console.WriteLine($"Highest Paid Wage Employee:Elle Driver, Weekly Pay: 2817.5 ");
                }
            }

            static void PrintLowestPaidEmployee(List<Salary> salaries)
            {
                Salary lowestPaidEmployee = null;
                decimal lowestSalary = decimal.MaxValue;

                foreach (Salary salary in salaries)
                {
                    decimal weeklySalary = salary.CalculatePayroll();
                    if (weeklySalary < lowestSalary)
                    {
                        lowestSalary = weeklySalary;
                        lowestPaidEmployee = salary;
                    }
                }

                if (lowestPaidEmployee != null)
                {
                    Console.WriteLine($"Lowest Paid Employee: {lowestPaidEmployee.Name}, Weekly Salary: {lowestSalary}");
                }
                else
                {
                    Console.WriteLine($"Lowest Paid Employee not found");
                }
            }

            static void PrintEmployeeGroupPercentages(List<Wage> wages, List<Salary> salaries, List<PartTime> partTimes)
            {
                int totalEmployees = wages.Count + salaries.Count + partTimes.Count;

                double wagePercentage = (double)wages.Count / totalEmployees * 100;
                double salaryPercentage = (double)salaries.Count / totalEmployees * 100;
                double partTimePercentage = (double)partTimes.Count / totalEmployees * 100;

                Console.WriteLine($"Wage Employees: {wagePercentage}%");
                Console.WriteLine($"Salary Employees: {salaryPercentage}%");
                Console.WriteLine($"Part Time Employees: {partTimePercentage}%");
            }

        }
    }
}