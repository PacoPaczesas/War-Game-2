using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game_2.Models
{
    internal class Deck
    {
        private List<Card> _deck = new List<Card>();

        public Deck()
        {
            _deck = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _deck.Add(new Card(suit, rank));
                }
            }

        }

        public void ShuffleDeck()
        {
            List<Card> tempDeck = new List<Card>();
            Random rng = new Random();

            while (_deck.Count > 0)
            {
                int n = rng.Next(0, _deck.Count);
                Card c = _deck[n];
                tempDeck.Add(c);
                _deck.RemoveAt(n);
            }
            _deck = tempDeck;
        }

        public void DealCards(Player player1, Player player2)
        {
            for (int i = 0; i < _deck.Count; i += 2)
            {
                player1.ReceiveCard(_deck[i]);
                player2.ReceiveCard(_deck[i + 1]);
            }
        }


    }
}



