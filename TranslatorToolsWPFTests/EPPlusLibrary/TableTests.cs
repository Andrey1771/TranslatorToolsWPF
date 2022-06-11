using EPPlusLibrary;
using EPPlusLibrary.PositionUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsWPFTests.EPPlusLibrary
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        public void TestAdd_Bool_Single()
        {
            bool ok;
            var table = new Table<bool>();
            var firstPos = new Position(0, 0);
            var secondPos = new Position(2, 2);

            var result = table.Add(firstPos, secondPos, true, out ok).ToListTable(false);

            var correctAnswer = new List<List<bool>>() {
                new() { true, true, true },
                new() { true, true, true },
                new() { true, true, true },
            };

            Assert.AreEqual(result.All(n => correctAnswer.All(t => t.SequenceEqual(n))), true);
        }

        [TestMethod]
        public void TestAdd_Int_Two()
        {
            bool ok;
            var table = new Table<int>();
            var tablePositions = new List<Position>() { new Position(1, 1), new Position(2, 2), new Position(3, 2), new Position(5, 5) };

            var result = table.Add(tablePositions[0], tablePositions[1], 1, out ok).Add(tablePositions[2], tablePositions[3], 2, out ok).ToListTable(0);

            var correctAnswer = new List<List<int>>() {
                new() { 0, 0, 0, 0, 0, 0 },
                new() { 0, 1, 1, 0, 0, 0 },
                new() { 0, 1, 1, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
            };

            Assert.AreEqual(result.All(n => correctAnswer.All(t => t.SequenceEqual(n))), true);
        }

        [TestMethod]
        public void TestAdd_Bool_Three()
        {
            bool ok;
            var table = new Table<bool>();
            var firstPos = new Position(0, 0);
            var secondPos = new Position(2, 2);

            var result = table.Add(firstPos, secondPos, true, out ok).ToListTable(false);

            var correctAnswer = new List<List<bool>>() { new() { true, true, true },
            new() { true, true, true },
            new() { true, true, true },
            };

            Assert.AreEqual(result.All(n => correctAnswer.All(t => t.SequenceEqual(n))), true);
        }
    }
}
