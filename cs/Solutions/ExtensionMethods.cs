using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Day7;

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

    public static class DictionaryExtensions {
        public static Signal Find(this IDictionary<string, Signal> environment, string key) {
            // Ideally, Find() should return an IntSignal() after recursively evaluating the 
            // value of key being passed
            if (environment.ContainsKey(key)) {
                var val = environment[key];
                var valType = val.GetType();
                if (valType == typeof(IntSignal)) {
                    return val;
                }
                else if (valType == typeof(BinarySignal)) {
                    // recursively find the operands and apply the operator on it.
                    var binSignal = val as BinarySignal;
                    // Apply Operation to recursively-found value of left and right operands.

                }
                else if (valType == typeof(UnarySignal)) {
                    var binSignal = val as UnarySignal;
                }
            }

            return new IntSignal(42);
        }
    }
}