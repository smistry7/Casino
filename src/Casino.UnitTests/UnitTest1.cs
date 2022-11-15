using Casino.Domain;

namespace Casino.UnitTests
{
    public class DeckTests
    {
        [Fact]
        public void Poker()
        {
            var deck = new Deck();
            var hand1 = deck.Shuffle().Deal(2);
            var hand2 = deck.Shuffle().Deal(2);

            var board = deck.Discard().Deal(3).ToList();
            board.AddRange( deck.Discard().Deal(1));

            board.AddRange(deck.Discard().Deal(1));


        }
    }
}