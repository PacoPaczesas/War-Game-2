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
            string[] name = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "As" };
            string[] suit = { " of Hearts", " of Diamonds", " of Clubs", " of Spades" };
            int[] value = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            int thisValue;
            string thisName;
            string thisSuit;


            for (int i = 0; i < 13; i++)
            {
                thisName = name[i];
                for (int j = 0; j < 4; j++)
                {
                    thisSuit = suit[j];
                    thisValue = i;
                    _deck.Add(new Card(thisName, thisSuit, thisValue));
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



