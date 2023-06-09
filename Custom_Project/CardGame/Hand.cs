using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public abstract class Hand
    {
        private List<Card> _cards;
        private int _value = 0;
        private bool _dealer;


        public Hand(): this(false)
        {
            
        }

        public Hand(bool dealer)
        {
            _cards = new List<Card> { };
            _value = 0;
            _dealer = dealer;
        }

        protected List<Card> Cards { get { return _cards; } set { _cards = value; } }
        public int Value { get { return _value; } set { _value = value; } }
        public bool Dealer { get { return _dealer; } set { _dealer = value; } }

        public void AddCard(Card card)
        {
            
            _cards.Add(card);

        }

        public abstract void CalculateValue();
        

        public virtual int getValue()
        {
            this.CalculateValue();
            return this._value;
        }

        public abstract bool has_won();

        public abstract void display(bool show_card = false);
    }
}


