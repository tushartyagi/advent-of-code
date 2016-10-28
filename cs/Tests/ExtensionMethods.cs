using AdventOfCode.ExtensionMethods;
using NUnit.Framework;

namespace AdventOfCode.Tests {
    [TestFixture]
    public class Testing_StringExtensions {

        [Test]
        public void Correctly_Splits_String_Of_Length_Zero() {
            var test = "";

            var partitions = test.PartitionStringIntoAlternates();

            Assert.AreEqual(partitions.Length, 2);
            Assert.AreEqual(partitions[0], "");
            Assert.AreEqual(partitions[1], "");

        }

        [Test]
        public void Correctly_Splits_String_Of_Length_One() {
            var test ="a";

            var partitions = test.PartitionStringIntoAlternates();

            Assert.AreEqual(partitions.Length, 2);
            Assert.AreEqual(partitions[0], "a");
            Assert.AreEqual(partitions[1], "");

        }

        [Test]
        public void Correctly_Splits_String_Of_Even_Length() {
            var test ="abababab";

            var partitions = test.PartitionStringIntoAlternates();

            Assert.AreEqual(partitions.Length, 2);
            Assert.AreEqual(partitions[0], "aaaa");
            Assert.AreEqual(partitions[1], "bbbb");

        }

        [Test]
        public void Correctly_Splits_String_Of_Odd_Length() {
            var test ="ababababa";

            var partitions = test.PartitionStringIntoAlternates();

            Assert.AreEqual(partitions.Length, 2);
            Assert.AreEqual(partitions[0], "aaaaa");
            Assert.AreEqual(partitions[1], "bbbb");

        }
    }

}