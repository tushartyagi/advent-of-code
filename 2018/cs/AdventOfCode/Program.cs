using System;
using System.Linq;
using AdventOfCode.Solutions;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "inputs/2.txt";
            var solution = new Solution2();

            var checksum = solution.FindBoxesWhichDiffBy1(inputPath);
            Console.WriteLine(checksum);

            
        }
    }
}
