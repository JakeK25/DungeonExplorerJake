using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

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
        private List<Item> inventory = new List<Item>();
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
            Console.WriteLine("Your current inventory is: "); // Display inventory to the user
            foreach (var i in inventory)
                Console.WriteLine("" + i.name + " ");
            Console.Read();
        }
        
        public void SortInventoryAlphabetically()
        {
            var sortedList = inventory.OrderBy(item => item.name).ToList();
            inventory = sortedList;
            Console.WriteLine("Inventory sorted alphabetically!");
        }

        // Example method to integrate sorting into the game loop
        public void ShowSortedInventory()
        {
            SortInventoryAlphabetically();
            InventoryContents();
        }

        public void MoveRoomChoice()
        {
            Console.WriteLine(
                "Which room would you like to enter? \n 1. Spiders Den (S) \n 2. Hornets Nest (H) \n 3. Crab Infested Lair (C) \n 4. Undead Pirate Cavern (U) \n 5. Navy Soldier's Armory (N) \n 6. Phantom's Graveyard (P) \n 7. BOSS ROOM! (B)");
            var userInput = Console.ReadLine();

            if (userInput == "1")
            {
                this.CurrentRoom = Room.spidersDen;
            }
            else if (userInput == "2")
            {
                this.CurrentRoom = Room.hornetsNest;
            }
            else if (userInput == "3")
            {
                this.CurrentRoom = Room.crabLair;
            }
            else if (userInput == "4")
            {
                this.CurrentRoom = Room.pirateCavern;
            }
            else if (userInput == "5")
            {
                this.CurrentRoom = Room.navyRoom;
            }
            else if (userInput == "6")
            {
                this.CurrentRoom = Room.phantomRoom;
            }
            else if (userInput == "7")
            {
                this.CurrentRoom = Room.bossRoom;

                if (Room.bossDefeated)
                {
                    Console.WriteLine("The Pirate Captain has already been defeated!");
                }
                else
                {
                    Console.WriteLine("The Pirate Captain has ambushed you");
                    BattleManager b = new BattleManager(Game.player, new PirateCaptain());
                    b.StartBattle();
                }
            }
            else
            {
                Console.WriteLine("Something went wrong... Please enter a number between 1 and 7...");
            }
            this.CurrentRoom.OnPlayerEnter(this);
        }
    }


    public abstract class Creature : IDamageable
    {
        
        public int maxHealth;
        public int health {get; set;}
        public string Name { get; private set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        
        public bool IsDead { get; private set; } = false;

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
            Console.WriteLine($"Creature took {amount} damage, Remaining health {health}");

            if (IsDead) return;
            
            health -= amount;
            Console.WriteLine($"Creature took {amount} damage, Remaining health {health}");

            if (health <= 0)
            {
                health = 0;
                IsDead = true;
                Console.WriteLine("Creature is defeated!");
            }
        }
        
        public bool IsAlive()
        {
            return !IsDead;
        }
        public Creature()
        {
        }
        public virtual Creature DoMove(Creature c)
        {
            throw new System.NotImplementedException();
        }
    }

    public class PirateCaptain : Creature
    {
        public PirateCaptain() : base("PirateCaptain", 200)
        {
            health = 200;
            AttackDamage = 20;
        }
    }
}