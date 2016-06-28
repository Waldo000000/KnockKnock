using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRedPillWebRole;
using RedPillContract.RedPill;

namespace MyRedPillTests
{
    public abstract class RedPillTests
    {
        protected abstract IRedPill RedPill { get; }

        [TestMethod]
        public void FibonacciNumber_3_2()
        {
            Assert.AreEqual(2, RedPill.FibonacciNumber(3));
        }
    }

    [TestClass]
    public class ReadifyRedPillTests : RedPillTests
    {
        protected override IRedPill RedPill => new RedPillClient("BasicHttpBinding_IRedPill_Readify");
    }

    [TestClass]
    public class MyProdRedPillTests : RedPillTests
    {
        protected override IRedPill RedPill => new RedPillClient("BasicHttpBinding_IRedPill");
    }

    [TestClass]
    public class MyLocalRedPillTests : RedPillTests
    {
        protected override IRedPill RedPill => new MyRedPill();
    }
}
