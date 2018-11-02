using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day8
{
    public static class Characters
    {
        public static int GetCharacterCodeCount(string input) {
            return Count(input);
        }

        public static int GetCharacterCount(string input) {
            return input.Length;
        }
    
        private static int Count(string str) {
            int count = 0;
            int pos = 0;
            char next = str[pos++];
            if (next == '"') {
                next = str[pos++];
                while(true) {
                    if (next == '"') {
                        return count;
                    }
                    else if (next == '\\') { // Three characters which can be escaped
                        next = str[pos++];
                        if (next == 'x') {
                            // Should I check for hex-values 0-9/a-f?
                            char hex1 = str[pos++];
                            char hex2 = str[pos++];
                            count++;
                            next = str[pos++];
                        }
                        else if (next == '\\' || next == '"') {
                            count++;
                            next = str[pos++];
                        }
                        else throw new InvalidOperationException();
                    }
                    else {  // All other characters
                        count++;
                        next = str[pos++];
                    }
                }
            }
            else throw new InvalidOperationException();
        }

        public static string Encode(string input) {
            var r = new Regex(@"([""\\])");
            var output = r.Replace(input, @"\$1");
            return string.Format("\"{0}\"", output);
        }
    }

    public static class Runner {
            public static void Run() {
                int characters = 0, characterCodes = 0, encodedCharCount = 0;
                using(StreamReader r = new StreamReader(File.Open("Input/Day8.txt", FileMode.Open)))
                {
                    for (var line = r.ReadLine(); line != null; line = r.ReadLine())
                    {
                        System.Console.WriteLine(line);
                        characterCodes += Characters.GetCharacterCodeCount(line);
                        characters += Characters.GetCharacterCount(line);
                        var encoded = Characters.Encode(line);
                        var encodedCount = Characters.GetCharacterCount(encoded);
                        encodedCharCount += encodedCount;                        
                    }
                    System.Console.WriteLine(characters - characterCodes);
                    System.Console.WriteLine(encodedCharCount - characters);
                }
            }
        }
}