namespace SystemExceptionHandling
{
    internal class CustomErrorHandling
    {
        public class TempIsZeroException : Exception
        {
            public TempIsZeroException(string message) : base(message)
            {
            }
        }
        /*User-defined exception classes are derived from the Exception class.*/
        public class Temperature
        {
            int temperature = 10;

            public void showTemp()
            {

                if (temperature == 0)
                {
                    throw (new TempIsZeroException("Zero Temperature found"));
                }
                else
                {
                    Console.WriteLine($"Temperature: {temperature}");
                }
            }
        }

        public void Output()
        {
            Temperature temp = new Temperature();
            try
            {
                temp.showTemp();
            }
            catch (TempIsZeroException e)
            {
                Console.WriteLine($"TempIsZeroException: {e.Message}");
            }
        }

    }
}
