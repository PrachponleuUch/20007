using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class BlackJackGame: Game
    {
        public void Play()
        {


            while (true)
            {



                bool dealer = true;

                Deck deck = new Deck();
                deck.shuffle();

                Hand player_hand = new BlackJackHand();
                Hand dealer_hand = new BlackJackHand(dealer);

                for (int i = 0; i < 2; i++)
                {
                    player_hand.AddCard(deck.Deal());
                    dealer_hand.AddCard(deck.Deal());
                }

                Console.WriteLine("-----------------------------------------------------------------------------------------");

                player_hand.display(true);
                dealer_hand.display();



                if (this.check_winner(player_hand, dealer_hand))
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



                string user_input = "";



                string[] choice1 = { "stand" };
                string[] choice2 = { "stand", "hit" };
                string[] choice3 = { "hit" };

                while (player_hand.getValue() < 21 && !(choice1.Contains(user_input.ToLower())))
                {
                    Console.WriteLine("Please choose hit or stand: ");
                    user_input = Console.ReadLine();
                    while (!(choice2.Contains(user_input.ToLower())))
                    {
                        Console.WriteLine("Please choose hit or stand: ");
                        user_input = Console.ReadLine();
                    }
                    if ((choice3.Contains(user_input.ToLower())))
                    {
                        player_hand.AddCard(deck.Deal());
                        player_hand.display(true);
                    }
                }

                if (this.check_winner(player_hand, dealer_hand))
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

                int player_hand_value = player_hand.getValue();
                int dealer_hand_value = dealer_hand.getValue();

                while (dealer_hand_value < 17)
                {
                    dealer_hand.AddCard(deck.Deal());
                    dealer_hand_value = dealer_hand.getValue();
                }

                dealer_hand.display(true);

                if (this.check_winner(player_hand, dealer_hand))
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

                Console.WriteLine($"\nFinal Results\nYour hand: {player_hand_value}\nDealer's hand: {dealer_hand_value}");

                this.check_winner(player_hand, dealer_hand, true);
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

        public bool check_winner(Hand player_hand, Hand dealer_hand, bool gameover = false)
        {
            if (!gameover)
            {
                if (player_hand.getValue() > 21)
                {
                    Console.WriteLine("\nYou lose.");
                    return true;
                }
                else if (dealer_hand.getValue() > 21)
                {
                    Console.WriteLine("\nYou win.");
                    return true;
                }
                else if (dealer_hand.has_won() && player_hand.has_won())
                {
                    Console.WriteLine("\nTie.");
                    return true;
                }
                else if (dealer_hand.has_won())
                {
                    Console.WriteLine("\nYou lose.");
                    return true;
                }
                else if (player_hand.has_won())
                {
                    Console.WriteLine("\nYou win.");
                    return true;
                }
            }
            else
            {
                if (player_hand.getValue() > dealer_hand.getValue())
                {
                    Console.WriteLine("\nYou win.");
                }
                else if (player_hand.getValue() == dealer_hand.getValue())
                {
                    Console.WriteLine("\nTie.");
                }
                else
                {
                    Console.WriteLine("\nYou lose.");
                }
            }

            return false;
        }


        public bool Quit()
        {
            string user_input = "";
            Console.WriteLine("Enter 'quit' to quit BlackJack or Press 'enter' to continue: ");
            user_input = Console.ReadLine().ToLower();
            if (user_input == "quit")
            {
                return true;
            }
            return false;
        }

    }
}
