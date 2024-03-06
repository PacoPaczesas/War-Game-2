using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game_2.Models
{
    internal class Player
    {
        private List<Card> _hand = new List<Card>();

        public void ReceiveCard(Card card)
        {
            _hand.Add(card);
        }

        public Card SendCard()
        {
            Card c = null;
            c = _hand[0];
            _hand.RemoveAt(0);
            return c;
        }

        public bool readyCheck()
        {
            bool readyCheck = true;
            if (_hand.Count < 1)
            {
                readyCheck = false;
            }
            return readyCheck;
        }
        public bool IsReady()
            => _hand.Count > 0;


        public void CardLeft()
        {
            Console.WriteLine(_hand.Count());
        }




    }




}
