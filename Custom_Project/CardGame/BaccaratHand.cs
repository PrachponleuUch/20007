using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class BaccaratHand: Hand
    {
        private Dictionary<Rank, int> _cardDict = new Dictionary<Rank, int>()
        {
            { Rank.Ace, 11 },
            { Rank.Two, 2 },
            { Rank.Three, 3 },
            { Rank.Four, 4 },
            { Rank.Five, 5 },
            { Rank.Six, 6 },
            { Rank.Seven, 7 },
            { Rank.Eight, 8 },
            { Rank.Nine, 9 },
            { Rank.Ten, 10 },
            { Rank.Jack, 10 },
            { Rank.Queen, 10 },
            { Rank.King, 10 },
        };
        public BaccaratHand() : this(false)
        {

        }

        public BaccaratHand(bool dealer) : base(dealer)
        {
            
        }

        
        
        public override void CalculateValue()
        {
            int handvalue = 0;
            
            foreach (Card card in this.Cards)
            {
                card.Value = _cardDict[card.Rank];
                handvalue += card.Value;
            }
            this.Value = handvalue;
        }

        public override int getValue()
        {
            this.CalculateValue();
            return this.Value % 10;
        }

        public override bool has_won()
        {
            if (this.getValue() == 8 || this.getValue() == 9)
                return true;
            return false;
        }

        public override void display(bool show_card = true)
        {
            if (this.Dealer)
            {
                Console.WriteLine($"\nDealer's hand:");
            }
            else
            {
                Console.WriteLine($"\nYour hand:");
            }

            foreach (Card card in this.Cards)
            {
                    Console.WriteLine($"{card.CardDesc()}");   
            }

            if (show_card)
            {
                Console.WriteLine($"Value: {this.getValue()}");
            }
        }
    }

}
