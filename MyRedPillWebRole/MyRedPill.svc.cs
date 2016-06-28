using System;
using System.Threading.Tasks;
using MyRedPillWebRole.RedPill;

namespace MyRedPillWebRole
{
    public class MyRedPill : IRedPill
    {
        public Guid WhatIsYourToken()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> WhatIsYourTokenAsync()
        {
            throw new NotImplementedException();
        }

        public long FibonacciNumber(long n)
        {
            return 42; //tfsbad
        }

        public Task<long> FibonacciNumberAsync(long n)
        {
            throw new NotImplementedException();
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        public Task<TriangleType> WhatShapeIsThisAsync(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        public string ReverseWords(string s)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReverseWordsAsync(string s)
        {
            throw new NotImplementedException();
        }
    }
}
