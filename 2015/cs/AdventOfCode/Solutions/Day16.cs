using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.IO;

namespace AdventOfCode.Day16
{
    public class FindAuntSue
    {
        public static AuntSue CreateAuntSue(string artifacts) {
            var auntType = typeof(AuntSue);
            var aunt = new AuntSue();
            
            var re = new Regex(@"(\w+): (\d+)");

            foreach(Match match in re.Matches(artifacts)) {
                var details = match.ToString().Split(':');
                var artifact = details[0];
                var count = Convert.ToInt32(details[1]);

                var auntProp = auntType.GetProperty(ToTitleCase(artifact));
                auntProp.SetValue(aunt, count);
            }

            return aunt;
        }
        
        static string ToTitleCase(string s) {
            return  System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s);
        }

        /// <summary>
        ///  Parse each line of the input file, this is of the form:
        ///  Sue 1: goldfish: 6, trees: 9, akitas: 0
        /// </summary>
        public static (int, string) ParseAuntInfo(string s)
        {
            var re = new Regex(@"Sue (\d+): (.*)");
            var match = re.Match(s);
            Console.WriteLine("Aunt Value Count: " + match.Groups[2].Value);
            
            return (Convert.ToInt32(match.Groups[1].Value), match.Groups[2].Value);            
        }
    }

    public class AuntSue
    {
        public int Children { get; set;  } = 0;
        public int Cats { get; set; } = 0;
        public int Samoyeds { get; set; } = 0;
        public int Pomeranians { get; set; } = 0;
        public int Akitas { get; set; } = 0;
        public int Vizslas { get; set; } = 0;
        public int Goldfish { get; set; } = 0;
        public int Trees { get; set; } = 0;
        public int Cars { get; set; } = 0;
        public int Perfumes { get; set; } = 0;

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach(var property in this.GetType().GetProperties())
            {
                s.Append(property.Name + " : " + property.GetValue(this));
                s.Append(",");
            }
            return s.ToString();
        }
    }

    

    
}
