using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using AdventOfCode.Utils;

namespace AdventOfCode.Solutions
{
    public class Solution5
    {
        string _polymerString;
        
        public Solution5() {
            _polymerString = Utils.Utils.ReadLine(5);
        }
        
        public void Solve() {
            Solve1();
            Solve2();
        }

        public int React(string polymer) {
            var _polymer = new StringBuilder(polymer);
            return React(_polymer);
        }
        

        public int React(StringBuilder polymer) {
            bool hasDuplicates = true;

            while(hasDuplicates) {
                hasDuplicates = false;
                for (var i = 0; i < polymer.Length; ++i) {
                    if (i < polymer.Length && i + 1 < polymer.Length) {
                        if (DifferByCase(polymer[i], polymer[i+1])) {
                            polymer.Remove(i, 2);
                            hasDuplicates = true;
                        }
                    }
                }
            }

            return polymer.Length;
        }

        public void Solve1() {
            var polymerLength = React(_polymerString);
            Console.WriteLine(polymerLength);
        }

        public void Solve2() {
            var alphabets = "abcdefghijklmnopqrstuvwxyz";
            var polymers = alphabets.Select(RemoveAndReact);
            var minimumSize = polymers.Min();
            Console.WriteLine("Solution 2: {0}", minimumSize);
        }

        private int RemoveAndReact(char c) {
            int size = 0;
            char upper = (char)(c - 32);
            string pattern = $"[{c}{upper}]";

            string polymer = Regex.Replace(_polymerString, pattern, "");

            size = React(polymer);
            return size;
        }

        private bool DifferByCase(char a, char b) {
            var differByCase = false;
            if ((a - b == 'a' - 'A') || (a - b == 'A' - 'a'))
                differByCase = true;
            return differByCase;
        }
    }
}
