using System.Text.RegularExpressions;
using DATA.Models;

namespace BLL.Implementation;

public class MyAttributeValidation : CustomAttributeEntities
{
    public MyAttributeValidation(int minLength, int maxLength)
    {
        _minLength = minLength;
        _maxLength = maxLength;
    }

    public bool IsValid(object value)
    {
        string input = Convert.ToString(value);

        // Check for null or empty fields
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Field is required.");
            return false;
        }

        // Check for minimum and maximum length
        if (input.Length < _minLength || input.Length > _maxLength)
        {
            Console.WriteLine($"Field must be between {_minLength} and {_maxLength} characters.");
            return false;
        }

        // Check for valid email
        if (input.Contains("@"))
        {
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" +
                             @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            if (!Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("Invalid email format.");
                return false;
            }
        }

        // Check for valid phone number
        else if (input.Length == 10)
        {
            if (!long.TryParse(input, out long number))
            {
                Console.WriteLine("Invalid phone number format.");
                return false;
            }
        }

        return true;
    }
}
