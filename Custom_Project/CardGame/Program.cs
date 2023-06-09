using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game;
            string user_input = "";
            int[] choices = { 1, 2 };
            int choice = 0;
            while (user_input != "exit")
            {

                while (!(choices.Contains(choice)))
                {
                    Console.WriteLine("Game Choices:\n1. BlackJack\n2. Baccarat\nPlease choose (1 or 2): ");

                    choice = Convert.ToInt32(Console.ReadLine());
                }
                game = GameFactory.GetGame(choice);
                game.Play();
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Enter 'exit' to exit the program or Press 'enter' to continue: ");
                user_input = Console.ReadLine().ToLower();
                choice = 0;
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("\nThank you for playing");
        }
    }
}
