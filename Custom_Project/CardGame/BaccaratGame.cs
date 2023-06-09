using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public enum Choice
    {
        Player,
        Dealer,
        Tie
    }
    public class BaccaratGame: Game
    {
        private Choice choice;
        public void Play()
        {
            while (true)
            {

                bool dealer = true;

                Deck deck = new Deck();
                deck.shuffle();

                List<Hand> hands = new List<Hand>() { new BaccaratHand() , new BaccaratHand(dealer) };
                Console.WriteLine("-----------------------------------------------------------------------------------------");

                string user_input = "";

                string[] choice1 = { "player", "dealer", "tie" };


                while (!(choice1.Contains(user_input.ToLower())))
                {
                    Console.WriteLine("Please choose player, dealer or tie: ");
                    user_input = Console.ReadLine();
                }

                if (user_input == "player")
                    choice = Choice.Player;
                else if (user_input == "dealer")
                    choice = Choice.Dealer;
                else
                    choice = Choice.Tie;

                foreach (Hand hand in hands)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        hand.AddCard(deck.Deal());
                    }
                    hand.display();
                }

                if (this.check_winner(hands[0], hands[1]))
                {
                    if (Quit())
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                foreach (Hand hand in hands)
                {
                    if ((hand.getValue() < 5))
                    {
                        hand.AddCard(deck.Deal());
                    }
                    hand.display();
                }

                Console.WriteLine($"\nFinal Results\nYour hand: {hands[0].getValue()}\nDealer's hand: {hands[1].getValue()}");

                if (this.check_winner(hands[0], hands[1], true))
                {
                    if (Quit())
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            
        }

        public bool check_winner(Hand player_hand, Hand dealer_hand, bool gameover = false)
        {
            
            if (!gameover)
            {
                switch (choice)
                {
                    case Choice.Player:
                        if (player_hand.has_won())
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        break;
                    case Choice.Dealer:
                        if (dealer_hand.has_won())
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        break;
                    case Choice.Tie:
                        if (player_hand.getValue() == dealer_hand.getValue())
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        break;
                }

                
            }
            else
            {
                switch (choice)
                {
                    case Choice.Player:
                        if (player_hand.has_won())
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        else if (player_hand.getValue() > dealer_hand.getValue() )
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("You lose");
                            return true;

                        }
                        
                    case Choice.Dealer:
                        if (dealer_hand.has_won())
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        else if (player_hand.getValue() < dealer_hand.getValue())
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("You lose");
                            return true;

                        }
                        
                    case Choice.Tie:
                        if (player_hand.getValue() == dealer_hand.getValue())
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("You lose");
                            return true;

                        }
                        
                }
                
            }

            return false;
        }

        public bool Quit()
        {
            string user_input = "";
            Console.WriteLine("Enter 'quit' to quit Baccarat or Press 'enter' to continue: ");
            user_input = Console.ReadLine().ToLower();
            if (user_input == "quit")
            {
                return true;
            }
            return false;
        }
    }
}
