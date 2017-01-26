using System.Collections.Generic;
using AdventOfCode.Day10;
using NUnit.Framework;

namespace AdventOfCode.Tests 
{

    [TestFixture]
    public class ElvesLookElvesSayTests 
    {

        [Test]
        public void It_Correctly_Calculates_LookAndSay() 
        {
            var retVal = ElvesLookElvesSay.LookAndSay(1.ToString());
            Assert.AreEqual("11", retVal);
        }

        [Test]
        public void It_Correctly_Detects_11_As_21() 
        {
            var retVal = ElvesLookElvesSay.LookAndSay(11.ToString());
            Assert.AreEqual("21", retVal);
        }

        [Test]
        public void It_Correctly_Detects_21_As_1211() 
        {
            var retVal = ElvesLookElvesSay.LookAndSay(21.ToString());
            Assert.AreEqual("1211", retVal);
        }

        [Test]
        public void It_Correctly_Detects_1211_As_111221() 
        {
            var retVal = ElvesLookElvesSay.LookAndSay(1211.ToString());
            Assert.AreEqual("111221", retVal);
        }

        [Test]
        public void It_Correctly_Detects_111221_As_312211() 
        {
            var retVal = ElvesLookElvesSay.LookAndSay(111221.ToString());
            Assert.AreEqual("312211", retVal);
        }

    }
}