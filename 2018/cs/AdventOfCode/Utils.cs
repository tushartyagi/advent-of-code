using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Utils
{
    public class Utils
    {
        public static string ReadLine(int solutionNumber) {
            using (StreamReader s = new StreamReader(File.OpenRead($"inputs/{solutionNumber}.txt")))
            {
                return s.ReadToEnd().Trim();
            }
        }
        
        public static IEnumerable<string> ReadLines(int solutionNumber) {
            using (StreamReader s = new StreamReader(File.OpenRead($"inputs/{solutionNumber}.txt")))
            {
                while(!s.EndOfStream) {
                    yield return s.ReadLine();
                }
            }
        }
    }
}
