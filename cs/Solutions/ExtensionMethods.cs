using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.ExtensionMethods {
    
    public static class StringExtensions {
        public static string[] PartitionStringIntoAlternates(this String input) {
            StringBuilder santaMoves = new StringBuilder(),
                roboMoves = new StringBuilder();
        
            var chars = input.ToCharArray();

            for(var i = 0; i < chars.Length; i++) {
                if (i % 2 == 0)
                    santaMoves.Append(chars[i]);
                else
                    roboMoves.Append(chars[i]);
            }

            return new string[] { santaMoves.ToString(), roboMoves.ToString()};
        }
    }
}