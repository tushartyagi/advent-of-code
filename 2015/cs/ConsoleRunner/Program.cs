using System.IO;
using AdventOfCode.Day16;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            AuntSue[] aunts = new AuntSue[500];
            
            using (StreamReader sr = new StreamReader(File.Open(@"../AdventOfCode/Input/Day16.txt", FileMode.Open))) {
                for (var line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
                    var (auntIndex, auntArtifact) = FindAuntSue.ParseAuntInfo(line.Trim());
                    aunts[auntIndex - 1] = FindAuntSue.CreateAuntSue(auntArtifact);
                }
            }

            // These are the things that I have
            // children: 3
            // cats: 7
            // samoyeds: 2
            // pomeranians: 3
            // akitas: 0
            // vizslas: 0
            // goldfish: 5
            // trees: 3
            // cars: 2
            // perfumes: 1

            var selected = aunts.Where(a => { return a.Children == 3
                                 || a.Cats == 7
                                 || a.Samoyeds == 2
                                 || a.Pomeranians == 3
                                 || a.Akitas == 0
                                 || a.Vizslas == 0
                                 || a.Goldfish == 5
                                 || a.Trees == 3
                                 || a.Cars == 2
                                              || a.Perfumes == 1;});
                                 
            Console.WriteLine(selected.Count());
        }
    }

    
}
