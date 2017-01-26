using System.Text;

namespace AdventOfCode.Day10
{
    public class ElvesLookElvesSay 
    {
        // Need to work on this! Doesn't work :P
        public static string LookAndSay_Iterative(string number) 
        {
            StringBuilder sb = new StringBuilder();
            // We already know that the first character will make the following 
            // assignments true. (No null check b/c input doesn't require it).
            int count = 1;
            char currentChar = number[0];  

            foreach (char c in number.Substring(1)) 
            {
                if (c != currentChar) 
                {
                    sb.Append(count.ToString()); sb.Append(currentChar.ToString());
                    count = 1;
                    currentChar = c;
                }
                else 
                {
                    count += 1;
                }
            }

            sb.Append(count.ToString()); sb.Append(currentChar.ToString()); 
            return sb.ToString();
        }

        public static string LookAndSay(string number)
        {
            return LookAndSay_Iterative(number);
        }

        public static string LookAndSay_Recursive(string number)
        {
            return _NumberCounter(1, number[0], number.Substring(1));
        }

        private static string _NumberCounter(int currentCount, char currentChar, string remainingChars) 
        {
            if (string.IsNullOrEmpty(remainingChars))
            {
                return currentCount.ToString() + currentChar.ToString();
            }
            else if (currentChar == remainingChars[0]) 
            {
                return _NumberCounter(currentCount + 1, currentChar, remainingChars.Substring(1));
            }
            else 
            {
                return (currentCount.ToString() + currentChar.ToString()) + 
                    _NumberCounter(1, remainingChars[0], remainingChars.Substring(1));
            }
        }
    }

    public static class Runner {
        public static void Run() {
            const int iterations = 40;
            var current = 3113322113.ToString();

            for (int i = 0; i < iterations; i++)
            {
                current = ElvesLookElvesSay.LookAndSay(current);
                //System.Console.WriteLine("At {0}: {1}", i, current);    
            }

            System.Console.WriteLine("Final answer's length: {0}", current.Length);
        }
    }
    
}