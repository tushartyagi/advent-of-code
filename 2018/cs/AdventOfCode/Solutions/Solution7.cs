using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using AdventOfCode.Utils;
using System.Collections.Generic;

namespace AdventOfCode.Solutions
{
    public class Solution7
    {
        class State {

            public State(string name) {
                Name = name;
                Done = false;
                Pre = new List<State>();
                Post = new List<State>();
            }

            public string Name {get; set;}
            public bool Done {get; set;}
            public List<State> Pre {get; private set;} 
            public List<State> Post {get; private set;}

            public override string ToString() {
                return Name;
            }

            public void AddPre(State s) {
                this.Pre.Add(s);
            }

            public void AddPost(State s) {
                this.Post.Add(s);
            }
        }
        
        IDictionary<string, State> _states = new Dictionary<string, State>();
        const string pattern = @"Step (?<s1>\w) must be finished before step (?<s2>\w) can begin";
        Regex r = new Regex(pattern);
        
        public Solution7() {
            Setup();
            Solve1();
        }

        private void Setup()
        {
            foreach (var input in  Utils.Utils.ReadLines(7)) {
                var matches = r.Match(input);
                string preKey = matches.Groups["s1"].Value;
                string postKey = matches.Groups["s2"].Value;

                State pre, post;
                
                if (_states.ContainsKey(preKey)) {
                    pre = _states[preKey];
                } else {
                    pre = new State(preKey);
                    _states.Add(preKey, pre);
                }

                if (_states.ContainsKey(postKey)) {
                    post = _states[postKey];
                } else {
                    post = new State(postKey);
                    _states.Add(postKey, post);
                }

                pre.AddPost(post);
                post.AddPre(pre);
            }

        }
        
        public void Solve() {
            Solve1();
            Solve2();
        }

        public void Solve1() {
            var sources = _states.Where(k => k.Value.Pre.Count == 0);
            foreach(var s in sources) {
                Console.WriteLine(s.ToString());  
            }
            
        }

        public void Solve2() {
        }

    }

}
