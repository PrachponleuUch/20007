using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class BlackJackHand: Hand
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

        public BlackJackHand() : base(false)
        {

        }

        public BlackJackHand(bool dealer): base(dealer)
        {
            
        }

        


        public override void CalculateValue()
        {
            int handvalue = 0;
            
            foreach (Card card in this.Cards)
            {
                card.Value = _cardDict[card.Rank];

                handvalue += card.Value;

                if (card.Rank == Rank.Ace && handvalue > 21)
                {
                    handvalue -= 10;
                }
            }
            this.Value = handvalue;
        }

        

        public override bool has_won()
        {
            return this.getValue() == 21;
        }

        public override void display(bool show_hand = false)
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
                if (this.Dealer && !(show_hand) && !(this.has_won()))
                {
                    Console.WriteLine("HIDDEN");
                    Console.WriteLine($"{this.Cards[1].CardDesc()}");
                    break;
                }
                else
                {
                    Console.WriteLine($"{card.CardDesc()}");
                }
            }

            if (show_hand)
            {
                Console.WriteLine($"Value: {this.getValue()}");
            }
        }
    }
}
