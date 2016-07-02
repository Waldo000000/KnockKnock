using System;
using System.Collections.Generic;
using System.Linq;
using RedPillContract.RedPill;

namespace MyRedPillWebRole
{
    public class MyRedPill : IRedPill
    {
        public Guid WhatIsYourToken()
        {
            throw new NotImplementedException();
        }

        public long FibonacciNumber(long n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException(nameof(n), "Cannot calculate Fibonnaci number for integers less than 1");
            return n <= 2 ? 1 
                : FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            List<int> sides = new[] { a, b, c }.OrderByDescending(s => s).ToList();

            if (sides.Any(s => s <= 0))
                return TriangleType.Error;

            if (sides.First() >= sides.Skip(1).Sum())
                return TriangleType.Error;

            int numEqualSides = sides.GroupBy(s => s).Max(g => g.Count());

            switch (numEqualSides)
            {
                case 3: return TriangleType.Equilateral;
                case 2: return TriangleType.Isosceles;
                default: return TriangleType.Scalene;
            }
        }

        public string ReverseWords(string s)
        {
            throw new NotImplementedException();
        }
    }
}
