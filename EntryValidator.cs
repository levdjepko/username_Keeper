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
            static void computeLPSArray(String str, int M, int[] lps)
            {
                // lenght of the previous  
                // longest prefix suffix 
                int len = 0;

                int i = 1;

                lps[0] = 0; 
                
                // the loop calculates lps[i]  
                // for i = 1 to M-1 
                while (i < M)
                {
                    if (str[i] == str[len])
                    {
                        len++;
                        lps[i] = len;
                        i++;
                    }
                    else // (pat[i] != pat[len]) 
                    {
                        if (len != 0)
                        {
                            len = lps[len - 1];
                        }
                        else // if (len == 0) 
                        {
                            lps[i] = 0;
                            i++;
                        }
                    }
                }
            }

            // Returns true if str is repetition of  
            // one of its substrings else return false. 
            static bool isRepeat(String str)
            {

                int n = str.Length;
                int[] lps = new int[n];

                computeLPSArray(str, n, lps);

                // Find length of longest suffix  
                // which is also prefix of str. 
                int len = lps[n - 1];

                return (len > 0 && n % (n - len) == 0)
                                       ? true : false;
            }
            
                if (isRepeat(pass) == true)
                {
                    return false;
                }
         
            return true;
        }
    }
}