using System.IO;

namespace AdventOfCode.Core
{
    public static class Runner {
            public static void Run(string inputPath) {
                using(StreamReader r = new StreamReader(File.Open(inputPath, FileMode.Open)))
                {
                    for (var line = r.ReadLine(); line != null; line = r.ReadLine())
                    {
                        System.Console.WriteLine(line);
                        System.Console.WriteLine(line.Length);
                    }
                }
            }
        }
}