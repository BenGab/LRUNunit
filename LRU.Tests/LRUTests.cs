using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.ComTypes;
using UnitTestsLRUKelementArray;

namespace Tests
{
    [TestFixture]
    public class LRUTests
    {
        [Test]
        public void Constructor_Defatult_Limit()
        {
            //ARRANGE
            const int defaultLimit = 12;

            //ACT
            LRU sut = new LRU();

            //ASSERT
            Assert.That(sut.Limit, Is.EqualTo(defaultLimit));
        }

        [Test]
        public void constructor_expected_limit()
        {
            const int expectedLimit = 6;

            LRU sut = new LRU(expectedLimit);

            Assert.That(sut.Limit, Is.EqualTo(expectedLimit));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void constructor_negativeflow(int wrongLimit)
        {
            Assert.Throws<ArgumentException>(() => new LRU(wrongLimit));
        }

        [Test]
        public void constructor_expected_list_not_null()
        {
            const int expectedLimit = 6;
            LRU sut = new LRU(expectedLimit);

            Assert.That(sut.Elements, Is.Not.Null);
        }

        [Test]
        public void add_element_should_contains_in_list()
        {
            LRU sut = new LRU();

            sut.Add(5);

            Assert.That(sut.Elements.First(), Is.EqualTo(5));
        }

        [Test]
        public void every_element_should_be_first_item()
        {
            LRU sut = new LRU();

            sut.Add(5);
            sut.Add(6);

            Assert.That(sut.Elements.First(), Is.EqualTo(6));
        }

        [Test]
        public void overload_shoul_keep_same_lenght()
        {
            LRU sut = new LRU(1);
            sut.Add(5);
            sut.Add(6);

            Assert.That(sut.Elements.Count, Is.EqualTo(1));
        }

        [Test]
        public void overload_should_no_keep_last_element()
        {
            LRU sut = new LRU(1);
            sut.Add(5);
            sut.Add(6);
            List<object> expected = new List<object>() { 6 };

            CollectionAssert.AreEqual(sut.Elements, expected);
        }

        [Test]
        public void Add_null_Should_Throw_ArgumentNullException()
        {
            LRU sut = new LRU();
            Assert.Throws<ArgumentNullException>(() => sut.Add(null));
        }

        [Test]
        public void Add_ExistValut_Should_Move_To_Top()
        {
            LRU sut = new LRU(4);

            sut.Add(5);
            sut.Add(4);
            sut.Add(3);
            sut.Add(5);

            Assert.That(sut.Elements.Last, Is.Not.EqualTo(5));
        }
    }
}
