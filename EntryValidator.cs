using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Core
{
    public static class EntryValidator
    {
        public static bool CheckPassword(string pass)
        {
            //checks password length
            if (pass.Length < 5 || pass.Length > 12)
            {
                return false;
            }
            
            //Does not contain special characters
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (pass.Contains(c))
                    return false;
            }

            //No white space
            if (pass.Contains(" "))
            {
                return false;
            }

            //check if password consists of letters and/or numbers with at least 1 of each
            Regex lettersAndNumbersOnly = new Regex(@"[a-zA-Z0-9]", RegexOptions.IgnoreCase);
            string letters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string digits = @"0123456789";
            char[] letterChars = letters.ToCharArray();
            char[] digitsChars = digits.ToCharArray();

            int checkedLetters = 0;
            foreach (char c in letterChars)
            {
                if (pass.Contains(c))
                {
                    checkedLetters++;
                }
            }
            foreach (char c in digitsChars)
            {
                if (pass.Contains(c))
                {
                    checkedLetters++;
                }
            }
            if (! (checkedLetters == pass.Length))
            {
                return false;
            }
            

            //two consecutive characters are the same
            for (int i = 0; i < pass.Length - 1; i++)
            {
                if (pass[i] == pass[i + 1])
                    return false;
            }

            //check if there's any sequence of characters that is repeated in the password
            //TODO not done yet...
            /*
            List<string> allCombinations = new List<string>();
            for (int i = 0; i < pass.Length / 2; i++)
            {
                for (int j = 1; j < pass.Length; j++)
                {
                    allCombinations.Add(pass.Substring(i, j - i));
                }
            }*/

            return true;
        }
    }
}