using System.ComponentModel;

namespace UI.AppDisplayScreen;

public class Validator
{
    public static T Convert<T>(string prompt)
    {
        bool valid = false;
        string userInput;

        while (!valid)
        {
            userInput = Utility.GetUserInput(prompt);

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
                Utility.PrintMessage("\nInvalid input. Be like you go like try am again.", false);
            }
        }

        return default;
    }
}
