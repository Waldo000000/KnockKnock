using System;
using System.Collections.Generic;
using System.Linq;
using EasyAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRedPillWebRole;
using RedPillContract.RedPill;

namespace MyRedPillTests
{
    public abstract class RedPillTests
    {
        protected abstract IRedPill RedPill { get; }

        [TestMethod]
        public void FibonacciNumber_LessThanOne_Throws()
        {
            Enumerable.Range(-10, 0)
                .AllItemsSatisfy(n => Should.Throw<ArgumentOutOfRangeException>(() => RedPill.FibonacciNumber(n)));
        }

        [TestMethod]
        public void FibonacciNumber_SmallIntegers_ReturnsCorrespondingFibonacciNumber()
        {
            IEnumerable<FibonacciResult> expected = new List<long> { 1, 1, 2, 3, 5, 8, 13, 21, 34 }.Select((e, n) => new FibonacciResult(n + 1, e));
            expected.AllItemsSatisfy(e => RedPill.FibonacciNumber(e.Number).ShouldBe(e.FibonacciNumber, $"Failed for n={e.Number}"));
        }

        public class FibonacciResult
        {
            public int Number { get; }
            public long FibonacciNumber { get; }

            public FibonacciResult(int number, long fibonacciNumber)
            {
                Number = number;
                FibonacciNumber = fibonacciNumber;
            }
        }
    }

    [TestClass]
    public class ReadifyRedPillTests : RedPillTests
    {
        protected override IRedPill RedPill => new RedPillClient("BasicHttpBinding_IRedPill_Readify");
    }

    [TestClass]
    public class MyLocalRedPillTests : RedPillTests
    {
        protected override IRedPill RedPill => new MyRedPill();
    }

    [TestClass, Ignore]
    public class MyProdRedPillTests : RedPillTests
    {
        protected override IRedPill RedPill => new RedPillClient("BasicHttpBinding_IRedPill");
    }
}
