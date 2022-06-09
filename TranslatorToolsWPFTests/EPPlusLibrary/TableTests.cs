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
        public void TestAdd()
        {
            bool ok;
            var table = new Table<bool>();
            var firstPos = new Position(0, 0);
            var secondPos = new Position(2, 2);

            var correctAnswer = new List<List<bool>>() { new() { true, true, true },
            new() { true, true, true },
            new() { true, true, true },
            };

            var listTable = table.Add(firstPos, secondPos, true, out ok).ToListTable(false);

            Assert.AreEqual(listTable.SequenceEqual(correctAnswer), true);
        }
    }
}
