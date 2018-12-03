using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions
{
    public class Solution3
    {
        private readonly int _size;
        private int[,] _claimsGrid;
        static string claimPattern = @"#(?<id>\d+) @ (?<left>\d+),(?<top>\d+): (?<width>\d+)x(?<height>\d+)";
        Regex re = new Regex(claimPattern, RegexOptions.Compiled);

        public Solution3(int size)
        {
            _size = size;
            _claimsGrid = new int[size, size];
        }

        public void AddClaim(string claim)
        {
            var match = re.Match(claim);
            int claimId = Int32.Parse(match.Groups["id"].Value),
                left = Int32.Parse(match.Groups["left"].Value),
                top = Int32.Parse(match.Groups["top"].Value),
                width = Int32.Parse(match.Groups["width"].Value),
                height = Int32.Parse(match.Groups["height"].Value);

            for(var i = top; i < top + height; i++)
            {
                for(var j = left; j < left + width; j++)
                {
                    // Blank area, claim it
                    if(_claimsGrid[i, j] == 0)
                    {
                        _claimsGrid[i, j] = claimId;
                    }
                    // Else overwrite the claim with -1 which means it's a conflict
                    else
                    {
                        _claimsGrid[i, j] = -1;
                    }
                }
            }
        }

        public int GetFabricUnderClaim()
        {
            int fabricUnderClaim = 0;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_claimsGrid[i, j] == -1) fabricUnderClaim += 1;
                }
            }

            return fabricUnderClaim;
        }

        public int Solve()
        {
            var inputPath = "inputs/3.txt";

            using (StreamReader s = new StreamReader(File.OpenRead(inputPath)))
            {
                while(!s.EndOfStream)
                {
                    var claim = s.ReadLine();
                    AddClaim(claim);
                }
            }           

            var answer = GetFabricUnderClaim();
            return answer;
        }
    }
}
