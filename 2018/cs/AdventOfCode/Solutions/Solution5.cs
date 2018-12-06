using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.Utils;

namespace AdventOfCode.Solutions
{
    public class Solution5
    {
        public void Solve() {
            Solve1();
        }

        public void Solve1() {
            StringBuilder s = new StringBuilder(Utils.Utils.ReadLine(5));
            bool hasDuplicates = true;

            while(hasDuplicates) {
                hasDuplicates = false;
                for (var i = 0; i < s.Length; ++i) {
                    if (i < s.Length && i + 1 < s.Length) {
                        if (DifferByCase(s[i], s[i+1])) {
                            s.Remove(i, 2);
                            hasDuplicates = true;
                        }
                    }
                }
            }

            Console.WriteLine(s.Length);
        }

        private bool DifferByCase(char a, char b) {
            var differByCase = false;
            if ((a - b == 'a' - 'A') || (a - b == 'A' - 'a'))
                differByCase = true;
            return differByCase;
        }
    }
}
