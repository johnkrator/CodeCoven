using System.ComponentModel;

namespace ATMConsoleApp.AppUI
{
    public static class UserValidator
    {
        public static T Convert<T>(string prompt)
        {
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = AppUtility.GetUserInput(prompt);

                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                    else
                    {
                        return default;
                    }
                }
                catch
                {
                    /* Console.WriteLine("\nInvalid input. You go need try am again.");*/
                    AppUtility.PrintMessage("\nInvalid input. Be like you go like try am again.", false);
                }
            }

            return default;
        }
    }
}
