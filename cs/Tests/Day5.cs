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
    public void It_Should_Work_Correctly_For_Nice_Strings_v1() {
        Assert.IsTrue(Helpers.IsNice_v1("ugknbfddgicrmopn"));
        Assert.IsTrue(Helpers.IsNice_v1("aaa"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Naughty_Strings_v1() {
        Assert.IsFalse(Helpers.IsNice_v1("jchzalrnumimnmnp"));
        Assert.IsFalse(Helpers.IsNice_v1("haegwjzuvuyypxyu"));
        Assert.IsFalse(Helpers.IsNice_v1("dvszwmarrgswjxmb"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Repeats_In_Between() {
        Assert.IsTrue(Helpers.RepeatsInBetween("xyx"));
        Assert.IsTrue(Helpers.RepeatsInBetween("aaa"));
        Assert.IsTrue(Helpers.RepeatsInBetween("abcdefeghi"));
        Assert.IsTrue(Helpers.RepeatsInBetween("qjhvhtzxzqqjkmpb"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Pairs_In_Between() {
        Assert.IsTrue(Helpers.PairsAppearTwice("xyxy"));
        Assert.IsTrue(Helpers.PairsAppearTwice("aabcdefghaa"));
        Assert.IsTrue(Helpers.PairsAppearTwice("qjhvhtzxzqqjkmpb"));
        Assert.IsFalse(Helpers.PairsAppearTwice("aaa"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Nice_Strings_v2() {
        Assert.IsTrue(Helpers.IsNice_v2("qjhvhtzxzqqjkmpb"));
        Assert.IsTrue(Helpers.IsNice_v2("xxyxx"));
    }

    [Test]
    public void It_Should_Work_Correctly_For_Naughty_Strings_v2() {
        Assert.IsFalse(Helpers.IsNice_v2("ieodomkazucvgmuy"));
        Assert.IsFalse(Helpers.IsNice_v2("uurcxstgmygtbstg"));
    }
}