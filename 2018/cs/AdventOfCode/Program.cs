using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using AdventOfCode.Solutions;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //var inputPath = "inputs/3.txt";
            //var solution = new Solution3(1000);
            //string datePattern = @"\[(?<date>.*)\]";
            //Regex re = new Regex(datePattern);

            //DateTime startDate = DateTime.Parse("1518-10-19 00:04");
            //DateTime EndDate = DateTime.Parse("1518-10-19 00:15");

            //DateTime epoch = DateTime.Parse($"{startDate.Year}-{startDate.Month}-{startDate.Day - 1} 23:30");

            //var a = re.Match("[1518-10-19 01:15] falls asleep");
            //var b = a.Groups["date"].Value;

            //var minutes = GetIndexFromTime(b);
            //var solution = new solution4();
            //solution.solve();

            Stopwatch s = new Stopwatch();
            s.Start();
            var solution = new Solution1();
            var answer = solution.SolveForRepeatedFrequencies("inputs/1.txt");
            s.Stop();
            Console.WriteLine(answer);
            Console.WriteLine(s.Elapsed);
        }

        
    }
}
