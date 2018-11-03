using AdventOfCode.Day16;
using NUnit.Framework;

namespace AdventOfCode.Tests 
{

    [TestFixture]
    public class AuntSueTests
    {
        [Test]
        public void CreateAuntSueCreatesProperAuntSue1()
        {
            var artifacts = "Sue 1: goldfish: 6, trees: 9, akitas: 0";
            var aunt = FindAuntSue.CreateAuntSue(artifacts);
            Assert.AreEqual(aunt.Goldfish, 6);
            Assert.AreEqual(aunt.Trees, 9);
            Assert.AreEqual(aunt.Akitas, 0);
            Assert.AreEqual(aunt.Children, 0);
            Assert.AreEqual(aunt.Cats, 0);
            Assert.AreEqual(aunt.Samoyeds, 0);
            Assert.AreEqual(aunt.Pomeranians, 0);
            Assert.AreEqual(aunt.Vizslas, 0);
            Assert.AreEqual(aunt.Cars, 0);
            Assert.AreEqual(aunt.Perfumes, 0);
        }

    }
}
