using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace AdventOfCode.Solutions
{
    public class Solution2 {

        // Finds the number of characters which appear two or three times.
        // Note that for the puzzle we need only the Min(1, times) since even if the
        // character appears twice more than once, it is only considered once.
        private IEnumerable<Mapping> Groups(string s) {
            return s.GroupBy(c => c,
                             (c, cs) => new Mapping {
                                 Key = c,
                                 Count = cs.Count()
                             });
        }

        public (int, int) HasTwoAndThreeCount(string s) {
            var groups = Groups(s);
            var twos = groups.Any(mapping => mapping.Count == 2) ? 1 : 0;
            var threes = groups.Any(mapping => mapping.Count == 3) ? 1 : 0;

            return (twos, threes);
        }

        public long GetChecksum(IEnumerable<string> ids) {
            var (twos, threes) = ids.Aggregate((0, 0), Aggregator);
            return twos * threes;
        }

        private (int, int) Aggregator((int, int) existingCounts, string id) {
            var (newTwo, newThree)  = HasTwoAndThreeCount(id);
            var (existingTwos, existingThrees) = existingCounts;
            return (newTwo + existingTwos, newThree + existingThrees);
        }

        public long Solve(string inputPath) {
            var ids = ReadIds(inputPath);
            var checksum = GetChecksum(ids);
            return checksum;
        }

        private IEnumerable<string> ReadIds(string inputPath) {
            using(StreamReader s = new StreamReader(File.OpenRead(inputPath))) {
                while(!s.EndOfStream) {
                    yield return s.ReadLine();
                }
            }
        }

        public (int, int) GetBoxIds(IEnumerable<string> ids) {
            var idList = ids.ToList();
            var idLength = idList[0].Length;

            for(var i = 0; i < idList.Count(); i++) {
                for(var j = i + 1; j < idList.Count(); j++) {
                    int diff = 0;                    
                    for(var c = 0; c < idLength; c++) {
                        if (diff > 1) break;
                        if (idList[i][c] != idList[j][c]) diff++;
                    }
                    if (diff == 1)
                        return (i, j);
                }
            }
            return (-1, -1);            
        }

        public string FindBoxesWhichDiffBy1(string inputPath) {
            var ids = ReadIds(inputPath);
            var (firstPos, secondPos) = GetBoxIds(ids);
            var (first, second) = (ids.ToList()[firstPos], ids.ToList()[secondPos]);

            return new String(first.Intersect(second).ToArray());
        }
    }
    

    class Mapping {
        public char Key {get; set;}
        public int Count {get; set;}        
    }
}
