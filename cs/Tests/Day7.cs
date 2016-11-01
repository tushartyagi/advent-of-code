using System.Collections.Generic;
using AdventOfCode.Day7;
using NUnit.Framework;

namespace AdventOfCode.Tests {

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
            Assert.AreEqual(19138, b);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_AND() {
            var ls = e.Evaluate("ls");
            Assert.AreEqual(72, ls);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_1_in_LHS() {
            var OneAndLq = e.Evaluate("1AndLq");
            // 1 & 111001000 => 0
            Assert.AreEqual(0, OneAndLq);
            var OneAndLf = e.Evaluate("1AndLf");
            // 1 & 1111011
            Assert.AreEqual(1, OneAndLf);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_1_in_RHS() {
            var lfAnd1 = e.Evaluate("lfAnd1");
            // 1111011 & 1 => 1
            Assert.AreEqual(1, lfAnd1);
            var lqAnd1 = e.Evaluate("lqAnd1");
            // // 111001000 & 1 => 0
            Assert.AreEqual(0, lqAnd1);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_OR() {
            var lo = e.Evaluate("lo");
            Assert.AreEqual(507, lo);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_NOT() {
            var ls = e.Evaluate("ln");
            Assert.AreEqual(65412, ls);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_LSHIFT() {
            var lsls = e.Evaluate("lsls");
            Assert.AreEqual(288, lsls);
        }

        [Test]
        public void It_Should_Evaluate_The_Relative_Values_Correctly_For_RSHIFT() {
            var lsrs = e.Evaluate("lsrs");
            Assert.AreEqual(18, lsrs);
        }
    }


}