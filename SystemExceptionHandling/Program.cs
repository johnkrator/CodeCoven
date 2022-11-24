namespace SystemExceptionHandling
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MajorErrorHandling main = new MajorErrorHandling();
            main.division(10, 10);

            // Custom exceptions
            CustomErrorHandling customErrorHandling = new CustomErrorHandling();
            customErrorHandling.Output();

        }
    }
}