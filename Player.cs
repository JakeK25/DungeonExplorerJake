using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public interface IDamageable
    {
        void TakeDamage(int amount);
        bool IsAlive();
    }


    public class Player : Creature, IDamageable // Class constructor Player
    { 
        public int AttackDamage { get; set; }

        public void TakeDamage(int amount)
        {
            health -= amount;
            Console.WriteLine("The player took {amount} damage! \n Remaining Health: {health}");
            
        }
        public bool IsAlive()
        {
            if (health >= 1)
                return true;
            else
                return false;
        }


        public Room CurrentRoom;
        private readonly List<Item> inventory = new List<Item>();
        public int LevelNumber = 1;
        public string Name { get; private set; }



        public Player(int _health, int _maxHealth, int attackdamage) // Create health system and gather input from the user for username
        {
            health = _health;
            AttackDamage = attackdamage;
            maxHealth = maxHealth;
            
            inventory = new List<Item>();
            
            Console.WriteLine("What would you like your username to be?");
            var Name = Console.ReadLine();
            Console.WriteLine("Your username is: " + Name);
            
        }
        

        public void ShowHealth()
        {
            Console.WriteLine("Health is currently:" + health);
            Console.Read();
        }

        public void PickUpItem(Item item) // Pick-up item add to inventory
        {
            inventory.Add(item);
            InventoryContents();
            Console.Read();
        }

        public void InventoryContents()
        {
            Console.Write("Your current inventory is: "); // Display inventory to the user
            foreach (var i in inventory)
                Console.Write("" + i.name + " ");
            Console.Read();
        }

        public void MoveRoomChoice()
        {
            Console.WriteLine(
                "Which room would you like to enter? \n 1. Spiders Den (S) \n 2. Hornets Lair (H) \n 3. Crab Infested Lair (C) \n 4. Undead Pirate Cavern (U) \n 5. Navy Soldier's Armory (N) \n 6. Phantom's Graveyard (P) \n 7. BOSS ROOM! (B)");
            var userInput = Console.ReadLine();

            if (userInput == "1")
            {
                var spidersDen =
                    new Room(
                        "Spider's Den \n You walk into a large cave covered in cobwebs, and you feel a unnerving feeling...");
                this.CurrentRoom = spidersDen;
            }
            else if (userInput == "2")
            {
                var hornetsNest =
                    new Room(
                        "Hornet's Nest \n You walk into a large cave with honeycombed walls, the floor is sticky and you hear a buzzing noise in the distance...");
                this.CurrentRoom = hornetsNest;
            }
            else if (userInput == "3")
            {
                var crabLair =
                    new Room(
                        "Crab Infested Lair \n You walk into a cave with a thin layer of water along the floor and a scuttering sound in the distance...");
                this.CurrentRoom = crabLair;
            }
            else if (userInput == "4")
            {
                var pirateCavern =
                    new Room(
                        "Undead Pirate Cavern \n You walk into a cave scattered with pirates crawling along the floor with flesh missing from their bodies you immediately feel a sense of danger...");
                this.CurrentRoom = pirateCavern;
            }
            else if (userInput == "5")
            {
                var navyRoom =
                    new Room(
                        "Navy Soldier's Armory \n You are trespassing in a navy soldier armory with soldiers loitering and armoring up, they all turn to look at you in confusion...");
                this.CurrentRoom = navyRoom;
            }
            else if (userInput == "6")
            {
                var phantomRoom =
                    new Room(
                        "Phantom's Graveyard \n You walk into a gloomy graveyard, fog covers your sight and you hear shrieking in the distance... ");
                this.CurrentRoom = phantomRoom;
            }
            else if (userInput == "7")
            {
                var bossRoom = new Room("Boss Room \n Placeholder");
                this.CurrentRoom = bossRoom;
            }
            else
            {
                Console.WriteLine("Something went wrong... Please enter a number between 1 and 7...");
            }
        }
    }


    public abstract class Creature : IDamageable
    {
        
        public int maxHealth;
        public int health;
        public string Name { get; private set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }

        public Creature(string name, int health, int _maxHealth, int attackDamage)
        {
            Name = name;
            health = health;
            this.maxHealth = maxHealth;
            AttackDamage = attackDamage;
        }

        public Creature(string name, int health)
        {
            Name = name;
            health = health;
            maxHealth = health;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            Console.WriteLine($"Creature took {amount} damage, Remaining health {Health}");
        }
        
        public bool IsAlive()
        {
            if (health >= 1)
                return true;
            else
                return false;
        }
        public Creature()
        {
        }

        public virtual Creature DoMove(Creature c)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Boss : Creature
    {
        public Boss() : base("Boss", 500)
        {
        }
    }

    public class Hornet : Creature
    {
        public Hornet() : base("Hornet", 100)
        {
            Health = 100;
            AttackDamage = 10;
        }
    }

    public class Spider : Creature
    {
        public Spider() : base("Spider", 100)
        {

        }

        public override Creature DoMove(Creature c)
        {
            c.health -= 10;
            Console.WriteLine("The Spider struck you with a web, It dealt 10 damage!");
            return c;
        }
    }
}