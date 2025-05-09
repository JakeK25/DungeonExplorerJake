﻿using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;

namespace DungeonExplorer
{
    internal class Game
    {
        public static Player player;
        private static Game_Map gameMap;

        public static void GameStart() // Initialize the game with one room and one player
        {
            gameMap = new Game_Map(15, 10);
            player = new Player(100, 100, 50);
            player.CurrentRoom = new Room(
                "Skulls shores \n The entrance to the island you notice two large caves in front of you and you are stood on a large sandy beach, the sun is blazing",
                Room.noteBottle,
                Room.seaShell);

            Console.WriteLine("Welcome to the Pirate Dungeon Explorer!");
            player.ShowHealth();
        }

        public static void StoryOpening()
        {
            Console.Clear();
            Console.WriteLine(
                "You have entered the island by ship, instantly you notice two large caves shaped like skulls"); // Start of Story or Map
            Console.WriteLine(
                "On the beach you notice two items glimmering in the distance so you walk over to take a look");
            Console.WriteLine(
                "...\n There is a cutlass there, or an old musket. which do you pick up (cutlass/musket)");
            var validInput = false;
            while (!validInput)
            {
                var input = Console.ReadLine(); // Input to decide players weapon
                if (input == "cutlass")
                {
                    player.PickUpItem(new Item("cutlass", "A pirates right hand man"));
                    validInput = true;
                }
                else if (input == "musket")
                {
                    player.PickUpItem(new Item("musket", "An old rusty musket, but it will get the job done"));
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input please enter cutlass/musket ...");
                }
            }
        }
        
        public static void Maingameloop()
        {
            var isPlaying = true;

            do
            {
                Console.Clear();
                
                Console.WriteLine("What would you like to do next...?:");

                Console.WriteLine("1. Move Room...");                                           // Main game loop user input
                Console.WriteLine("2. View Current Health");
                Console.WriteLine("3. View Inventory");
                Console.WriteLine("4. View Description of room");
                Console.WriteLine("5. View Map");
                Console.WriteLine("6. Keep Searching room");
                Console.WriteLine("7. Sort Inventory alphabetically");
                Console.WriteLine("8. Exit Game");
                Console.WriteLine("Enter your choice using 1 to 8:");

                var userInput = Console.ReadLine();

                if (userInput == "1")                                              // If loop to validate user input
                {
                    player.MoveRoomChoice();
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("You chose to View your current health"); // View Current health
                    player.ShowHealth();
                    Console.ReadLine();
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("You chose to view your inventory"); // View Inventory
                    player.InventoryContents();
                }
                else if (userInput == "4")
                {
                    Console.WriteLine("You chose to view the description of the room..." +
                                      player.CurrentRoom.GetDescription()); // Get description for room
                    Console.ReadLine();
                }
                else if (userInput == "5")
                {
                    Console.WriteLine("You chose to view the map"); // Display Map Option
                    Console.WriteLine(" S = Spiders Den \n H = Hornets Nest \n C = Crab Infested Lair \n U = Undead Pirate Cavern \n P = Phantom Graveyard \n N = Navy Armory \n B = Secret Boss Room...");
                    gameMap.DisplayMap();
                }
                else if (userInput == "6")
                {
                    if (player.CurrentRoom != null)
                    {
                        player.CurrentRoom.SearchingRoom(player);
                    }
                    else
                    {
                        Console.WriteLine("You are not in a room");
                    }

                    Console.ReadLine();
                }
               
                else if (userInput == "7")
                {
                    Console.WriteLine("You chose to sort your inventory...");
                    player.ShowSortedInventory();
                    Console.ReadLine();
                }
                
                else if (userInput == "8")
                {
                    Console.WriteLine("You chose to Exit the game"); // Option to exit the game and terminate the console
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Choice, choose a number between 1 and 8");
                    Console.ReadLine(); // Exception handling to ensure user input is correct
                }
            } while (isPlaying);
        }
    }
}