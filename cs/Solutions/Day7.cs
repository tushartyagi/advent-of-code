using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using AdventOfCode.ExtensionMethods;

namespace AdventOfCode.Day7 {

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

    public class Evaluator {
        private IDictionary<string, string> _environment;

        public Evaluator ()
        {
            _environment = new Dictionary<string, string>();
        }

        public Evaluator(IDictionary<string, string> environment) {
            _environment = environment;
        }

        public int Evaluate(string key) {
            int result;

            // System.Console.WriteLine("Evaluating {0}.", key);
            // Base Cases
            if (int.TryParse(key, out result)) {
                return result;
            }
            var instruction = _environment[key];
            if (int.TryParse(instruction, out result)) {
                return result;
            }

            // Recursive cases
            else {
                var binaryPattern = @"(\w+)\s(AND|OR|LSHIFT|RSHIFT)\s(\w+)";
                var unaryPattern  = @"(NOT)\s(\w+)";

                 if (instruction.Contains("AND")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var rightOperand = r.Groups[3].Value;

                        var leftSignal = Evaluate(leftOperand);
                        var rightSignal = Evaluate(rightOperand);

                        var evaluation = leftSignal & rightSignal;
                        _environment[key] = evaluation.ToString();

                        return evaluation;
                    }
                }
                else if (instruction.Contains("OR")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var rightOperand = r.Groups[3].Value;

                        var leftSignal = Evaluate(leftOperand);
                        var rightSignal = Evaluate(rightOperand);
                        
                        var evaluation = leftSignal | rightSignal;
                        _environment[key] = evaluation.ToString();

                        return evaluation;
                    }
                }
                else if (instruction.Contains("NOT")) {
                    var r = Regex.Match(instruction, unaryPattern);
                    if (r.Success && r.Groups.Count == 3) {
                        var leftOperand = r.Groups[2].Value;

                        var leftSignal = Evaluate(leftOperand);

                        var evaluation = (65535 - leftSignal);
                        _environment[key] = evaluation.ToString();

                        return evaluation;
                    }
                }
                else if (instruction.Contains("LSHIFT")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var bits = int.Parse(r.Groups[3].Value);

                        var leftSignal = Evaluate(leftOperand);
                        var evaluation = leftSignal << bits;
                        _environment[key] = evaluation.ToString();

                        return evaluation;

                    }
                }
                else if (instruction.Contains("RSHIFT")) {
                    var r = Regex.Match(instruction, binaryPattern);
                    if (r.Success && r.Groups.Count == 4) {
                        var leftOperand = r.Groups[1].Value;
                        var bits = int.Parse(r.Groups[3].Value);

                        var leftSignal = Evaluate(leftOperand);
                        var evaluation =  leftSignal >> bits;
                        _environment[key] = evaluation.ToString();

                        return evaluation;

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
                System.Console.WriteLine("The value of 'a is: " + a);
            }
        }
    }
}