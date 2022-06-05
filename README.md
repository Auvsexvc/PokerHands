# Ranking Poker Hands
Create a poker hand that has a method to compare itself to another poker hand:

Result PokerHand.CompareWith(PokerHand hand);

A poker hand has a constructor that accepts a string containing 5 cards:

PokerHand hand = new PokerHand("KS 2H 5C JD TD");

The characteristics of the string of cards are:
    Each card consists of two characters, where
    The first character is the value of the card: 2, 3, 4, 5, 6, 7, 8, 9, T(en), J(ack), Q(ueen), K(ing), A(ce)
    The second character represents the suit: S(pades), H(earts), D(iamonds), C(lubs)
    A space is used as card separator between cards
    
The result of your poker hand compare can be one of these 3 options:
public enum Result 
{ 
    Win, 
    Loss, 
    Tie 
}

AAAAAAANNNNNDDD!!!!!

The poker hands must be sortable by rank, the highest rank first:
var hands = new List<PokerHand> 
{ 
    new PokerHand("KS 2H 5C JD TD"),
    new PokerHand("2C 3C AC 4C 5C")
};
hands.Sort();


Notes
Apply the Texas Hold'em rules for ranking the cards.
Low aces are NOT valid in this kata.
There is no ranking for the suits.
