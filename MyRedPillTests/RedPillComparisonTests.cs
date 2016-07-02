using System.Linq;
using System.Runtime.Serialization.Formatters;
using EasyAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRedPillWebRole;
using RedPillContract.RedPill;

namespace MyRedPillTests
{
    [TestClass]
    public class RedPillComparisonTests
    {
        private static IRedPill ReadifyRedPill => new RedPillClient("BasicHttpBinding_IRedPill_Readify");
        private static IRedPill MyRedPill => new MyRedPill();

        [TestMethod]
        public void FibonacciNumber_SmallPositiveIntegers_Equivalent()
        {
            Enumerable.Range(1, 30)
                .AllItemsSatisfy(n => MyRedPill.FibonacciNumber(n).ShouldBe(ReadifyRedPill.FibonacciNumber(n), $"Mismatching Fibonacci number for {n}"));
        }

        [TestMethod]
        public void WhatShapeIsThis_ThreeSmallIntegers_Equivalent()
        {
            Enumerable.Range(-1, 4).AllItemsSatisfy(a =>
                Enumerable.Range(-1, 4).AllItemsSatisfy(b =>
                    Enumerable.Range(-1, 4).AllItemsSatisfy(c =>
                        MyRedPill.WhatShapeIsThis(a, b, c).ShouldBe(ReadifyRedPill.WhatShapeIsThis(a, b, c), $"Incorrect type returned for ({a}, {b}, {c})"))));
        }
    }
}