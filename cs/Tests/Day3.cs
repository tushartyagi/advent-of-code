using NUnit.Framework;
using AdventOfCode.Day3;
using System.Collections.Generic;

[TestFixture]
public class Testing_House {

    HouseEqualityComparer comparer;

    [SetUp]
    public void Init() {
        comparer = new HouseEqualityComparer();
    }

    [Test]
    public void Houses_with_same_positions_are_equal() {
        var house1 = new House(0,0);
        var house2 = new House(0,0);

        Assert.That(house1, Is.EqualTo(house2).Using(comparer));
    }

    [Test]
    public void Houses_work_well_with_HashSet() {
        var hs = new HashSet<House>(comparer){new House(0,0)};
        hs.Add(new House(0,0));

        Assert.AreEqual(1, hs.Count);
    }

    [Test]
    public void It_Should_Return_Correct_House_On_Movement() {
        var house1 = new House(0,0);
        var up = house1.Up();
        var down = house1.Down();
        var left = house1.Left();
        var right = house1.Right();

        Assert.That(up,    Is.EqualTo(new House(0, -1)).Using(comparer));
        Assert.That(down,  Is.EqualTo(new House(0, 1)).Using(comparer));
        Assert.That(left,  Is.EqualTo(new House(-1, 0)).Using(comparer));
        Assert.That(right, Is.EqualTo(new House(1, 0)).Using(comparer));
    }

}

[TestFixture]
public class Testing_Movement {

    SantaGiftDistribution santa;
    House startingHouse;

    [SetUp]
    public void Init() {
        santa = new SantaGiftDistribution();
        startingHouse = new House(0, 0);
    }

    [Test]
    public void It_Starts_With_The_Initial_Position() {
        // Santa lands at some house and that counts as visited.
        Assert.AreEqual(santa.Houses.Count, 1);
    }

    [Test]
    public void Movement_String_Gives_Correct_Results() {
        var movements = ">";
        santa.Move(startingHouse, movements);
        Assert.AreEqual(santa.Houses.Count, 2);
    }

    [Test]
    public void Movement_String_Gives_Correct_Results_2() {
        var movements = "^>v<";
        santa.Move(startingHouse, movements);
        Assert.AreEqual(santa.Houses.Count, 4);
    }

    [Test]
    public void Movement_String_Gives_Correct_Results_3() {
        var movements = "^v^v^v^v^v";
        santa.Move(startingHouse, movements);
        Assert.AreEqual(santa.Houses.Count, 2);
    }
}