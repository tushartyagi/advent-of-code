using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day4 {

    public static class MiningHelper {
        public static bool StartsWithFiveZeros(string input) {
            var pattern = @"^00000[a-z0-9]+";
            var match = Regex.Match(input, pattern);
            return match.Success;
        }

         public static bool StartsWithSixZeros(string input) {
            var pattern = @"^000000[a-z0-9]+";
            var match = Regex.Match(input, pattern);
            return match.Success;
        }

        public static string CalculateMd5Hash(string input) {

            using (MD5 md5Hash = MD5.Create()) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }

    public class AdventCoinMining {

        public delegate bool StartsWithNZeros(string input);
        
        public long GetCorrectNumber(string secretKey, Func<string, bool> IsValid) {
            long number = -1L;
            for (long i = 0; /* Infinite Possibilities */; i++)
            {
                var newString = secretKey + i.ToString();
                var hash = MiningHelper.CalculateMd5Hash(newString);
                if (IsValid(hash)) {
                    // System.Console.WriteLine("String for {0} is {1}", i, newString);
                    number = i;
                    break;
                }
            }
            return number;
        }

        public static void RunPartA() {
        
            var mining = new AdventCoinMining();
            var number = mining.GetCorrectNumber("yzbqklnj", MiningHelper.StartsWithFiveZeros);

            System.Console.WriteLine("The number is: {0}", number);
                    
        }

         public static void RunPartB() {
        
            var mining = new AdventCoinMining();
            var number = mining.GetCorrectNumber("yzbqklnj", MiningHelper.StartsWithSixZeros);

            System.Console.WriteLine("The number is: {0}", number);
                    
        }
    }
}