using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DocumentBuilderLibrary;
using DocumentBuilderLibrary.PositionUtil;

namespace TranslatorToolsWPFTests.EPPlusLibrary
{
    [TestClass]
    public class TableTests // TODO Refactoring
    {
        [TestMethod]
        public void TestToListTable_Int_Correct_Zero()
        {
            var table = new Table<int>();

            var result = table.ToListTable();

            var correctAnswer = new List<List<int>>();
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect), true);
        }

        [TestMethod]
        public void TestToListTable_Bool_Correct_One()
        {
            bool ok;
            var table = new Table<bool>();
            var firstPos = new Position(0, 0);
            var secondPos = new Position(2, 2);

            var result = table.Add(firstPos, secondPos, true, out ok).ToListTable();

            var correctAnswer = new List<List<bool>>() {
                new() { true, true, true },
                new() { true, true, true },
                new() { true, true, true },
            };
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect) && ok, true);
        }

        [TestMethod]
        public void TestToListTable_Int_Correct_Two()
        {
            bool ok;
            var table = new Table<int>();
            var tablePositions = new List<Position>() { new Position(1, 1), new Position(2, 2), new Position(3, 2), new Position(5, 5) };

            var result = table.Add(tablePositions[0], tablePositions[1], 1, out ok).Add(tablePositions[2], tablePositions[3], 2, out ok).ToListTable();

            var correctAnswer = new List<List<int>>() {
                new() { 0, 0, 0, 0, 0, 0 },
                new() { 0, 1, 1, 0, 0, 0 },
                new() { 0, 1, 1, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
            };
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect) && ok, true);
        }

        [TestMethod]
        public void TestToListTable_Int_Correct_Three()
        {
            bool ok;
            var table = new Table<int>();
            var tablePositions = new List<Position>() { new Position(1, 1), new Position(2, 2), new Position(3, 2), new Position(5, 5), new Position(4, 0), new Position(5, 1) };

            var result = table.Add(tablePositions[0], tablePositions[1], 1, out ok).Add(tablePositions[2], tablePositions[3], 2, out ok).Add(tablePositions[4], tablePositions[5], 3, out ok).ToListTable();

            var correctAnswer = new List<List<int>>() {
                new() { 0, 0, 0, 0, 3, 3 },
                new() { 0, 1, 1, 0, 3, 3 },
                new() { 0, 1, 1, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
                new() { 0, 0, 0, 2, 2, 2 },
            };
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect) && ok, true);
        }

        [TestMethod]
        public void TestToListTable_Int_Default()
        {
            bool ok;
            var table = new Table<int>();
            var firstPos = new Position(1, 1);
            var secondPos = new Position(2, 2);

            var result = table.Add(firstPos, secondPos, 1, out ok).ToListTable(-1);

            var correctAnswer = new List<List<int>>() {
                new() { -1, -1, -1 },
                new() { -1,  1,  1 },
                new() { -1,  1,  1 },
            };
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect) && ok, true);
        }

        [TestMethod]
        public void TestToListTable_Int_Point()
        {
            bool ok;
            var table = new Table<int>();
            var firstPos = new Position(2, 2);
            var secondPos = new Position(2, 2);

            var result = table.Add(firstPos, secondPos, 1, out ok).ToListTable();

            var correctAnswer = new List<List<int>>() {
                new() { 0, 0, 0 },
                new() { 0, 0, 0 },
                new() { 0, 0, 1 },
            };
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect) && ok, true);
        }

        [TestMethod]
        public void TestToListTable_Int_Negative_Position_One()
        {
            bool ok;
            var table = new Table<int>();
            var firstPos = new Position(0, 0);
            var secondPos = new Position(-1, 2);

            var result = table.Add(firstPos, secondPos, 1, out ok).ToListTable();

            var correctAnswer = new List<List<int>>();

            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(!checkList.All(isCorrect => isCorrect) || ok, false);
        }

        [TestMethod]
        public void TestToListTable_Int_Negative_Position_Three()
        {
            bool ok;
            var table = new Table<int>();

            var tablePositions = new List<Position>() { new Position(1, 4), new Position(2, 5), new Position(0, -1), new Position(3, 2), new Position(4, 2), new Position(5, 5) };

            var result = table.Add(tablePositions[0], tablePositions[1], 1, out ok).Add(tablePositions[2], tablePositions[3], 2, out ok).Add(tablePositions[4], tablePositions[5], 3, out ok).ToListTable();

            var correctAnswer = new List<List<int>>() {
                new() { 0, 0, 0, 0, 0, 0 },
                new() { 0, 0, 0, 0, 0, 0 },
                new() { 0, 0, 0, 0, 3, 3 },
                new() { 0, 0, 0, 0, 3, 3 },
                new() { 0, 1, 1, 0, 3, 3 },
                new() { 0, 1, 1, 0, 3, 3 },
            };

            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect), true);
            Assert.AreEqual(ok, false);
        }

        [TestMethod]
        public void TestToListTable_Int_Intersect_Rectangles_Two()
        {
            bool ok;
            var table = new Table<int>();
            var tablePositions = new List<Position>() { new Position(1, 1), new Position(2, 2), new Position(2, 2), new Position(5, 5) };

            var result = table.Add(tablePositions[0], tablePositions[1], 1, out ok).Add(tablePositions[2], tablePositions[3], 2, out ok).ToListTable();

            var correctAnswer = new List<List<int>>() {
                new() { 0, 0, 0 },
                new() { 0, 1, 1 },
                new() { 0, 1, 1 },
            };
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(!checkList.All(isCorrect => isCorrect) || ok, false);
        }

        [TestMethod]
        public void TestToListTable_Int_Intersect_Rectangles_Three()
        {
            bool ok;
            var table = new Table<int>();
            var tablePositions = new List<Position>() { new Position(1, 1), new Position(2, 2), new Position(2, 2), new Position(5, 5), new Position(4, 0), new Position(5, 1) };

            var result = table.Add(tablePositions[0], tablePositions[1], 1, out ok).Add(tablePositions[2], tablePositions[3], 2, out ok).Add(tablePositions[4], tablePositions[5], 3, out ok).ToListTable();

            var correctAnswer = new List<List<int>>() {
                new() { 0, 0, 0, 0, 3, 3 },
                new() { 0, 1, 1, 0, 3, 3 },
                new() { 0, 1, 1, 0, 0, 0 },
            };
            var checkList = result.Select((row, index) => row.SequenceEqual(correctAnswer[index]));

            Assert.AreEqual(checkList.All(isCorrect => isCorrect), true);
            Assert.AreEqual(ok, false);
        }
    }
}
