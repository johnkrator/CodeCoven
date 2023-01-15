using System.Text.RegularExpressions;
using DATA.Models;

namespace BLL.Implementation;

public class AttributeValidation : CustomAttributeEntities
{
    public AttributeValidation(int minLength, int maxLength)
    {
        MinLength = minLength;
        MaxLength = maxLength;
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
        if (input.Length < MinLength || input.Length > MaxLength)
        {
            Console.WriteLine($"Field must be between {MinLength} and {MaxLength} characters.");
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
        else if (input.Length == 11)
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
