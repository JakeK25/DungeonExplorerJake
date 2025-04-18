using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Item // Class constructor item, creating the item for the user to pick-up
    {
        public string desc;
        public string name;

        public Item(string _name, string _desc)
        {
            name = _name;
            desc = _desc;
        }
    }
    public class Player                                   // Class constructor Player
    { 
        public void MoveRoomChoice()
        {
            Console.WriteLine(
                "Which room would you like to enter? \n 1. Spiders Den (S) \n 2. Hornets Lair (H) \n 3. Crab Infested Lair (C) \n 4. Undead Pirate Cavern (U) \n 5. Navy Soldier's Armory (N) \n 6. Phantom's Graveyard (P) \n 7. BOSS ROOM! (B)");
            var userInput = Console.ReadLine();

            if (userInput == "1")
            {
                var spidersDen =
                    new Room("Spider's Den \n You walk into a large cave covered in cobwebs, and you feel a unnerving feeling...");
                this.CurrentRoom = spidersDen;
            }
            else if (userInput == "2")
            {
                var hornetsNest =
                    new Room("Hornet's Nest \n You walk into a large cave with honeycombed walls, the floor is sticky and you hear a buzzing noise in the distance...");
            }
            else if (userInput == "3")
            {
                var crabLair =
                    new Room("Crab Infested Lair \n You walk into a cave with a thin layer of water along the floor and a scuttering sound in the distance...");
            }
            else if (userInput == "4")
            {
                var pirateCavern =
                    new Room("Undead Pirate Cavern \n You walk into a cave scattered with pirates crawling along the floor with flesh missing from their bodies you immediately feel a sense of danger...");
            }
            else if (userInput == "5")
            {
                var navyRoom =
                    new Room("Navy Soldier's Armory \n You are trespassing in a navy soldier armory with soldiers loitering and armoring up, they all turn to look at you in confusion...");
            }
            else if (userInput == "6")
            {
                var phantomRoom =
                    new Room("Phantom's Graveyard \n You walk into a gloomy graveyard, fog covers your sight and you hear shrieking in the distance... ");
            }
            else if (userInput == "7")
            {
                var bossRoom = new Room("Boss Room \n Placeholder");
            }
            else
            {
                Console.WriteLine("Something went wrong... Please enter a number between 1 and 7...");
            }
        }
        
        
        public Room CurrentRoom;
        private readonly List<Item> inventory = new List<Item>();
        public int LevelNumber = 1;

        public Player(int health) // Create health system and gather input from the user for username
        {
            inventory = new List<Item>();
            Health = health;
            Console.WriteLine("What would you like your username to be?");
            var Name = Console.ReadLine();
            Console.WriteLine("Your username is: " + Name);
        }

        public string Name { get; private set; }
        public int Health { get; private set; }

        public void Damage(int damage)
        {
            Health = Health - damage;
        }

        public void ShowHealth()
        {
            Console.WriteLine("Health is currently:" + Health);
        }

        public void PickUpItem(Item item) // Pick-up item add to inventory
        {
            inventory.Add(item);
            InventoryContents();
        }

        public void InventoryContents()
        {
            Console.Write("Your current inventory is: "); // Display inventory to the user

            foreach (var i in inventory) Console.Write("" + i.name + " ");

            Console.Read();
        }

        public abstract class Creature
        {
            protected int health;
            protected string name;

            protected Creature(string _name, int _health)
            {
                name = _name;
                health = _health;
            }
        }

        public class Monster : Creature
        {
            public Monster() : base("Monster", 500)
            {
            }
        }

        public class Boss : Creature
        {
            public Boss() : base("Boss", 1500)
            {
            }
        }
    }
}