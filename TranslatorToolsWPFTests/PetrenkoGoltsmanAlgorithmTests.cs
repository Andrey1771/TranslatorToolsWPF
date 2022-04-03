using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetrenkoGoltsmanAlgorithmLibrary;
using System.Collections.Generic;
using System.Linq;

namespace TranslatorToolsWPFTests
{
    [TestClass]
    public class PetrenkoGoltsmanAlgorithmTests
    {
        [TestMethod]
        public void TestCalculateIndex_StringList()
        {
            var strList = new List<string>() { "Ќе выходи из комнаты, не совершай ошибку.",
                                               "выходи и совершай ошибку.|",
                                               "«а жизнь нужно сражатьс€, за красоту можно умере.| “арик",
                                               "—амый весомый аргумент против демократии - это п€тиминутный разговор с избирателем. | Some",
                                               "я не знаю каким оружием будет вестись 3 мирова€ война, но 4 будет палками и камн€ми" };

            var correctIndexes = new List<double>() { 17968.5, 4630.5, 32000, 178955.5, 150381.5 };
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CalculateIndex(strList).SequenceEqual(correctIndexes), answer);
        }

        [TestMethod]
        public void TestCalculateIndex_StringList_WithEmptyStringList()
        {
            var strList = new List<string>();
            var correctIndexes = new List<double>();
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CalculateIndex(strList).SequenceEqual(correctIndexes), answer);
        }

        [TestMethod]
        public void TestCalculateIndex_String()
        {
            var str = "Ќе выходи из комнаты, не совершай ошибку.";
            var answer = 17968.5;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CalculateIndex(str), answer);
        }

        [TestMethod]
        public void TestCalculateIndex_String_WithEmptyString()
        {
            var str = "";
            var answer = 0;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CalculateIndex(str), answer);
        }

        [TestMethod]
        public void TestCalculateIndex_String_WithOnlySymbolsString()
        {
            var str = ",:-- ; ,, , | ";
            var answer = 0;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CalculateIndex(str), answer);
        }

        //public static async Task<Dictionary<string, List<string>>> CompareIndexes(IEnumerable<string> leftStrList, IEnumerable<string> rightStrList)

        [TestMethod]
        public void TestCompareIndexes_StringList()
        {
            var leftStrList = new List<string>() { "Ќе выходи из комнаты, не совершай ошибку.",
                                                   "выходи и совершай ошибку.|",
                                                   "«а жизнь нужно сражатьс€, за красоту можно умере.| “арик",
                                                   "—амый весомый аргумент против демократии - это п€тиминутный разговор с избирателем. | Some",
                                                   "я не знаю каким оружием будет вестись 3 мирова€ война, но 4 будет палками и камн€ми" };

            var rightStrList = new List<string>() { "Do not leave the room, don't make a mistake.",
                                                    "come out and make a mistake.",
                                                    "I don't know what weapons world war 3 will",
                                                    "The most weighty argument against democracy is a five-minute conversation with a voter. | Some",
                                                    "You have to fight for life, you can die for beautyM.| Tarik" };

            var correctMatches = new Dictionary<string, List<string>>() { { "Ќе выходи из комнаты, не совершай ошибку.", new List<string>() { "Do not leave the room, don't make a mistake.", "I don't know what weapons world war 3 will" } },
                                                                  { "выходи и совершай ошибку.|", new List<string>() },
                                                                  { "«а жизнь нужно сражатьс€, за красоту можно умере.| “арик", new List<string>() { "You have to fight for life, you can die for beautyM.| Ta" } },
                                                                  { "—амый весомый аргумент против демократии - это п€тиминутный разговор с избирателем. | Some", new List<string>() },
                                                                  { "я не знаю каким оружием будет вестись 3 мирова€ война, но 4 будет палками и камн€ми", new List<string>() }
            };

            var answer = true;
            //TODO Fix that
            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(leftStrList, rightStrList).Result.SequenceEqual(correctMatches), answer);
        }

        [TestMethod]
        public void TestCompareIndexes_StringList_WithEmptyStrLists()
        {
            var leftStrList = new List<string>();
            var rightStrList = new List<string>();
            var correctMatches = new Dictionary<string, List<string>>();
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(leftStrList, rightStrList).Result.SequenceEqual(correctMatches), answer);
        }

        [TestMethod]
        public void TestCompareIndexes_String()
        {
            var firstStr = "Ќе выходи из комнаты, не совершай ошибку.";
            var secondStr = "Do not leave the room, don't make a mistake.";
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(firstStr, secondStr), answer);
        }

        [TestMethod]
        public void TestCompareIndexes_String_WithComments()
        {
            var firstStr = "Ќе выходи из комнаты, не совершай ошибку. | fgewe";
            var secondStr = "Do not leave the room, don't make a mistake.|ge";
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(firstStr, secondStr), answer);
        }

        [TestMethod]
        public void TestCompareIndexes_String_WithEmptyComments()
        {
            var firstStr = "Ќе выходи из комнаты, не совершай ошибку.|";
            var secondStr = "Do not leave the room, don't make a mistake.";
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(firstStr, secondStr), answer);
        }
    }
}


/*
public static List<double> CalculateIndex(IEnumerable<string> strList)
        {
            var indexesList = new List<double>();
            foreach (var str in strList) // ћожет быть, имеет смысл разбить на несколько участков и потоков, соответственно?
            {
                indexesList.Add(Calculate(TakeSymbols(RemoveComments(str)).Length));
            }

            return indexesList;
        }

        public static async Task<Dictionary<string, List<string>>> CompareIndexes(IEnumerable<string> leftStrList, IEnumerable<string> rightStrList)
        {
            var leftIndexesList = await Task.Run(() =>
            {
                return CalculateIndex(leftStrList);
            });

            var rightIndexesList = await Task.Run(() =>
            {
                return CalculateIndex(rightStrList);
            });

            return MatchStrings(leftStrList, rightStrList, leftIndexesList, rightIndexesList);
        }
 */

/*            var i = PetrenkoGoltsmanAlgorithm.CalculateIndex("Ќе выходи из комнаты, не совершай ошибку.");
            var r = PetrenkoGoltsmanAlgorithm.CalculateIndex("выходи и совершай ошибку.|");
            var t = PetrenkoGoltsmanAlgorithm.CalculateIndex("«а жизнь нужно сражатьс€, за красоту можно умере.| “арик");
            var y = PetrenkoGoltsmanAlgorithm.CalculateIndex("—амый весомый аргумент против демократии - это п€тиминутный разговор с избирателем. | Some");
            var u = PetrenkoGoltsmanAlgorithm.CalculateIndex("я не знаю каким оружием будет вестись 3 мирова€ война, но 4 будет палками и камн€ми");


            var o = PetrenkoGoltsmanAlgorithm.CalculateIndex("Do not leave the room, don't make a mistake.");
            var k = PetrenkoGoltsmanAlgorithm.CalculateIndex("come out and make a mistake.");
            var g = PetrenkoGoltsmanAlgorithm.CalculateIndex("I don't know what weapons world war 3 will");
            var h = PetrenkoGoltsmanAlgorithm.CalculateIndex("The most weighty argument against democracy is a five-minute conversation with a voter. | Some");
            var j = PetrenkoGoltsmanAlgorithm.CalculateIndex("You have to fight for life, you can die for beautyM.| Tarik");
*/