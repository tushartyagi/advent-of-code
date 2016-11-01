using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using AdventOfCode.ExtensionMethods;

namespace AdventOfCode.Day7a {

    public class Wire {
        public string Id { get; set; }
        public Lazy<int> Signal { get; private set;}

        public Wire(string id, Lazy<int> signal) {
            Id = id;
            Signal = signal;
        }

        public Wire(string id) {
            Id = id;
        }

        public Wire(string id, int signal) {
            Id = id;
            Signal = new Lazy<int>(() => signal);
        }

        public void AddSignal(int signal) {
            Signal = new Lazy<int>(() => signal);
        }

        public void AddSignal(Lazy<int> signal) {
            Signal = signal;
        }
        public Wire And (Wire b, string id) {
            return new Wire(id: id, 
                        signal: new Lazy<int>(() => Signal.Value & b.Signal.Value));
        }

        public Wire Or (Wire b, string id) {
            return new Wire(id: id, 
                        signal: new Lazy<int>(() => Signal.Value | b.Signal.Value));
        }
        
        public Wire LShift (int bits, string id) {
            return new Wire(id: id, 
                        signal: new Lazy<int>(() => Signal.Value << bits));
        }

        public Wire RShift (int bits, string id) {
            return new Wire(id: id, 
                        signal: new Lazy<int>(() => Signal.Value >> bits));
        }

        public Wire Not (string id) {
            return new Wire(id: id, 
                        signal: new Lazy<int>(() => 65535 - Signal.Value));
        }
    }

    // This fills the environment with the absolute and relative values:
    // Absolute: 19138 -> b
    // Relative: lf AND lq -> ls
    public class Parser {

        // In the first iteration of the code, environment stores the values 
        // as strings just so the evaluation can be deferred.
        private IDictionary<string, string> _environment;

        public Parser ()
        {
            _environment = new Dictionary<string, string>();
        }

        public Parser(IDictionary<string, string> environment) {
            _environment = environment;
        }

        public void Parse(string instruction) {

            var parts = instruction.Split(new string[]{"->"}, StringSplitOptions.RemoveEmptyEntries);
            
            if (parts.Length != 2) {
                throw new ArgumentException("The instruction provided is malformed");
            }
            else {
                _environment.Add(parts[1].Trim(), parts[0].Trim());
            }
        }
    }
    

    // Converts values from Relative to Absolute
    public class Evaluator {
        private IDictionary<string, string> _environment;

        public Evaluator ()
        {
            _environment = new Dictionary<string, string>();
        }

        public Evaluator(IDictionary<string, string> environment) {
            _environment = environment;
        }

        public Wire Evaluate(string key) {
            int result;

            // There are cases when the key passed is simply an int/signal
            if (int.TryParse(key, out result)) {
                return new Wire("result", result);
            }

            // Otherwise, this is a key or another expression which needs 
            // to be evaluated.
            var instruction = _environment[key];
            if (int.TryParse(instruction, out result)) {
                return new Wire("result", result);
            }
            else {
                var binaryPattern = @"(\w+)\s(AND|OR|LSHIFT|RSHIFT)\s(\w+)";
                var unaryPattern  = @"(NOT)\s(\w+)";

                 if (instruction.Contains("AND")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var rightOperand = r.Groups[3].Value;

                        var leftWire = Evaluate(leftOperand);
                        var rightWire = Evaluate(rightOperand);
                        return leftWire.And(rightWire, "result");
                    }
                }
                else if (instruction.Contains("OR")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var rightOperand = r.Groups[3].Value;

                        var leftWire = Evaluate(leftOperand);
                        var rightWire = Evaluate(rightOperand);
                        return leftWire.Or(rightWire, "result");
                    }
                }
                else if (instruction.Contains("NOT")) {
                    var r = Regex.Match(instruction, unaryPattern);
                    if (r.Success && r.Groups.Count == 3) {
                        var leftOperand = r.Groups[2].Value;

                        var leftWire = Evaluate(leftOperand);
                        return leftWire.Not("result");
                    }
                }
                else if (instruction.Contains("LSHIFT")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var bits = int.Parse(r.Groups[3].Value);

                        var leftWire = Evaluate(leftOperand);
                        return leftWire.LShift(bits, "result");
                    }
                }
                else if (instruction.Contains("RSHIFT")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var bits = int.Parse(r.Groups[3].Value);

                        var leftWire = Evaluate(leftOperand);
                        return leftWire.RShift(bits, "result");
                    }
                }

                throw new KeyNotFoundException();
            }
        }
    }


    public static class Runner {

        public static void Run() {
            var env = new Dictionary<string, string>();
            var p = new Parser(env);
            var e = new Evaluator(env);

            using (StreamReader sr = new StreamReader(File.Open("Input/Day7.txt", FileMode.Open))) {
                for(var instruction = sr.ReadLine(); instruction != null; instruction = sr.ReadLine()) {
                    p.Parse(instruction.Trim());
                }
                var a = e.Evaluate("lx");
                System.Console.WriteLine("The value of 'a is: " + a.Signal.Value);
            }
        }
    }

}