using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD203_UfukTuncer_Shadow_Quest
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Adventure Game!");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Credits");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Game game = new Game();
                        game.Start();
                        break;
                    case "2":
                        ShowCredits();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("Game developed by Your Name");
            Console.WriteLine("Special thanks to: ...");
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
    }

    class Game
    {
        private Player player;
        private Dictionary<string, Location> locations;

        public Game()
        {
            player = new Player();
            locations = new Dictionary<string, Location>
        {
            { "Forest", new Location("Forest", "A dark, eerie forest with strange noises.") },
            { "Cave", new Location("Cave", "A cold, damp cave. Something glows inside.") },
            { "Village", new Location("Village", "A small village with friendly people.") }
        };
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Current Location: " + player.CurrentLocation);
                Console.WriteLine(locations[player.CurrentLocation].Description);
                Console.WriteLine("Where do you want to go? (Forest, Cave, Village, Quit)");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();
                if (choice.ToLower() == "quit") return;

                if (locations.ContainsKey(choice))
                {
                    player.CurrentLocation = choice;
                }
                else
                {
                    Console.WriteLine("Invalid location! Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
    }

    class Location
    {
        public string Name { get; }
        public string Description { get; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    class Player
    {
        public string CurrentLocation { get; set; }

        public Player()
        {
            CurrentLocation = "Village";
        }
    }

}

