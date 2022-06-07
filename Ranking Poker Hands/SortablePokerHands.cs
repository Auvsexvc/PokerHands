using NUnit.Framework;

namespace Ranking_Sortable_Poker_Hands
{
    [TestFixture]
    public class SortablePokerTests
    {
        private readonly List<string> _hands = new()
        {
                "JH AH TH KH QH", // royal flush
                "JH 9H TH KH QH", // straight flush
                "5C 6C 3C 7C 4C", // straight flush
                "2D 6D 3D 4D 5D", // straight flush
                "2C 3C AC 4C 5C", // straight flush
                "JC KH JS JD JH", // 4 of a kind
                "JC 7H JS JD JH", // 4 of a kind
                "JC 6H JS JD JH", // 4 of a kind
                "KH KC 3S 3H 3D", // full house
                "2H 2C 3S 3H 3D", // full house
                "3D 2H 3H 2C 2D", // full house
                "JH 8H AH KH QH", // flush
                "4C 5C 9C 8C KC", // flush
                "3S 8S 9S 5S KS", // flush
                "8C 9C 5C 3C TC", // flush
                "QC KH TS JS AH", // straight
                "JS QS 9H TS KH", // straight
                "6S 8S 7S 5H 9H", // straight
                "3C 5C 4C 2C 6H", // straight
                "2C 3H AS 4S 5H", // straight
                "AC KH QH AH AS", // 3 of a kind
                "7C 7S KH 2H 7H", // 3 of a kind
                "7C 7S 3S 7H 5S", // 3 of a kind
                "AS 3C KH AD KC", // 2 pairs
                "3C KH 5D 5S KC", // 2 pairs
                "5S 5D 2C KH KC", // 2 pairs
                "3H 4C 4H 3S 2H", // 2 pairs
                "AH 8S AH KC JH", // pair
                "KD 4S KD 3H 8S", // pair
                "KC 4H KS 2H 8D", // pair
                "QH 8H KD JH 8S", // pair
                "8C 4S KH JS 4D", // pair
                "KS 8D 4D 9S 4S", // pair
                "KD 6S 9D TH AD",
                "TS KS 5S 9S AC",
                "JH 8S TH AH QH",
                "TC 8C 2S JH 6C",
                "2D 6D 9D TH 7D",
                "9D 8H 2C 6S 7H",
                "4S 3H 2C 7S 5H" };

        [Test]
        public void PokerHandSortTest()
        {
            var expected = new List<PokerHand> {
            new PokerHand("KS AS TS QS JS"),
            new PokerHand("2H 3H 4H 5H 6H"),
            new PokerHand("AS AD AC AH JD"),
            new PokerHand("JS JD JC JH 3D"),
            new PokerHand("2S AH 2H AS AC"),
            new PokerHand("AS 3S 4S 8S 2S"),
            new PokerHand("2H 3H 5H 6H 7H"),
            new PokerHand("2S 3H 4H 5S 6C"),
            new PokerHand("2D AC 3H 4H 5S"),
            new PokerHand("AH AC 5H 6H AS"),
            new PokerHand("2S 2H 4H 5S 4C"),
            new PokerHand("AH AC 5H 6H 7S"),
            new PokerHand("AH AC 4H 6H 7S"),
            new PokerHand("2S AH 4H 5S KC"),
            new PokerHand("2S 3H 6H 7S 9C")
        };
            var random = new Random((int)DateTime.Now.Ticks);
            var actual = expected.OrderBy(_ => random.Next()).ToList();
            actual.Sort();
            for (var i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i], "Unexpected sorting order at index {0}", i);
        }

        [Test]
        public void RandomizedTest()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var expected = _hands.ConvertAll(x => new PokerHand(x));
            for (var i = 0; i < 25000; i++)
            {
                var actual = expected.OrderBy(_ => random.Next()).ToList();
                actual.Sort();
                for (var j = 0; j < expected.Count; j++)
                    Assert.AreEqual(expected[j], actual[j], "Unexpected sorting order found at index {0}", j);
            }
        }
    }
}