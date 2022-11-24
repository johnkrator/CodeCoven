using System.ComponentModel;

namespace MyATMAPP.AppUI
{
    public static class UserValidator
    {
        // Generics explains the Type concepts better
        public static T? Convert<T>(string prompt)
        {
            bool _valid = false;
            string? _userInput;

            while (!_valid)
            {
                _userInput = AppUtility.GetUserInput(prompt);

                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(_userInput);
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
