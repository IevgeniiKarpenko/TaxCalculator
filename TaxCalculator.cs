using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    class Solution
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            double rate, hours;
            Console.WriteLine("Write Emplyee rate:");
            string rateStr = Console.ReadLine();
            while (!double.TryParse(rateStr, out rate))
            {
                Console.WriteLine("Error, try again:");
                rateStr = Console.ReadLine();
            }

            Console.WriteLine("Write worked hours:");
            string hoursStr = Console.ReadLine();
            while (!double.TryParse(hoursStr, out hours))
            {
                Console.WriteLine("Error, try again:");
                rateStr = Console.ReadLine();
            }

            Console.WriteLine("Write Location:");
            string location = Console.ReadLine();

            ShowPayments(rate, hours, location);
        }

        public static int ShowPayments(double rate, double hours, string location)
        {
            double gross = rate * hours;

            Console.WriteLine($"Employee location: {location}"); Console.WriteLine();
            Console.WriteLine($"Gross Amount: €{gross} "); Console.WriteLine();


            double netSalary = GetNetSalary(gross, location);
            Console.WriteLine($"Net Amount: €{netSalary}");


            return 0;
        }

        private static double GetProgressiveTax(double gross, double tax1, int wage, double tax2)
        {
            double tax = 0;
            if (gross > wage)
            {
                tax = wage * tax1;
                tax += (gross - wage) * tax2;
            }
            else
            {
                tax = gross * tax1;
            }

            return tax;
        }

        public static double GetNetSalary(double gross, string location)
        {
            double incomeTax = 0.0;
            double socialCharge = 0.0;
            double pension = 0.0;

            switch (location)
            {
                case "Ireland":

                    incomeTax = GetProgressiveTax(gross, 0.25, 600, 0.4);
                    socialCharge = GetProgressiveTax(gross, 0.07, 500, 0.08);
                    pension = gross * 0.04;
                    break;

                case "Germany":
                    incomeTax = GetProgressiveTax(gross, 0.25, 400, 0.32);
                    pension = gross * 0.02;
                    break;

                case "Italy":

                    incomeTax = gross * 0.25;
                    pension = gross * 0.0919;
                    break;
                default:
                    Console.WriteLine("Specified location was not found");
                    break;
            }

            Console.WriteLine("Less deductions"); Console.WriteLine();
            Console.WriteLine($"Income Tax : €{incomeTax}");
            Console.WriteLine($"Universal Social Charge: €{socialCharge}");
            Console.WriteLine($"Pension: €{pension}");

            return gross - incomeTax - pension - socialCharge;
        }
    }
}
