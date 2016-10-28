using System;
using AdventOfCode.Day6;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Grid grid = new Grid(10,10);
            var instruction = "turn on 0,0 through 999,999";
            var output = grid.parseInstruction(instruction);
        
        }
    }
}
