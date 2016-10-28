using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day5 {

    public static class Helpers {
        public static bool Has3Vowels(string input) {
            string AtLeastThreeVowels = @"([^aeiou]*[aeiou][^aeiou]*){3,}";
            var r = new Regex(AtLeastThreeVowels);
            var result = r.Match(input);
            return result.Success;
        }

        public static bool HasALetterTwiceInARow(string input) {
            string twiceInARow = @"([a-zA-Z])\1";
            var r = new Regex(twiceInARow);
            var result = r.Match(input);
            return result.Success;
        }

        public static bool HasSomeStrings(string input) {
            return input.Contains("ab")
                || input.Contains("cd")
                || input.Contains("pq")
                || input.Contains("xy");
        }

        public static bool IsNice(string input) {
            return Has3Vowels(input) && HasALetterTwiceInARow(input) && !HasSomeStrings(input);
        }
    }
    
    public static class NiceOrNaughty {

        public static void RunPartA() {
        
            using(StreamReader stream = new StreamReader(File.Open(@".\Input\Day5.txt", FileMode.Open))) {
                var niceCount = 0;
                for(var line = stream.ReadLine(); line != null; line = stream.ReadLine())
                {
                    if (Helpers.IsNice(line)) niceCount++;
                }
                System.Console.WriteLine("The number of nice lines: {0}" , niceCount);
            }        
        }
    }

}
