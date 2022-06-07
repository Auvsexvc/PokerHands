namespace Ranking_Sortable_Poker_Hands
{
    public class Card
    {
        private readonly List<string> suits = new() { "C", "D", "H", "S" };

        private readonly Dictionary<string, int> ranksAndValues = new()
                { { "A", 14 },{ "2", 2 },{ "3", 3 },{ "4", 4 },{ "5", 5 },{ "6", 6 },{ "7", 7 },{ "8", 8 },{ "9", 9 },{ "T", 10 },{ "J", 11 },{ "Q", 12 },{ "K", 13 } };

        public string Suit { get; set; }
        public int Value { get; set; }

        public Card(string cardName)
        {
            Suit = suits.Find(s => s == cardName[1].ToString());
            Value = ranksAndValues.FirstOrDefault(s => s.Key == cardName[0].ToString()).Value;
        }
    }
}