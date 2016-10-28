using NUnit.Framework;
using AdventOfCode.Day4;

[TestFixture]
public class TestDay4 {

    public AdventCoinMining advent;

    [SetUp]
    public void Init() {
        advent = new AdventCoinMining();
    }

    [Test]
    public void It_Should_Correctly_Check_If_String_Begins_With_00000() {
        // This has to capture at least 5 zeros
        var validInput = "00000aa";
        Assert.IsTrue(MiningHelper.StartsWithFiveZeros(validInput));

        var invalidInput = "0000a";
        Assert.IsFalse(MiningHelper.StartsWithFiveZeros(invalidInput));

        var validInput2 = "000000a";
        Assert.IsTrue(MiningHelper.StartsWithFiveZeros(validInput2));
    }

    [Test]
    public void It_Should_Generate_Correct_Md5() {
        var input = "tushar";
        var output = "df7c905d9ffebe7cda405cf1c82a3add";  // online
        var hash = MiningHelper.CalculateMd5Hash(input);

        Assert.AreEqual(hash, output);
    }

    [Test]
    public void It_Should_Generate_Correct_Mining_Number_1() {
        var secretKey = "abcdef";
        var answer = advent.GetCorrectNumber(secretKey, MiningHelper.StartsWithFiveZeros);

        Assert.AreEqual(609043, answer);
    }

    [Test]
    public void It_Should_Generate_Correct_Mining_Number_2() {
        var secretKey = "pqrstuv";
        var answer = advent.GetCorrectNumber(secretKey, MiningHelper.StartsWithFiveZeros);

        Assert.AreEqual(1048970, answer);
    }

}