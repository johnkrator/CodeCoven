using System;

namespace InstallmentalPayment
{
    public class PayOnInstallment
    {
        private static DateTime _CurrentDay;
        private static string _User;
        private static string _Product;
        private static double _ProductAmount;
        private static double _Period;
        private static double _Percentage;

        public PayOnInstallment()
        {
        }

        public void DailyPlan()
        {
            Console.Write("\nPlease enter your name: ");
            _User = Console.ReadLine();

            Console.Write("\nEnter product name: ");
            _Product = Console.ReadLine();

            Console.Write("\nEnter product amount: ");
            _ProductAmount = double.Parse(Console.ReadLine());

            Console.Write(
                "\nTo pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 30 for 1month: ");

            _Period = double.Parse(Console.ReadLine());
            
            _Percentage = (_Period / 100);
            _CurrentDay = DateTime.Now.AddDays(_Period);

            double installmentPayment = _ProductAmount * _Percentage;

            double i = 0;

            for (i = installmentPayment; i <= _ProductAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"\nAgreed day to be credited: {_CurrentDay.ToLongDateString()}. The expected installment amount is ${installmentPayment}. Total received ${i}. As payment for {_Product} by {_User}");
                _CurrentDay = _CurrentDay.AddDays(1);
            }
        }

        public void WeeklyPlan()
        {
            Console.Write("\nPlease enter your name: ");
            _User = Console.ReadLine();

            Console.Write("\nEnter product name: ");
            _Product = Console.ReadLine();

            Console.Write("\nEnter product amount: ");
            _ProductAmount = double.Parse(Console.ReadLine());

            Console.Write(
                "\nTo pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 30 for 1month: ");

            _Period = double.Parse(Console.ReadLine());
            
            _Percentage = (_Period / 100);
            _CurrentDay = DateTime.Now.AddDays(_Period);

            double installmentPayment = _ProductAmount * _Percentage;

            double i = 0;

            for (i = installmentPayment; i <= _ProductAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"\nAgreed day to be credited: {_CurrentDay.ToLongDateString()}. The expected installment amount is ${installmentPayment}. Total received ${i}. As payment for {_Product} by {_User}");
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
                "\nTo pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 30 for 1month: ");
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
            Console.Write("\nPlease enter your name: ");
            _User = Console.ReadLine();

            Console.Write("\nEnter product name: ");
            _Product = Console.ReadLine();

            Console.Write("\nEnter product amount: ");
            _ProductAmount = double.Parse(Console.ReadLine());

            Console.Write(
                "\nTo pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 30 for 1month: ");

            _Period = double.Parse(Console.ReadLine());
            
            _Percentage = (_Period / 100);
            _CurrentDay = DateTime.Now.AddDays(_Period);

            double installmentPayment = _ProductAmount * _Percentage;

            double i = 0;

            for (i = installmentPayment; i <= _ProductAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"\nAgreed day to be credited: {_CurrentDay.ToLongDateString()}. The expected installment amount is ${installmentPayment}. Total received ${i}. As payment for {_Product} by {_User}");
                _CurrentDay = _CurrentDay.AddMonths(1);
            }
        }

        public void SixMonthPlan()
        {
            Console.Write("\nPlease enter your name: ");
            _User = Console.ReadLine();

            Console.Write("\nEnter product name: ");
            _Product = Console.ReadLine();

            Console.Write("\nEnter product amount: ");
            _ProductAmount = double.Parse(Console.ReadLine());

            Console.Write(
                "\nTo pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 30 for 1month: ");

            _Period = double.Parse(Console.ReadLine());
            
            _Percentage = (_Period / 100);
            _CurrentDay = DateTime.Now.AddDays(_Period);

            double installmentPayment = _ProductAmount * _Percentage;

            double i = 0;

            for (i = installmentPayment; i <= _ProductAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"\nAgreed day to be credited: {_CurrentDay.ToLongDateString()}. The expected installment amount is ${installmentPayment}. Total received ${i}. As payment for {_Product} by {_User}");
                _CurrentDay = _CurrentDay.AddMonths(6);
            }
        }

        public void OneYearPlan()
        {
            Console.Write("\nPlease enter your name: ");
            _User = Console.ReadLine();

            Console.Write("\nEnter product name: ");
            _Product = Console.ReadLine();

            Console.Write("\nEnter product amount: ");
            _ProductAmount = double.Parse(Console.ReadLine());

            Console.Write(
                "\nTo pay on installment, please choose a plan. Example 1 for One day, 7 for 1week, 14 for 2weeks, 30 for 1month: ");

            _Period = double.Parse(Console.ReadLine());
            
            _Percentage = (_Period / 100);
            _CurrentDay = DateTime.Now.AddDays(_Period);

            double installmentPayment = _ProductAmount * _Percentage;

            double i = 0;

            for (i = installmentPayment; i <= _ProductAmount; i += installmentPayment)
            {
                Console.WriteLine(
                    $"Agreed day to be credited: {_CurrentDay.ToLongDateString()}. The expected installment amount is ${installmentPayment}. Total received ${i}. As payment for {_Product} by {_User}");
                _CurrentDay = _CurrentDay.AddYears(1);
            }
        }

        public void Run()
        {
            DailyPlan();
            // WeeklyPlan();
            // BiWeeklyPlan();
            // MonthlyPlan();
            // SixMonthPlan();
            // OneYearPlan();
        }
    }
}
