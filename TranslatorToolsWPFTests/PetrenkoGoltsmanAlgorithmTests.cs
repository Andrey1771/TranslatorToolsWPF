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
            var strList = new List<string>() { "�� ������ �� �������, �� �������� ������.",
                                               "������ � �������� ������.|",
                                               "�� ����� ����� ���������, �� ������� ����� �����.| �����",
                                               "����� ������� �������� ������ ���������� - ��� ������������ �������� � �����������. | Some",
                                               "� �� ���� ����� ������� ����� ������� 3 ������� �����, �� 4 ����� ������� � �������" };

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
            var str = "�� ������ �� �������, �� �������� ������.";
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
            var leftStrList = new List<string>() { "�� ������ �� �������, �� �������� ������.",
                                                   "������ � �������� ������.|",
                                                   "�� ����� ����� ���������, �� ������� ����� �����.| �����",
                                                   "����� ������� �������� ������ ���������� - ��� ������������ �������� � �����������. | Some",
                                                   "� �� ���� ����� ������� ����� ������� 3 ������� �����, �� 4 ����� ������� � �������" };

            var rightStrList = new List<string>() { "Do not leave the room, don't make a mistake.",
                                                    "come out and make a mistake.",
                                                    "I don't know what weapons world war 3 will",
                                                    "The most weighty argument against democracy is a five-minute conversation with a voter. | Some",
                                                    "You have to fight for life, you can die for beautyM.| Ta" };

            var correctMatches = new Dictionary<string, List<string>>() { { "�� ������ �� �������, �� �������� ������.", new List<string>() { "Do not leave the room, don't make a mistake.", "I don't know what weapons world war 3 will" } },
                                                                  { "������ � �������� ������.|", new List<string>() },
                                                                  { "�� ����� ����� ���������, �� ������� ����� �����.| �����", new List<string>() { "You have to fight for life, you can die for beautyM.| Ta" } },
                                                                  { "����� ������� �������� ������ ���������� - ��� ������������ �������� � �����������. | Some", new List<string>() },
                                                                  { "� �� ���� ����� ������� ����� ������� 3 ������� �����, �� 4 ����� ������� � �������", new List<string>() }
            };

            var answer = true;
            var result = PetrenkoGoltsmanAlgorithm.CompareIndexes(leftStrList, rightStrList).Result;

            Assert.AreEqual(result.All(n => correctMatches.Any(t => t.Value.SequenceEqual(n.Value))), answer);
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
            var firstStr = "�� ������ �� �������, �� �������� ������.";
            var secondStr = "Do not leave the room, don't make a mistake.";
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(firstStr, secondStr), answer);
        }

        [TestMethod]
        public void TestCompareIndexes_String_WithComments()
        {
            var firstStr = "�� ������ �� �������, �� �������� ������. | fgewe";
            var secondStr = "Do not leave the room, don't make a mistake.|ge";
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(firstStr, secondStr), answer);
        }

        [TestMethod]
        public void TestCompareIndexes_String_WithEmptyComments()
        {
            var firstStr = "�� ������ �� �������, �� �������� ������.|";
            var secondStr = "Do not leave the room, don't make a mistake.";
            var answer = true;

            Assert.AreEqual(PetrenkoGoltsmanAlgorithm.CompareIndexes(firstStr, secondStr), answer);
        }
    }
}