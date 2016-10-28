using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day6 {

    public class Pos {
        public int X { get; set; }
        public int Y { get; set; }

        public Pos(int x, int y) {
            X = x;
            Y = y;
        }
    }   
    
    public class Instruction {
        public State State { get; set; }
        public Pos From {get; set;}
        public Pos To {get; set;}

        public Instruction(State status, Pos @from, Pos to) {
            State = status;
            From = @from;
            To = to;
        }
    }

    public enum State {
        On,
        Off,
        Toggle
    }

    public class Grid {
        
        // In the grid, 0 means light is off, 1 means it's on.
        private int[,] _grid;
        private int _lit;

        public int this[int x, int y] {
            get {
                return _grid[x, y];
            }
        }

        public int NumberLit { 
            get {
                return _lit;
            } 
        }

        public Grid(int row, int col) {
            // Everything's inits to zero in the grid, therefore every light is non-lit
            _grid = new int[row, col];
            _lit = 0;
        }

        public void UpdateState(State state, Pos from, Pos to) {
            if (state == State.On) {
                for (int x = @from.X; x <= to.X; x++)
                {
                    for (int y = @from.Y; y <= to.Y; y++)
                    {
                        if (_grid[x, y] == 0) {
                            _grid[x,y] = 1;
                            _lit += 1;
                        }
                    }
                }

            } 
            else if (state == State.Off) {
                for (int x = @from.X; x <= to.X; x++)
                {
                    for (int y = @from.Y; y <= to.Y; y++)
                    {
                        if (_grid[x,y] == 1) {
                            _grid[x,y] = 0;
                            _lit -= 1;
                        }
                    }
                }
            }
            else if (state == State.Toggle) {
                for (int x = @from.X; x <= to.X; x++)
                {
                    for (int y = @from.Y; y <= to.Y; y++)
                    {
                        if (_grid[x, y] == 0) _lit += 1;
                        else _lit -= 1;

                        _grid[x,y] ^= 1;
                    }
                }
            }
        }

        public Instruction ParseInstruction(string instruction) {
        
            var pattern = @"(\d+),(\d+)[a-z\s]*(\d+),(\d+)";
            var r = Regex.Match(instruction, pattern);
            if (r.Success && r.Groups.Count == 5) {
            
                int from1 = int.Parse(r.Groups[1].Value);
                int to1 = int.Parse(r.Groups[2].Value);
                int from2 = int.Parse(r.Groups[3].Value);
                int to2 = int.Parse(r.Groups[4].Value);
        
                Pos from = new Pos(from1, to1);
                Pos to = new Pos(from2, to2);

                if (instruction.StartsWith("toggle")) {
                    return new Instruction(State.Toggle, @from, to);
                } 
                else if (instruction.StartsWith("turn on")) {
                    return new Instruction(State.On, @from, to);
                } 
                else if (instruction.StartsWith("turn off")) {
                    return new Instruction(State.Off, @from, to);
                } 
            }

            throw new InvalidOperationException();
        }

        public static void Run() {
            Grid g = new Grid(1000,1000);

            using (StreamReader sr = new StreamReader(File.Open(@".\Input\Day6.txt", FileMode.Open))) {
                for (var line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
                    var instruction = g.ParseInstruction(line.Trim());
                    g.UpdateState(instruction.State, instruction.From, instruction.To);
                }

                System.Console.WriteLine("The number of lit bulbs are: {0}", g.NumberLit);
            }
        }
    }

}