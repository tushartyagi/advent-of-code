using System;
using System.Collections.Generic;

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

    public abstract class Operation {}
    public class Binary : Operation {}
    public class Unary : Operation {}

    public class IntSignal : Signal
    {
        public override int Value { get; }

        public IntSignal (int val)
        {
            Value = val;
        }

    }

    public class BinarySignal : Signal{
        Signal _signal1;
        Signal _signal2;
        Operation _op;

        public BinarySignal (Operation op, Signal signal1, Signal signal2) {

        }

        public override int Value { get; }

    }

    public class UnarySignal : Signal {
        Signal _signal;
        Operation _op;

        public UnarySignal (Operation op, Signal signal) {

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
        private IDictionary<string, string> _environment;

        public Parser ()
        {
            _environment = new Dictionary<string, string>();
        }

        public Parser(IDictionary<string, string> environment) {
            _environment = environment;
        }
    }

}