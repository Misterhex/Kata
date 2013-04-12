using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            // problem #1
            Console.WriteLine(PerfectSquare.IsSquare(1000000001));
            Console.WriteLine(PerfectSquare.IsSquare(100));
            Console.WriteLine(PerfectSquare.IsSquare(0));
            Console.WriteLine(PerfectSquare.IsSquare(1));
            Console.WriteLine(PerfectSquare.IsSquare(999));
            Console.WriteLine(PerfectSquare.IsSquare(1000005));
            Console.WriteLine();

            // problem #2
            TickerSearch tickerSearch = new TickerSearch();
            tickerSearch.PrepareDataStructure();
            Console.WriteLine(tickerSearch.Find("AAPL"));
            Console.WriteLine(tickerSearch.Find("MSFT"));
            Console.WriteLine(tickerSearch.Find("GOOG"));
            Console.WriteLine(tickerSearch.Find("YHOO"));
            Console.WriteLine(tickerSearch.Find("QQQQ"));
            Console.WriteLine();
            Console.WriteLine("Thanks!");

            Console.ReadLine();
        }

    }

    public class PerfectSquare
    {
        /// <summary>
        /// Question 1, check if N is perfect square.
        /// </summary>
        public static bool IsSquare(int n)
        {
            double r = Math.Sqrt(n);
            return (r % 1 == 0);
        }
    }

    public class TickerSearch
    {
        private static List<char> _capitalAlpabets = "abcdefghijklmnopqrstuvwxyz".ToUpper().ToCharArray().ToList();
        private string[, , ,] _array = new string[26, 26, 26, 26];

        public void PrepareDataStructure()
        {
            IEnumerable<string> randomTickers = GetRandomTickers();

            IEnumerable<string> addedTickers = new List<string>() { "AAPL", "MSFT", "GOOG", "YHOO", "QQQQ" };
            randomTickers = randomTickers.Concat(addedTickers);

            foreach (var ticker in randomTickers)
            {
                int pos1 = ticker.ElementAt(0) - 65;
                int pos2 = ticker.ElementAt(1) - 65;
                int pos3 = ticker.ElementAt(2) - 65;
                int pos4 = ticker.ElementAt(3) - 65;

                // use array to store ticker.
                _array[pos1, pos2, pos3, pos4] = ticker;
            };
        }

        public string Find(string ticker)
        {
            // query by array index position..
            string result =
                _array[
                ticker.ElementAt(0) - 65,
                ticker.ElementAt(1) - 65,
                ticker.ElementAt(2) - 65,
                ticker.ElementAt(3) - 65
                ];

            return result;
        }

        public IEnumerable<string> GetRandomTickers()
        {
            var random = new Random();
            foreach (var _ in Enumerable.Range(0, 1000000))
            {
                yield return string.Join("", _capitalAlpabets.ElementAt(random.Next(0, 26)),
                    _capitalAlpabets.ElementAt(random.Next(0, 26)),
                    _capitalAlpabets.ElementAt(random.Next(0, 26)),
                    _capitalAlpabets.ElementAt(random.Next(0, 26)));
            };
        }
    }

}
