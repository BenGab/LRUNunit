using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestsLRUKelementArray;

namespace Tests
{
    [TestFixture]
    public class KArrayTest
    {
        [Test]
        public void expectedSol()
        {
            int[] A = new int[] { 1, 2, 1, 2, 3, 2, -3, -1, -2 };

            var result = KarraySol.Sol(A);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void should_return_zero_when_not_paired()
        {
            int[] A = new int[] { 1, 2, 2, 3, 4, 5 };

            var result = KarraySol.Sol(A);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
