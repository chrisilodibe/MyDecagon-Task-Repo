using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week_2_Task
{
    public class validations
    {

        public static bool IsPasswordValid(string password)
        {
            // Check if the password length is at least 6 characters
            if (password.Length < 6)
            {
                return false;
            }

            // Check if the password contains at least one alphanumeric character
            if (!password.Any(char.IsLetterOrDigit))
            {
                return false;
            }

            // Check if the password contains at least one special character
            if (!password.Any(IsSpecialCharacter))
            {
                return false;
            }

            return true;
        }

        static bool IsSpecialCharacter(char c)
        {
            // Define a list of special characters you want to check for
            string specialCharacters = "!@#$%^&*()-_=+[]{}|;:'\"<>,.?/";

            // Check if the character is in the list of special characters
            return specialCharacters.Contains(c);
        }


        public static bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for a valid email address
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            // Use Regex.IsMatch to check if the email matches the pattern

        }
        public static bool IsValidPhone(string phoneNo)
        {
            // Match a phone number in the format XXX-XXX-XXXX or XXX XXX XXXX
            return Regex.IsMatch(phoneNo, @"^\d{4}[-\s]?\d{3}[-\s]?\d{4}$");
        }

        public static bool IsValidFirstName(string firstName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
            {
                return false;
            }
            return Regex.IsMatch(firstName, @"^[a-zA-Z]+$");
        }
        public static bool IsValidlastName(string lastName)
        {

            if (string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            return Regex.IsMatch(lastName, @"^[a-zA-Z]+$");
        }
    }
}




