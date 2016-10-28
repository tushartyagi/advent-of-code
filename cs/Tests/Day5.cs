using NUnit.Framework;
using AdventOfCode.Day5;


[TestFixture]
public class TestDay5_Helpers {

    [Test]
    public void It_Should_Work_Correctly_For_3_Vowels() {
        Assert.IsTrue(Helpers.Has3Vowels("aei"));
        Assert.IsTrue(Helpers.Has3Vowels("xazegov"));
        Assert.IsTrue(Helpers.Has3Vowels("aeiouaeiouaeiou"));
        Assert.IsFalse(Helpers.Has3Vowels("dvszwmarrgswjxmb"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_2_Letters_In_A_Row() {
        Assert.IsTrue(Helpers.HasALetterTwiceInARow("xx"));
        Assert.IsTrue(Helpers.HasALetterTwiceInARow("abcdde"));
        Assert.IsTrue(Helpers.HasALetterTwiceInARow("aabbccdd"));
        Assert.IsFalse(Helpers.HasALetterTwiceInARow("jchzalrnumimnmnp"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Strings_We_Dont_Want() {
        Assert.IsFalse(Helpers.HasSomeStrings("xx"));
        Assert.IsFalse(Helpers.HasSomeStrings("deahaeosc"));
        Assert.IsFalse(Helpers.HasSomeStrings("saotehbaoeug"));
        Assert.IsTrue(Helpers.HasSomeStrings("aseotuhabsatoehu"));
        Assert.IsTrue(Helpers.HasSomeStrings("haegwjzuvuyypxyu"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Nice_Strings() {
        Assert.IsTrue(Helpers.IsNice("ugknbfddgicrmopn"));
        Assert.IsTrue(Helpers.IsNice("aaa"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Naughty_Strings() {
        Assert.IsFalse(Helpers.IsNice("jchzalrnumimnmnp"));
        Assert.IsFalse(Helpers.IsNice("haegwjzuvuyypxyu"));
        Assert.IsFalse(Helpers.IsNice("dvszwmarrgswjxmb"));
    }
}