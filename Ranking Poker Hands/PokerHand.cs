namespace Ranking_Sortable_Poker_Hands
{
    public class PokerHand : IComparable<PokerHand>
    {
        private List<Card> handCards;
        private int rank;

        public int Rank => rank;

        public PokerHand(string hand)
        {
            handCards = HandBuilder(hand);
            SetTheRank();
        }

        public Result CompareWith(PokerHand hand)
        {
            if (CompareTo(hand) == -1)
                return Result.Win;
            if (CompareTo(hand) == 1)
                return Result.Loss;

            return Result.Tie;
        }

        public void SetTheRank()
        {
            rank = handCards.Select(c => c.Value).Sum();



            if (IsRoyalFlush()) rank += 1000000;
            else if (IsStraightFlush()) rank += 950000;
            else if (IsStraightFlushLow()) rank += 900000;
            else if (IsFourOfAKind()) rank += 800000;
            else if (IsFullHouse()) rank += 700000;
            else if (IsFlush()) rank += 600000;
            else if (IsStraight()) rank += 500000;
            else if (IsStraightLow()) rank += 400000;
            else if (IsThreeOfAKind()) rank += 300000;
            else if (IsTwoPairs()) rank += 200000;
            else if (IsPair()) rank += 100000 + 10 * (handCards.Select(c => c.Value).Sum() - handCards.Select(c => c.Value).Distinct().Sum());
            else
            {
                rank = 0;
                var tmp = handCards.OrderByDescending(c => c.Value).Select(c => c.Value).ToList();
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0) rank += tmp[i] * 5;
                    else
                        rank += tmp[i] * (6 - i) / ((tmp[i - 1] - tmp[i]) * i);
                }
            }
        }

        private List<Card> HandBuilder(string hand) =>
            hand.Split(" ").Select(c => new Card(c)).ToList();

        public bool IsPair() =>
            handCards.Select(c => c.Value).Distinct().Count() == handCards.Count() - 1
                && handCards.Select(c => c.Value).Distinct().Any(c => handCards.Where(d => d.Value == c).Count() == 2);

        public bool IsTwoPairs() =>
            handCards.Select(c => c.Value).Distinct().Count() == handCards.Count() - 2
                && handCards.Select(c => c.Value).Distinct().Any(c => handCards.Where(d => d.Value == c).Count() == 2);

        public bool IsThreeOfAKind() =>
            handCards.Select(c => c.Value).Distinct().Count() == handCards.Count() - 2
                && handCards.Select(c => c.Value).Distinct().Any(c => handCards.Where(d => d.Value == c).Count() == 3);

        public bool IsStraightLow() =>
            handCards.Select(c => c.Value).Distinct().Count() == handCards.Count()
                && handCards.Where(c => c.Value == 14).Count() == 1 && handCards.Where(c => c.Value != 14).Select(c => c.Value).Max() == 5 && handCards.Select(c => c.Value).Min() == 2;

        public bool IsStraight() =>
            handCards.Select(c => c.Value).Distinct().Count() == handCards.Count()
                && handCards.Select(c => c.Value).Max() - handCards.Select(c => c.Value).Min() == 4;

        public bool IsFlush() =>
            handCards.Select(c => c.Value).Distinct().Count() == handCards.Count()
            && handCards.Select(c => c.Suit).Distinct().Count() == 1;

        public bool IsFullHouse() =>
            handCards.Select(c => c.Value).Distinct().Count() == handCards.Count() - 3;

        public bool IsFourOfAKind() =>
            handCards.Distinct().Count() == handCards.Count() - 3
                && handCards.Select(c => c.Value).Distinct().Any(c => handCards.Where(d => d.Value == c).Count() == 4);

        public bool IsStraightFlushLow() =>
            handCards.Select(c => c.Suit).Distinct().Count() == 1
                && handCards.Where(c => c.Value == 14).Count() == 1 && handCards.Where(c => c.Value != 14).Select(c => c.Value).Max() == 5 && handCards.Select(c => c.Value).Min() == 2;

        public bool IsStraightFlush() =>
            handCards.Select(c => c.Value).Max() - handCards.Select(c => c.Value).Min() == 4
                && handCards.Select(c => c.Suit).Distinct().Count() == 1;

        public bool IsRoyalFlush() =>
            handCards.Select(c => c.Value).Sum() == 60
                && handCards.Select(c => c.Suit).Distinct().Count() == 1;

        public int CompareTo(PokerHand other)
        {
            if (Rank > other.Rank) return -1;
            if (Rank == other.Rank) return 0;
            return 1;
        }
    }
}