using AdventOfCode.Day11;
using NUnit.Framework;

namespace AdventOfCode.Tests 
{

    [TestFixture]
    public class CorporatePolicyTests 
    {
        [TestCase("hijklmmn", false)]
        [TestCase("abbceffg", false)]
        [TestCase("abbcegjk", false)]
        [TestCase("abcdffaa", true)]
        [TestCase("ghjaabcc", true)]
        public void ChecksForValidityOfPasswords(string password, bool validity)
        {
            Assert.AreEqual(validity, CorporatePolicy.IsValidPassword(password));
        }

        [TestCase("abcdefgh", "abcdffaa")]
        //[TestCase("ghijklmn", "ghjaabcc")]
        public void CheckForNextValidPasswords(string current, string next)
        {
            Assert.AreEqual(next, CorporatePolicy.NextValidPassword(current));
        }

    }
}