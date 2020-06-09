using System.Text;
using System;
using System.Text.RegularExpressions;

namespace Core
{
    public static class EntryValidator
    {
        public static bool CheckPassword(string raw)
        {
            bool stringPasses = false;
            //check password length
            if (raw.Length < 5 || raw.Length > 12)
            {
                stringPasses = false;
                return stringPasses;
            }
            //check if password consists of letters and/or numbers with at least 1 of each
            Regex lettersAndNumbersOnly = new Regex(@"[a-zA-Z0-9]", RegexOptions.IgnoreCase);
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";
            if (lettersAndNumbersOnly.IsMatch(raw) && raw.Contains(letters) && raw.Contains(digits)){
                stringPasses = true;
            }
            //check if there's any sequence of characters that is repeated in the password


            return stringPasses;
        }
    }
}