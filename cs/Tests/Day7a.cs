using NUnit.Framework;
using AdventOfCode.Day7a;
using System.Collections.Generic;
using System;

namespace AdventOfCode.Tests {

    [TestFixture]
    public class WireTests {

        [Test]
        public void It_Should_Store_The_Operations_As_Thunks() {
            var wire_a = new Wire("a", 123);
            var wire_b = new Wire("b", 456);

            var z = wire_a.And(wire_b, "z");
            Assert.IsFalse(z.Signal.IsValueCreated);
        }

        [Test]
        public void It_Should_Evaluate_Nested_Values_When_Called() {
            var wire_a = new Wire("a", 123);
            var wire_b = new Wire("b", 456);

            var z = wire_a.And(wire_b, "z");
            Assert.AreEqual(72, z.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_Arbitarily_Nested_Values_When_Called() {
            var x = new Wire("x", 123);
            var y = new Wire("y", 456);

            var d = x.And(y, "d");
            var e = x.Or(y, "e");

            var f = x.LShift(2, "f");
            var g = y.RShift(2, "g");

            var h = x.Not("h");
            var i = y.Not("i");

            Assert.AreEqual(123, x.Signal.Value);
            Assert.AreEqual(456, y.Signal.Value);
            Assert.AreEqual(72 , d.Signal.Value);
            Assert.AreEqual(507, e.Signal.Value);
            Assert.AreEqual(492, f.Signal.Value);
            Assert.AreEqual(114, g.Signal.Value);
            Assert.AreEqual(65412, h.Signal.Value);
            Assert.AreEqual(65079, i.Signal.Value);
            
        }

        [Test]
        public void It_Should_Not_Fail_With_Values_Which_Will_Be_Defined_Later() {
            var lf = new Wire("lf");
            var lq = new Wire("lq");

            var ls = lf.And(lq, "ls");
            Assert.IsFalse(ls.Signal.IsValueCreated);
        }

        [Test]
        public void It_Should_Work_With_Values_Which_Will_Be_Defined_Later() {
            var lf = new Wire("lf");
            var lq = new Wire("lq");

            var ls = lf.And(lq, "ls");

            lf.AddSignal(123);
            lq.AddSignal(456);
            Assert.AreEqual(72 , ls.Signal.Value);   
        }

        [Test]
        public void It_Should_Work_With_Complex_Values_Which_Will_Be_Defined_Later() {
            var lf = new Wire("lf");
            var lq = new Wire("lq");

            var ls = lf.And(lq, "ls");

            lf.AddSignal(123);
            lq.AddSignal(456);
            Assert.AreEqual(72 , ls.Signal.Value);   
        }
    }

    public class EvaluatorTests {

        IDictionary<string, string> Environment;
        Evaluator e;

        [SetUp]
        public void Init() {
            Environment = new Dictionary<string, string>();
            Environment.Add("b", "19138");
            Environment.Add("ls", "lf AND lq");
            Environment.Add("1AndLq", "1 AND lq");
            Environment.Add("1AndLf", "1 AND lf");
            Environment.Add("lfAnd1", "lf AND 1");
            Environment.Add("lqAnd1", "lq AND 1");
            Environment.Add("lf", "123");
            Environment.Add("lq", "456");
            Environment.Add("lo", "lf OR lq");
            Environment.Add("ln", "NOT lf");
            Environment.Add("lsls", "ls LSHIFT 2");
            Environment.Add("lsrs", "ls RSHIFT 2");

            e = new Evaluator(Environment);
        }

        [Test]
        public void It_Should_Evaluate_The_Absolute_Values_Correctly() {
            var b = e.Evaluate("b");
            Assert.AreEqual("result", b.Id);
            Assert.AreEqual(19138, b.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_AND() {
            var ls = e.Evaluate("ls");
            Assert.AreEqual(72, ls.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_1_in_LHS() {
            var OneAndLq = e.Evaluate("1AndLq");
            // 1 & 111001000 => 0
            Assert.AreEqual(0, OneAndLq.Signal.Value);
            var OneAndLf = e.Evaluate("1AndLf");
            // 1 & 1111011
            Assert.AreEqual(1, OneAndLf.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_1_in_RHS() {
            var lfAnd1 = e.Evaluate("lfAnd1");
            // 1111011 & 1 => 1
            Assert.AreEqual(1, lfAnd1.Signal.Value);
            var lqAnd1 = e.Evaluate("lqAnd1");
            // // 111001000 & 1 => 0
            Assert.AreEqual(0, lqAnd1.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_OR() {
            var lo = e.Evaluate("lo");
            Assert.AreEqual(507, lo.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_NOT() {
            var ls = e.Evaluate("ln");
            Assert.AreEqual(65412, ls.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_LSHIFT() {
            var lsls = e.Evaluate("lsls");
            Assert.AreEqual(288, lsls.Signal.Value);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_RSHIFT() {
            var lsrs = e.Evaluate("lsrs");
            Assert.AreEqual(18, lsrs.Signal.Value);
        }
    }

    public class ParserTests {

        IDictionary<string, string> environment;
        Parser p;

        [SetUp]
        public void Init() {
            environment = new Dictionary<string, string>();
            p = new Parser(environment);
        }

        [Test]
        public void It_Should_Parse_The_Absolute_Values_Correctly() {
            p.Parse("19138 -> b");
            Assert.IsTrue(environment.ContainsKey("b"));
            Assert.AreEqual("19138", environment["b"]);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_AND() {
            p.Parse("ls AND lf -> lq");
            Assert.IsTrue(environment.ContainsKey("lq"));
            Assert.AreEqual("ls AND lf", environment["lq"]);
        }
    }
}