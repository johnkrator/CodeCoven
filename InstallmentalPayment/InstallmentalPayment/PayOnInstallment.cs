using System;

namespace InstallmentalPayment
{
    public class PayOnInstallment
    {
        private static DateTime _CurrentDay;

        public PayOnInstallment()
        {
        }

        public void DailyPlan()
        {
            Console.WriteLine("Please enter your name: ");
            var user = Console.ReadLine();

            Console.WriteLine("Enter product name: ");
            var product = Console.ReadLine();

            Console.WriteLine("Enter product amount: ");
            var productAmount = double.Parse(Console.ReadLine());

            Console.WriteLine(
                "To pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 7 for 7 days,: ");
            var period = double.Parse(Console.ReadLine());


            Console.WriteLine();
            var percentage = (period / 100);
            _CurrentDay = DateTime.Now.AddDays(period);

            double installmentPayment = productAmount * percentage;

            double i = 0;

            for (i = installmentPayment; i <= productAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"Appointed Date To Recieve payment {_CurrentDay.ToLongDateString()},  Amount Expected ${installmentPayment},Total Amount Recieved ${i}  For Product {product} by Customer {user.ToUpper()}");
                _CurrentDay = _CurrentDay.AddDays(1);
            }
        }

        public void WeeklyPlan()
        {
            Console.WriteLine("Please enter your name: ");
            var user = Console.ReadLine();

            Console.WriteLine("Enter product name: ");
            var product = Console.ReadLine();

            Console.WriteLine("Enter product amount: ");
            var productAmount = double.Parse(Console.ReadLine());

            Console.WriteLine(
                "To pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 7 for 7 days,: ");
            var period = double.Parse(Console.ReadLine());


            Console.WriteLine();
            var percentage = (period / 100);
            _CurrentDay = DateTime.Now.AddDays(period);

            double installmentPayment = productAmount * percentage;

            double i = 0;

            for (i = installmentPayment; i <= productAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"Appointed Date To Recieve payment {_CurrentDay.ToLongDateString()},  Amount Expected ${installmentPayment},Total Amount Recieved ${i}  For Product {product} by Customer {user.ToUpper()}");
                _CurrentDay = _CurrentDay.AddDays(7);
            }
        }

        public void BiWeeklyPlan()
        {
            Console.WriteLine("Please enter your name: ");
            var user = Console.ReadLine();

            Console.WriteLine("Enter product name: ");
            var product = Console.ReadLine();

            Console.WriteLine("Enter product amount: ");
            var productAmount = double.Parse(Console.ReadLine());

            Console.WriteLine(
                "To pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 7 for 7 days,: ");
            var period = double.Parse(Console.ReadLine());


            Console.WriteLine();
            var percentage = (period / 100);
            _CurrentDay = DateTime.Now.AddDays(period);

            double installmentPayment = productAmount * percentage;

            double i = 0;

            for (i = installmentPayment; i <= productAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"Appointed Date To Recieve payment {_CurrentDay.ToLongDateString()},  Amount Expected ${installmentPayment},Total Amount Recieved ${i}  For Product {product} by Customer {user.ToUpper()}");
                _CurrentDay = _CurrentDay.AddDays(14);
            }
        }

        public void MonthlyPlan()
        {
            Console.WriteLine("Please enter your name: ");
            var user = Console.ReadLine();

            Console.WriteLine("Enter product name: ");
            var product = Console.ReadLine();

            Console.WriteLine("Enter product amount: ");
            var productAmount = double.Parse(Console.ReadLine());

            Console.WriteLine(
                "To pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 7 for 7 days,: ");
            var period = double.Parse(Console.ReadLine());


            Console.WriteLine();
            var percentage = (period / 100);
            _CurrentDay = DateTime.Now.AddDays(period);

            double installmentPayment = productAmount * percentage;

            double i = 0;

            for (i = installmentPayment; i <= productAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"Appointed Date To Recieve payment {_CurrentDay.ToLongDateString()},  Amount Expected ${installmentPayment},Total Amount Recieved ${i}  For Product {product} by Customer {user.ToUpper()}");
                _CurrentDay = _CurrentDay.AddMonths(1);
            }
        }

        public void SixMonthPlan()
        {
            Console.WriteLine("Please enter your name: ");
            var user = Console.ReadLine();

            Console.WriteLine("Enter product name: ");
            var product = Console.ReadLine();

            Console.WriteLine("Enter product amount: ");
            var productAmount = double.Parse(Console.ReadLine());

            Console.WriteLine(
                "To pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 7 for 7 days,: ");
            var period = double.Parse(Console.ReadLine());


            Console.WriteLine();
            var percentage = (period / 100);
            _CurrentDay = DateTime.Now.AddDays(period);

            double installmentPayment = productAmount * percentage;

            double i = 0;

            for (i = installmentPayment; i <= productAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"Appointed Date To Recieve payment {_CurrentDay.ToLongDateString()},  Amount Expected ${installmentPayment},Total Amount Recieved ${i}  For Product {product} by Customer {user.ToUpper()}");
                _CurrentDay = _CurrentDay.AddDays(6);
            }
        }

        public void OneYearPlan()
        {
            Console.WriteLine("Please enter your name: ");
            var user = Console.ReadLine();

            Console.WriteLine("Enter product name: ");
            var product = Console.ReadLine();

            Console.WriteLine("Enter product amount: ");
            var productAmount = double.Parse(Console.ReadLine());

            Console.WriteLine(
                "To pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 7 for 7 days,: ");
            var period = double.Parse(Console.ReadLine());


            Console.WriteLine();
            var percentage = (period / 100);
            _CurrentDay = DateTime.Now.AddDays(period);

            double installmentPayment = productAmount * percentage;

            double i = 0;

            for (i = installmentPayment; i <= productAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"Appointed Date To Recieve payment {_CurrentDay.ToLongDateString()},  Amount Expected ${installmentPayment},Total Amount Recieved ${i}  For Product {product} by Customer {user.ToUpper()}");
                _CurrentDay = _CurrentDay.AddYears(1);
            }
        }

        public void Run()
        {
            DailyPlan();
            WeeklyPlan();
            BiWeeklyPlan();
            MonthlyPlan();
            SixMonthPlan();
            OneYearPlan();
        }
    }
}
