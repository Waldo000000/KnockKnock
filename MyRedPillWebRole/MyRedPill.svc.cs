using System;
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
            return 42; //tfsbad
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        public string ReverseWords(string s)
        {
            throw new NotImplementedException();
        }
    }
}
