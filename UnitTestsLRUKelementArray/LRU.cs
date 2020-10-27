using System;
using System.Collections.Generic;

namespace UnitTestsLRUKelementArray
{
    public class LRU
    {
        public int Limit { get; private set; }
        public List<object> Elements { get; private set; }

        public LRU(int limit=12)
        {
            if(limit <=0)
            {
                throw new ArgumentException($"{limit} could not be less or equalzero");
            }
            Limit = limit;
            Elements = new List<object>(Limit);
        }

        public void Add(object value)
        {
            value.NotNull();

            if(Elements.Contains(value))
            {
                Elements.RemoveAt(Elements.IndexOf(value));
            }

            if(Elements.Count == Limit)
            {
                Elements.RemoveAt(Limit - 1);
            }

            Elements.Insert(0, value);
        }
    }
}
