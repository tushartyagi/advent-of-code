using NUnit.Framework;
using AdventOfCode.Day6;

[TestFixture]
public class TestDay6 {

    public Grid grid;

    [SetUp]
    public void Init() {
        grid = new Grid(5,5);
    }

    [Test]
    public void It_Should_Parse_Instructions_Correctly() {
        var instruction = "turn on 0,0 through 999,999";
        var output = grid.ParseInstruction(instruction);

        // Poor man's test since I have not implemented 
        // equality comparer
        Assert.IsInstanceOf(typeof(Instruction), output);
        Assert.AreEqual(output.State, State.On);
        Assert.AreEqual(output.From.X, 0);
        Assert.AreEqual(output.From.Y, 0);
        Assert.AreEqual(output.To.X, 999);
        Assert.AreEqual(output.To.Y, 999);
    }

    [Test]
    public void Update_State_ON_Works_Perfectly() {
        grid.UpdateState(State.On, new Pos(0,0), new Pos(2,2));

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(1, grid[i, j]);                
            }
        }

        for (int i = 3; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(0, grid[i, j]);
                Assert.AreEqual(0, grid[j, i]);
            }
        }

        Assert.AreEqual(9, grid.NumberLit);
    }

    [Test]
    public void Update_State_OFF_Works_Perfectly() {
        grid.UpdateState(State.On,  new Pos(0,0), new Pos(4,4));
        grid.UpdateState(State.Off, new Pos(0,0), new Pos(2,2));

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(0, grid[i, j]);                
            }
        }

        for (int i = 3; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(1, grid[i, j]);
                Assert.AreEqual(1, grid[j, i]);
            }
        }

        Assert.AreEqual(16, grid.NumberLit);
    }

    [Test]
    public void Update_State_TOGGLE_Works_Perfectly() {
        grid.UpdateState(State.On,  new Pos(0,0), new Pos(4,4));
        grid.UpdateState(State.Off, new Pos(0,0), new Pos(2,2));
        grid.UpdateState(State.Toggle, new Pos(0,0), new Pos(4,4));

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(1, grid[i, j]);                
            }
        }

        for (int i = 3; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(0, grid[i, j]);
                Assert.AreEqual(0, grid[j, i]);
            }
        }

        Assert.AreEqual(9, grid.NumberLit);
    }

}