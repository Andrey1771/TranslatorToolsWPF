using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetrenkoGoltsmanAlgorithmLibrary
{
    public static class PetrenkoGoltsmanAlgorithm
    {
        private const double startIndex = 0.5;
        private const int indexIncrease = 1;
        private const string textPattern = @"\w*";
        private const string commentPattern = @"([|]+.*)+";

        // TODO Переименовать?
        public static List<double> CalculateIndex(IEnumerable<string> strList)
        {
            var indexesList = new List<double>();
            foreach (var str in strList) // Может быть, имеет смысл разбить на несколько участков и потоков, соответственно?
            {
                indexesList.Add(Calculate(TakeSymbols(RemoveComments(str)).Length));
            }

            return indexesList;
        }

        public static double CalculateIndex(string str)
        {
            return Calculate(TakeSymbols(RemoveComments(str)).Length);
        }

        // TODO Переименовать
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

        public static bool CompareIndexes(string leftStr, string rightStr)
        {
            return CalculateIndex(leftStr).Equals(CalculateIndex(rightStr));
        }

        private static string RemoveComments(string str)
        {
            return Regex.Replace(str, commentPattern, string.Empty);
        }

        private static string TakeSymbols(string str)
        {
            return string.Concat(Regex.Matches(str, textPattern));
        }

        private static double Calculate(int stringLength)
        {
            // Sum of an arithmetic progression
            var sumOfIndexesSymbols = (2 * startIndex + indexIncrease * (stringLength - 1)) * stringLength / 2;

            return sumOfIndexesSymbols * stringLength;
        }

        private static Dictionary<string, List<string>> MatchStrings(IEnumerable<string> leftStrList, IEnumerable<string> rightStrList, IEnumerable<double> leftIndexesList, IEnumerable<double> rightIndexesList)
        {
            var matchedStrings = new Dictionary<string, List<string>>();
            var leftStrListEnumerator = leftStrList.GetEnumerator();
            var rightStrListEnumerator = rightStrList.GetEnumerator();
            foreach (var leftIndex in leftIndexesList) // TODO Improve O(n^2) (Есть подозрение, что алгоритм можно сделать лучше)
            {
                var items = new List<string>();
                leftStrListEnumerator.MoveNext();

                foreach (var rightIndex in rightIndexesList) // Может у Linq есть способ сделать лучше?
                {
                    rightStrListEnumerator.MoveNext();
                    if (leftIndex == rightIndex)
                        items.Add(rightStrListEnumerator.Current);

                }
                rightStrListEnumerator.Reset();
                matchedStrings.Add(leftStrListEnumerator.Current, items);
            }

            return matchedStrings;
        }
    }
}
