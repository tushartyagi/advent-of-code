using System;
using System.Collections.Generic;
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
        // as strings just so the evaluation can be deferred. There is a Lazy<T>
        // defined in c# but keeping that for the stage once the system starts 
        // working.
        private IDictionary<string, Wire> _environment;

        public Parser ()
        {
            _environment = new Dictionary<string, Wire>();
        }

        public Parser(IDictionary<string, Wire> environment) {
            _environment = environment;
        }

        public void Parse(string instruction) {
            var success = false;
            var binaryPattern = @"(\w)\s(AND|OR|LSHIFT|RSHIFT)\s(\w)\s->\s(\w)";
            var unaryPattern  = @"(NOT)\s(\w)\s->\s(\w)";
            var assignmentPattern = @"(\w+)\s->\s(\w)";

            if (instruction.Contains("AND")) {
                var r = Regex.Match(instruction, binaryPattern);
                if (r.Success && r.Groups.Count == 5) {
                    var leftOperand = r.Groups[1].Value;
                    var rightOperand = r.Groups[3].Value;
                    var wireName = r.Groups[4].Value;
                

                    success = true;
                }
            }
            else if (instruction.Contains("OR")) {

            }
            else if (instruction.Contains("NOT")) {
                
            }
            else if (instruction.Contains("LSHIFT")) {
                
            }
            else if (instruction.Contains("RSHIFT")) {
                
            }
            else { // The remaining is the assignment of a signal
                var r = Regex.Match(instruction, assignmentPattern);
                if (r.Success && r.Groups.Count == 3) {
                    var signal = r.Groups[1].Value;
                    var rhs    = r.Groups[2].Value;
                    
                
                    success = true;
            }

            if (!success) {
                throw new InvalidOperationException("Cannot parse the instruction");
            }
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
            var instruction = _environment[key];
            int result;
            if (int.TryParse(instruction, out result)) {
                return new Wire("result", result);
            }
            else {
                var binaryPattern = @"(\w+)\s(AND|OR|LSHIFT|RSHIFT)\s(\w+)";
                var unaryPattern  = @"(NOT)\s(\w+)";
                var assignmentPattern = @"(\w+)";

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

}