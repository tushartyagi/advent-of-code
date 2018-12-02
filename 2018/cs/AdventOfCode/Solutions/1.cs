using System.Collections.Generic;
using System.IO;
using System;

namespace AdventOfCode.Solutions
{
    public class Solution1 {

        public long State { get; private set; } = 0;
        public HashSet<long> _frequencies = new HashSet<long>();

        public long GetState(string s) {
            if (s.StartsWith("+")) {
                return Int64.Parse(s.Substring(1));
            }
            else {
                return -1 * Int64.Parse(s.Substring(1));
            }
        }
        
        public void UpdateState(string s) {
            State += GetState(s);
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

        public long SolveForRepeatedFrequencies(string path) {
            var exhaustCount = 0;
            using(FileStream stream = File.OpenRead(path))
            using(StreamReader s = new StreamReader(stream)) {
                while(true) {
                    if (s.EndOfStream) {
                        //Console.WriteLine("Exhausted file, starting again...");
                        exhaustCount++;
                        stream.Position = 0;
                    }
                    var line = s.ReadLine();
                    //Console.WriteLine("Current state: {0}", State);
                    UpdateState(line);
                    if (_frequencies.Contains(State)) {
                        Console.WriteLine("Exhausted file {0} times", exhaustCount);
                        return State;
                    }
                    else {
                        _frequencies.Add(State);
                    }
                }
            }
        }
    }
}
