using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace AdventOfCode.Day9
{
    public class City {
        public string Name { get; set; }
        public int Distance {get; set;}
        public List<City> Neigbours {get; set;}
        public City (string name)
        {
            Name = name;
            Neigbours = new List<City>();
        }
        public void AddNeighbour(City city) {
            Neigbours.Add(city);
        }

        public int OneWayDistance() {
            // Iterate thorough all the neighbours and return the distance
            return Neigbours.Sum(c => c.Distance);
        }
    }

    public class Parser {
        
        Dictionary<string, City> map = new Dictionary<string, City>();
        
        public void StringToCity(string input) {
            var pattern = @"(?<start>\w+) to (?<end>\w+) = (?<distance>\d+)";
            var r = new Regex(pattern);
            var match = r.Match(input);

            if (match.Success) {
                var start = match.Groups["start"].Value.ToLower();
                var end = match.Groups["end"].Value.ToLower();
                var distance = Convert.ToInt32(match.Groups["distance"].Value);

                var neighbour = new City(end) {Distance = distance};

                if (map.ContainsKey(start)) {
                    map["start"].AddNeighbour(neighbour);
                }
                else {
                    var city = new City(start);
                    city.AddNeighbour(neighbour);
                    map.Add(start, city);
                }
            }
            else throw new InvalidOperationException();
        }
    }



}