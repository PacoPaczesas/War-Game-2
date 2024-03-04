using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game_2.Models
{
    internal class Card
    {
        public Card(string name, string suit, int value)
        {
            this.Name = name;
            this.Suit = suit; //TODO enum
            this.Value = value;
        }
        public string Name { get; init; }
        public int Value { get; init; }
        public string Suit { get; init; }


    }
}
