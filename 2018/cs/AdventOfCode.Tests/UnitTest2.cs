using System;
using System.Collections.Generic;
using Xunit;
using AdventOfCode.Solutions;

namespace AdventOfCode.Tests
{
    public class UnitTest2
    {
        Solution2 solution2;
        public UnitTest2() {
            solution2 = new Solution2();
        }

        public static IEnumerable<object[]> HasTwoAndThreeCountData {
            get {
                return new[] { 
                    new object[] { "abcdef", (0, 0) },
                    new object[] { "ababef", (1, 0) },
                    new object[] { "abcccd", (0, 1) },
                    new object[] { "aabcdd", (1, 0) },
                    new object[] { "abcdee", (1, 0) },
                    new object[] { "ababab", (0, 1) },
                };
            }
        }

        [Theory]
        [MemberData(nameof(HasTwoAndThreeCountData))]
        public void GetsCorrectCountsForTwoAndThreeElements_3(string input, (int, int) expected)
        {
            var (two, three) = solution2.HasTwoAndThreeCount(input);
            Assert.Equal((two, three), expected);
        }
    }
    
}
