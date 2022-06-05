namespace Ranking_Sortable_Poker_Hands
{
    public class Card
    {
        private List<string> suits = new List<string>() { "C", "D", "H", "S" };

        private Dictionary<string, int> ranksAndValues = new Dictionary<string, int>()
                { { "A", 14 },{ "2", 2 },{ "3", 3 },{ "4", 4 },{ "5", 5 },{ "6", 6 },{ "7", 7 },{ "8", 8 },{ "9", 9 },{ "T", 10 },{ "J", 11 },{ "Q", 12 },{ "K", 13 } };

        public string Suit { get; set; }
        public int Value { get; set; }

        public Card(string cardName)
        {
            Suit = suits.Where(s => s == cardName[1].ToString()).FirstOrDefault();
            Value = ranksAndValues.Where(s => s.Key == cardName[0].ToString()).FirstOrDefault().Value;
        }
    }
}