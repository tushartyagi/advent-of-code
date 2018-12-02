using System;
using System.IO;

namespace AdventOfCode.Solutions
{
    public class Solution1 {

        public long State { get; private set; } = 0;

        public void UpdateState(string s) {
            if (s.StartsWith("+")) {
                State += Int64.Parse(s.Substring(1));
            }
            else if (s.StartsWith("-")) {
                State -= Int64.Parse(s.Substring(1));
            }
        }

        public long ParseStates(string path) {
            using(StreamReader s = new StreamReader(File.OpenRead(path))) {
                while(!s.EndOfStream) {
                    var line = s.ReadLine();
                    UpdateState(line);
                }
            }

            return State;
        }
    }
}
