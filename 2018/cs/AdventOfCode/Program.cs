using System;
using System.Collections.Generic;
using AdventOfCode.Solutions;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "inputs/3.txt";
            var solution = new Solution3(1000);

            //var solution = new Solution3(8);
            //var claims = new list<string>
            //{
            //    "#1 @ 1,3: 4x4",
            //    "#2 @ 3,1: 4x4",
            //    "#3 @ 5,5: 2x2"
            //};

            //foreach (var claim in claims)
            //{
            //    solution.addclaim(claim);
            //}

            var answer = solution.Solve();
            Console.WriteLine(answer);
        }
    }
}
