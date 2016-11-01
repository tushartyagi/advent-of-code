using System;
using System.Collections.Generic;
using AdventOfCode.Day6;
using AdventOfCode.Day7a;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IDictionary<string, string> Environment;
            Evaluator e;

            Environment = new Dictionary<string, string>();
            Environment.Add("b", "19138");
            Environment.Add("ls", "lf AND lq");
            Environment.Add("lf", "123");
            Environment.Add("lq", "456");
            e = new Evaluator(Environment);

            e.Evaluate("ls");
        
        }
    }
}
