using System;
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
            string twiceInARow = @"(\w)\1";
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

        public static bool RepeatsInBetween(string input) {
            string repeatsInBetween = @"(\w)\w\1";
            var r = new Regex(repeatsInBetween);
            var result = r.Match(input);
            return result.Success;
        }

        public static bool PairsAppearTwice(string input) {
            string pairsAppearTwice = @"(\w\w)\w*\1";
            var r = new Regex(pairsAppearTwice);
            var result = r.Match(input);
            return result.Success;
        }

        public static bool IsNice_v1(string input) {
            return Has3Vowels(input) && HasALetterTwiceInARow(input) && !HasSomeStrings(input);
        }

        public static bool IsNice_v2(string input) {
            return RepeatsInBetween(input) && PairsAppearTwice(input);
        }
    }
    
    public static class NiceOrNaughty {

        private static void Run(Func<string, bool> IsNice) {
        
            using(StreamReader stream = new StreamReader(File.Open(@".\Input\Day5.txt", FileMode.Open))) {
                var niceCount = 0;
                for(var line = stream.ReadLine(); line != null; line = stream.ReadLine())
                {
                    if (IsNice(line)) niceCount++;
                }
                System.Console.WriteLine("The number of nice lines: {0}" , niceCount);
            }        
        }

        public static void RunPartA() {
        
            Run(Helpers.IsNice_v1);
        }

        public static void RunPartB() {
        
            Run(Helpers.IsNice_v2);
        }

    }

}
