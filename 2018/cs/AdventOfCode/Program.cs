using System;
using AdventOfCode.Solutions;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "inputs/1.txt";
            var solution1 = new Solution1();

            var answer = solution1.ParseStates(inputPath);
            Console.WriteLine(answer);
        }
    }
}
