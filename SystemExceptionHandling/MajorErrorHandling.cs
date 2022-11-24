namespace SystemExceptionHandling
{
    internal class MajorErrorHandling
    {
        int result;

        public void DivNumbers()
        {
            result = 0;
        }

        public void division(int num1, int num2)
        {
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Exception caught: {e}");
            }
            finally
            {
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
