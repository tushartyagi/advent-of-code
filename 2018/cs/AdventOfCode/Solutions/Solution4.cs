using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions
{
    public class Solution4
    {
        static readonly string guardInfoPattern = @"Guard #(?<guardId>\d+) begins";
        static readonly string datePattern = @"\[(?<date>.*)\]";
        IDictionary<int, Guard> _guardsInfo = new Dictionary<int, Guard>();
        Regex dateRegex = new Regex(datePattern);
        Regex guardRegex = new Regex(guardInfoPattern);

        private void Setup()
        {
            using (StreamReader s = new StreamReader(File.OpenRead("inputs/4.txt")))
            {
                int currentGuardId = -1;
                Guard currentGuard;
                DateTime sleepStartTime = DateTime.MinValue;

                while (!s.EndOfStream)
                {
                    var line = s.ReadLine();
                    // Line like: [1518-04-01 23:53] Guard #643 begins shift
                    if (IsGuardInfo(line))
                    {
                        currentGuardId = Int32.Parse(guardRegex.Match(line).Groups["guardId"].Value);
                    }
                    // Line like: [1518-04-02 00:05] falls asleep
                    else if (IsSleepInfo(line))
                    {
                        sleepStartTime = DateTime.Parse(dateRegex.Match(line).Groups["date"].Value);
                    }
                    // Line like: [1518-04-02 00:13] wakes up
                    else if (IsWakeUpInfo(line))
                    {
                        var sleepEndTime = DateTime.Parse(dateRegex.Match(line).Groups["date"].Value);
                        if (_guardsInfo.ContainsKey(currentGuardId))
                        {
                            currentGuard = _guardsInfo[currentGuardId];
                        }
                        else
                        {
                            currentGuard = new Guard() { Id = currentGuardId };
                        }

                        var index = GetIndexFromTime(sleepStartTime);
                        var minutes = (sleepEndTime - sleepStartTime).TotalMinutes;
                        for (var i = index; i < index + minutes; i++)
                        {
                            currentGuard.Minutes[i] += 1;
                            currentGuard.TotalDuration += 1;
                        }

                        _guardsInfo[currentGuardId] = currentGuard;
                    }
                }
            }
        }

        public int SolvePart1()
        {
            Setup();

            int maxDuration = _guardsInfo.Max(g => g.Value.TotalDuration);
            var mostSleepyGuard = _guardsInfo.First(guardInfo => guardInfo.Value.TotalDuration == maxDuration);
            var mostSleepyMinute = MostSleptMinute(mostSleepyGuard.Value);

            return mostSleepyGuard.Value.Id * mostSleepyMinute;
        }

        public int SolvePart2()
        {
            var maxDurations = _guardsInfo.Select(g => (g.Key, g.Value.Minutes.Max()));
            var maxDuration = maxDurations.Max(duration => duration.Item2);
            var mostAccurateSleeper = maxDurations.First(duration => duration.Item2 == maxDuration);
            var mostSleptMinute = MostSleptMinute(_guardsInfo[mostAccurateSleeper.Item1]);
            return mostAccurateSleeper.Item1 * mostSleptMinute;
            
        }

        public class Guard
        {
            public int Id { get; set; }
            public int TotalDuration { get; set; }
            public int[] Minutes { get; set; } = new int[105]; // Taking this from 23:30 to 01:15 as superset of everything
        }

        // Gets the index of the minute which has the maximum value, relative to midnight hour!
        public static int MostSleptMinute(Guard guard)
        {
            int maxIndex = 0, maxCount = 0;

            for (int i = 0; i < guard.Minutes.Length; i++)
            {
                if (guard.Minutes[i] > maxCount)
                {
                    maxCount = guard.Minutes[i];
                    maxIndex = i;
                }
            }

            // Relative to 00:00 since most things happen at midnight hour
            return maxIndex - 30;
        }

        public static bool IsGuardInfo(string s)
        {
            return s.Contains("Guard");
        }

        public static bool IsWakeUpInfo(string s)
        {
            return s.Contains("wakes");
        }

        public static bool IsSleepInfo(string s)
        {
            return s.Contains("falls");
        }

        // Maps 23:30 to 0 and 01:15 to 104 and same for others
        public static int GetIndexFromTime(string time)
        {
            return GetIndexFromTime(DateTime.Parse(time));
        }

        public static int GetIndexFromTime(DateTime dateTime)
        {
            DateTime epoch;

            if (dateTime.Hour == 23)
            {
                epoch = DateTime.Parse($"{dateTime.Year}-{dateTime.Month}-{dateTime.Day} 23:30");
            }
            else
            {
                // Hour would be 00 or 01, move back a day to get correct index
                var previousDate = dateTime.AddDays(-1);
                epoch = DateTime.Parse($"{previousDate.Year}-{previousDate.Month}-{previousDate.Day} 23:30");
            }

            return (int)(dateTime - epoch).TotalMinutes;
        }
    }

    
}
