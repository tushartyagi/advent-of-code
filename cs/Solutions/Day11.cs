using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode.Day11 
{
    public class CorporatePolicy 
    {
        public static bool IsValidPassword(string password) 
        {
            return NotContainsIOL(password) && 
                ContainsAtLeastOneRun(password) &&
                ContainsAtLeastTwoDoublePairs(password);
        }

        // Works well for non-unicode chars.
        private static string Reverse(string s)
        {
            var array = s.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        public static string NextValidPassword(string password) 
        {

            var currentPassword = NextPassword(password);

            while(!IsValidPassword(currentPassword))
            {
                currentPassword = NextPassword(currentPassword);                
            }

            return currentPassword;
        }

        private static string NextPassword(string password)
        {
            var reversedPassword = Reverse(password);
            var next = Increment(reversedPassword);
            return Reverse(next);
        }

        // This increments the string from left to right
        private static string Increment(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "a";
            }

            var firstChar = password[0];

            if (firstChar == 'z')
            {
                return NextChar(firstChar).ToString() + Increment(password.Substring(1));
            }
            else 
            {
                return NextChar(firstChar).ToString() + password.Substring(1);
            }
        }

        private static char PreviousChar(char y) 
        {
            return (char)((int)y - 1);
        }

        private static char NextChar(char y) 
        {
            if (y == 'z') return 'a';
            else return (char)((int)y + 1);
        }

        private static bool NotContainsIOL(string password) 
        {
            var match = Regex.Match(password, @"i|o|l", RegexOptions.IgnoreCase);
            return !match.Success;
        }

        /*
        Passwords must contain at least two different, non-overlapping 
        pairs of letters, like aa, bb, or zz.
        */
        private static bool ContainsAtLeastTwoDoublePairs(string password) 
        {
            var matches = Regex.Matches(password, @"(\w)\1", RegexOptions.IgnoreCase);
            if (matches.Count < 2) 
            {
                return false;
            }
            else 
            {
                var values = new List<string>();

                foreach (Match match in matches) 
                {
                    values.Add(match.Value);
                }

                return values.Distinct().Count() >= 2;
            }
        }

        /*
        Passwords must include one increasing straight of at 
        least three letters, like abc, bcd, cde, and so on, up to xyz. 
        They cannot skip letters; abd doesn't count.
        */
        private static bool ContainsAtLeastOneRun(string password)
        {
            char current, next, nexter;
            for (int index = 0; index < password.Length; index++)
            {
                // If this condition is true, then there is no run 
                // possible of length 3 or more
                if (index >= password.Length - 2) return false;

                current = password[index];
                next = password[index + 1];
                nexter = password[index + 2];

                // This means we have found a single run of chars, which is the minimum 
                // to pass.
                if (((int)next - (int)current == 1) && 
                    ((int)nexter - (int)current == 2))
                {
                    return true;
                }
            }

            return false;
        }

    }
}