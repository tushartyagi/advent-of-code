using System;
using Xunit;
using AdventOfCode.Solutions;

namespace AdventOfCode.Tests
{
    public class Solution1Tests
    {
        Solution1 solution1;
        public Solution1Tests() {
            solution1 = new Solution1();
        }
        
        [Fact]
        public void A_Positive_Should_Increment_The_State_Correctly()
        {
            Assert.Equal(solution1.State, 0);
            solution1.UpdateState("+12");
            Assert.Equal(solution1.State, 12);
            
        }

        [Fact]
        public void A_Negative_Should_Decrement_The_State_Correctly()
        {
            Assert.Equal(solution1.State, 0);
            solution1.UpdateState("-12");
            Assert.Equal(solution1.State, -12);
        }

    }
    
}
