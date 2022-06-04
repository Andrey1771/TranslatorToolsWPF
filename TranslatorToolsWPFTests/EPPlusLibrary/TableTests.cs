using EPPlusLibrary;
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
            var ok = false;
            var table = new Table<bool>();
            Add(Position inFirstPosition, Position inSecondPosition, T obj, out ok);
        }
    }
}
