using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Swin_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name, desc;
            Console.WriteLine("Please enter player's name: ");
            name = Console.ReadLine();
            Console.WriteLine("Please enter player's description: ");
            desc = Console.ReadLine();
            Player player0 = new Player(name, desc);
            Item item0 = new Item(new string[] { "sword", "weapon" }, "An anti-matter sword", "A sword made from anti-matter.");
            Item item1 = new Item(new string[] { "glasses", "accessory" }, "An all seeing glasses", "Glasses can see through all living creature souls.");
            Bag bag0 = new Bag(new string[] { "bag" }, "A dimensional bag", "A bag that stores items in another dimension.");
            player0.Inventory.Put(item0);
            player0.Inventory.Put(item1);
            player0.Inventory.Put(bag0);
            Item item2 = new Item(new string[] { "ring", "accessory" }, "A ring", "A non-suspicious ring");
            bag0.Inventory.Put(item2);
            Location location = new Location(new string[] { "house" }, "a wooden house", "A house made of wood.");
            player0.Location = location;
            Location garden = new Location(new string[] { "garden" }, "a lovely garden", "Garden near a wooden house");
            Swin_Adventure.Path path = new Swin_Adventure.Path(new string[] { "north" }, "Door", "A test door", garden);
            location.AddPath(path);


            
            CommandProcessor commandProcessor = new CommandProcessor();



            while (true)
            {
                Console.Write("\nCommand ->  ");
                string player_input = Console.ReadLine();
                string[] input_array = player_input.Split();
                
                
                if (player_input.ToLower() == "quit")
                {
                    Console.WriteLine("Thank you for playing.");
                    break;
                }
                

                Console.WriteLine(commandProcessor.Execute(player0, input_array));

                
            }
            Console.ReadLine();
        }
    }
}
