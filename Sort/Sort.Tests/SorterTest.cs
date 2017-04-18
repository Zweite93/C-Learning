using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace Sort.Tests
{
    [TestClass]
    public class SorterTest
    {
        private static void SortTest(List<int> list, List<int> expectedResult)
        {
            var sorter = new Sorter(new IntSorter());
            CollectionAssert.AreEqual(expectedResult, sorter.Sort(list));
        }

        [TestMethod]
        public void SimpleSortTest()
        {
            SortTest(new List<int> { 4, 2, 1, 5 }, new List<int> { 1, 2, 4, 5 });
        }

        [TestMethod]
        public void NegativeAndZeroValuesTest()
        {
            SortTest(new List<int> { 4, -2, 0, 5 }, new List<int> { -2, 0, 4, 5 });
        }

        [TestMethod]
        public void RepetitiveValuesTest()
        {
            SortTest(new List<int> { 4, 2, 2, 5, 1 }, new List<int> { 1, 2, 2, 4, 5 });
        }

        [TestMethod]
        public void OnlyNegativeValuesTest()
        {
            SortTest(new List<int> { -4, -2, -5, -1 }, new List<int> { -5, -4, -2, -1 });
        }

        [TestMethod]
        public void SingleValueTest()
        {
            SortTest(new List<int> { 0 }, new List<int> { 0 });
        }

        [TestMethod]
        public void NoValuesTest()
        {
            SortTest(new List<int>(), new List<int>());
        }
    }
}
