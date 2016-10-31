using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.ExtensionMethods;

namespace AdventOfCode.Day7 {
    public abstract class Wire {}
    public interface IOperation {
        int Evaluate();
    }

    public abstract class Signal {
        /* A Signal can be:
        * An Integar - from 0 to 65535
        * A Binary Operation - BinOp * Signal * Signal
        * An Unary Operation - UnOp  * Signal 
        */

        public abstract int Value { get; }
    }

    public enum Operation {
        And,
        Or,
        Not,
        Lshift,
        RShift,
        Assignment
    }



    public class IntSignal : Signal
    {
        public override int Value { get; }

        public IntSignal (int val)
        {
            Value = val;
        }

    }

    public class BinarySignal : Signal{
        public Signal Signal1 { get; }
        public Signal Signal2 { get; }
        public Operation Operation { get; }

        public BinarySignal (Operation op, Signal signal1, Signal signal2) {
            Operation = op;
            Signal1 = signal1;
            Signal2 = signal2;
        }

        public override int Value { get; }

    }

    public class UnarySignal : Signal {
        public Signal Signal { get; }
        public Operation Operation { get; }
        public UnarySignal (Operation op, Signal signal) {
            Operation = op;
            Signal = signal;
        }

        public override int Value { get; }
    }

    public class Not : IOperation {
        private Wire _wire;
        public Not (Wire x)
        {
            _wire = x;
        }

        public int Evaluate() {
            
            return 42;
        }
    }

    public class Parser {

        // In the first iteration of the code, environment stores the values 
        // as strings just so the evaluation can be deferred. There is a Lazy<T>
        // defined in c# but keeping that for the stage once the system starts 
        // working.
        private IDictionary<string, Signal> _environment;

        public Parser ()
        {
            _environment = new Dictionary<string, Signal>();
        }

        public Parser(IDictionary<string, Signal> environment) {
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
                    var rhs = r.Groups[4].Value;

                    _environment.Add(rhs, 
                        new BinarySignal(Operation.And, 
                                    _environment.Find(leftOperand), 
                                    _environment.Find(rightOperand)));
                
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
                    _environment.Add(rhs, 
                        new UnarySignal(Operation.Assignment, 
                                    _environment.Find(signal)));
                
                    success = true;
            }

            if (!success) {
                throw new InvalidOperationException("Cannot parse the instruction");
            }
        }
    }
    }
}
