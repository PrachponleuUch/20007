using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();
        private Random _random = new Random();
        

        public Deck()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _cards.Add(new Card((Suit)j, (Rank)i));
                }
            }
        }

        public void shuffle()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        public Card Deal()
        {
            Card _card;         
            _card = _cards[0];
            _cards.Remove(_cards[0]);
            return _card;
        }
    }
}
