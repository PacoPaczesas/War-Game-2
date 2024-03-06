using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game_2.Models
{
    internal class Card
    {
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public Rank Rank { get; init; }
        public Suit Suit { get; init; }

        public int CompareCards(Card oppCard)
        {
            if (this.Rank > oppCard.Rank)
            {
                return 1;
            }
            if (this.Rank < oppCard.Rank)
            {
                return -1;
            }
            return 0;
        }
    }


    public enum Suit
    {
        Hearts,
        Diamonds,
 /*       Clubs,
        Spades*/
    }

    public enum Rank
    {
        Two = 2,
        Three,
        Four,
/*        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace*/
    }

}
