using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public enum Suit
    {
        Spade,
        Diamond,
        Club,
        Heart
    };

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    };
    public class Card
    {

        private Suit _suit;
        private Rank _rank;
        private int _value;

        public Suit Suit{ get { return _suit; } }
        public Rank Rank { get { return _rank; } }
        public int Value { get { return _value; } set { _value = value; } }

        public Card(Suit suit, Rank rank) 
        { 
            _suit = suit;
            _rank = rank;
        }



        public string CardDesc()
        {
            return $"{_rank} of {_suit}";
        }

    }
}
