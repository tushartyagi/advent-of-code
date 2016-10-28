using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.ExtensionMethods;

namespace AdventOfCode.Day3 {

    public class HouseEqualityComparer : IEqualityComparer<House>
    {
        public bool Equals(House x, House y)
        {
            return x.PosX == y.PosX && x.PosY == y.PosY;
        }

        public int GetHashCode(House obj)
        {
            return obj.PosX.GetHashCode() + obj.PosY.GetHashCode();
        }
    }

    public class House : HouseEqualityComparer {

        public House(int x, int y) {
            PosX = x;
            PosY = y;
        }

        public int PosX {get; set;}
        public int PosY {get; set;}

        internal House Right()
        {
            return new House(PosX + 1, PosY);
        }

        internal House Left()
        {
            return new House(PosX - 1, PosY);
        }

        internal House Up()
        {
            return new House(PosX, PosY - 1);
        }

        internal House Down()
        {
            return new House(PosX, PosY + 1);
        }
    }

    public class MovementPlan
    {

        private HashSet<House> _houses;

        public HashSet<House> Houses {
            get {
                return _houses;
            } 
        }

        // Santa starts from here
        private House _seed = new House(0,0);

        public MovementPlan() {
            // Seed the value with the starting position
            _houses = new HashSet<House>(new HouseEqualityComparer()){_seed};

        }

        public House MoveNext(House current, Char move) {
            switch (move)
            {
                case '>':
                    return current.Right(); 
                case '<': 
                    return current.Left();
                case '^':
                    return current.Up(); 
                case 'v':
                    return current.Down();
                default:
                    throw new InvalidOperationException("Invalid move");
            }
        }

        // Starting with the current house, move using the string of 
        // movements and update _houses
        public void Move(House start, string movements) {
            
            var currentHouse = start;
            var nextHouse = currentHouse;
            
            foreach (var movement in movements)
            {
                nextHouse = MoveNext(currentHouse, movement);
                _houses.Add(nextHouse);
                currentHouse = nextHouse;
            }
        }

        public void StartDistribution(string movements) {
            Move(_seed, movements);
        }

        public static void RunPartA() {
        
            var santa = new MovementPlan();

            using(StreamReader stream = new StreamReader(File.Open(@".\Input\Day3.txt", FileMode.Open))) {
                var movements = stream.ReadToEnd().Trim();
                santa.StartDistribution(movements);
                System.Console.WriteLine("The number of houses: " + santa.Houses.Count);
            }        
        }

        public static void RunPartB() {
        
            // Both start at House(0,0)
            var santa = new MovementPlan();
            var robo =  new MovementPlan();

            using(StreamReader stream = new StreamReader(File.Open(@".\Input\Day3.txt", FileMode.Open))) {
                var movements = stream.ReadToEnd().Trim().DivideStringForSantaAndRobo();
                var santaMovements = movements[0];
                var roboMovements = movements[1];
                santa.StartDistribution(santaMovements);
                robo.StartDistribution(roboMovements);

                // If two HashSets using the same EqualityComparer are Unioned, then I 
                // should not be passing the equality comparer again! 
                var totalHouses = santa.Houses.Union(robo.Houses, new HouseEqualityComparer());

                System.Console.WriteLine("The number of houses: " + totalHouses.Count());
            }        
        }
    }

    
}