using System;
using System.Collections.Generic;
using System.Linq;

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

    public class SantaGiftDistribution
    {

        private HashSet<House> _houses;

        public HashSet<House> Houses {
            get {
                return _houses;
            } 
        }

        public SantaGiftDistribution() {
            // Seed the value with the starting position
            _houses = new HashSet<House>(new HouseEqualityComparer()){new House(0, 0)};

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

        public void MoveHouses(House current, string movements) {
            // Iterate movements and update the current value of house

        }

    }

    
}