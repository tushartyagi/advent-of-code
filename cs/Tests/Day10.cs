using System.Collections.Generic;
using AdventOfCode.Day10;
using NUnit.Framework;

namespace AdventOfCode.Tests 
{

    [TestFixture]
    public class ElvesLookElvesSayTests 
    {

        [TestCase("1", 1, "11")]
        [TestCase("1", 2, "21")]
        [TestCase("1", 3, "1211")]
        [TestCase("1", 4, "111221")]
        [TestCase("1", 5, "312211")]
        public void It_Correctly_Calculates_LookAndSay(string input, int iterations, string output) 
        {
            var retVal = ElvesLookElvesSay.LookAndSay(input, iterations);
            Assert.AreEqual(output, retVal);
        }

    }
}