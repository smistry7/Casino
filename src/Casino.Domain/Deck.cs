namespace Casino.Domain
{
    public static class CardReference
    {
        public static string[] Suits = new[] { "Clubs", "Hearts", "Diamonds", "Spades" };
        public static string[] Values = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    }
    public class Deck
    {
        private Stack<Card> _deck;

        public Deck()
        {
            Reset();
        }

        public Deck Shuffle()
        {
            var rnd = new Random();
            _deck = new Stack<Card>(_deck.OrderBy(x => rnd.Next()));
            return this;
        }


        public Deck Discard(int count = 1)
        {
            _deck.Pop();
            return this;
        }

        public IEnumerable<Card> Deal(int count = 1)
        {
            List<Card> cards = new List<Card>();
            for(int i = 0; i < count; i++)
            {
                cards.Add(_deck.Pop());
            }
            return cards;
        }


        private void Reset()
        {
            _deck = new Stack<Card>();
            foreach (var type in CardReference.Suits)
            {
                foreach (var card in CardReference.Values)
                {
                    _deck.Push(new Card(type, card));
                }
            }
        }
    }

    public record Card(string Suit, string Value)
    {
        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}