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




}