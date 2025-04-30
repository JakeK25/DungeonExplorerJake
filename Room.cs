using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room

    {
        public static bool bossDefeated = false;
        private List<Item> itemChoices;
        private bool hasBeenSearched = false;

        public Room(string _description, Item item1, Item item2)
        {
            description = _description;
            itemChoices = new List<Item> { item1, item2 };
        }

        public virtual void OnPlayerEnter(Player player)
        {
            Console.WriteLine(description);
            hasBeenSearched = false;
        }

        public void SearchingRoom(Player player)
        {
            if (hasBeenSearched)
            {
                Console.WriteLine("You've already searched this room, there's no items left to find in this room...");
                return;
            }

            Console.WriteLine("You search this room and find two items, however you are only able to carry one with you...");
            for (int i = 0; i < itemChoices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {itemChoices[i].name} - {itemChoices[i].desc}");
            }
            
            Console.Write("Choose an item to pick up (1 or 2):");
            int choice = -1;
            while (choice < 1 || choice > 2)
            {
                int.TryParse(Console.ReadLine(), out choice);
            }
            
            var selectedItem = itemChoices[choice - 1];
            player.PickUpItem(selectedItem);
            hasBeenSearched = true;
        }

        public string GetItemDescription()
        {
            return description;
        }

        public static Item noteBottle = new Item("Note in a Bottle", "A small bottle with a note inside lost from an old pirate legend");
        public static Item seaShell = new Item("Sea Shell", "Small glistening seashell found along the beach, a beautiful gift for someone you care for");
        
        public static Item spiderVenom = new Item("spiderVenom", "Small vile of spiders venom collected directly from its' fangs");
        public static Item spiderFang = new Item("Spiders' Fang", "Razor sharp fang gathered from a dead spider");

        public static Item honeyJar = new Item("Honey Jar", "Jar full of delicious Honey");
        public static Item hornetStinger = new Item("Hornet Stinger", "Sharp stingers gathered from a dead hornet");

        public static Item crabSticks = new Item("Crab Sticks", "Delicious Crab Sticks ready to eat");
        public static Item crabShell = new Item("Crab Shell", "Solid Crab shell used for protection from any harm thrown your way");

        public static Item pirateHat = new Item("Pirate Hat", "Legendary Pirate hat to make you look awesome");
        public static Item treasureMap = new Item("Treasure Map", "Treasure Map for the lost treasures of the black pearl");

        public static Item navyBadge = new Item("Navy Badge", "Badge given to only the most prestigious soldiers for the Navy");
        public static Item navyBackstaff = new Item("Navy Backstaff", "Backstaff to guide the Navy soldiers through the seven seas");

        public static Item phantomDust = new Item("Phantom Dust", "Small vile of dust left by the phantoms, this is incredibly rare among collectors");
        public static Item phantomCloak = new Item("Phantom Cloak", "Cloak that pirates gathered from the phantoms to allow them to become invisible");

        public static Item captainHook = new Item("Captains' Hook", "The hook gathered from killing the pirate captain, whoever carries this is a legend of the seas");
        public static Item goldenGlass = new Item("Golden Glass", "Golden glass gathered from the Pirate Captains' boat, used for drinking only the finest of rum");

        public static Room spidersDen =
            new Room(
                "Spider's Den \n You walk into a large cave covered in cobwebs, and you feel a unnerving feeling...",
                spiderVenom,
                spiderFang
                );

        public static Room hornetsNest =
                new Room("Hornet's Nest \n You walk into a large cave with honeycombed walls, the floor is sticky and you hear a buzzing noise in the distance...",
                    honeyJar,
                    hornetStinger);

        public static Room crabLair =
            new Room(
                "Crab Infested Lair \n You walk into a cave with a thin layer of water along the floor and a scuttering sound in the distance...",
                crabSticks,
                crabShell);

        public static Room pirateCavern =
            new Room(
                "Undead Pirate Cavern \n You walk into a cave scattered with pirates crawling along the floor with flesh missing from their bodies you immediately feel a sense of danger...",
                pirateHat,
                treasureMap);

        public static Room navyRoom =
            new Room(
                "Navy Soldier's Armory \n You are trespassing in a navy soldier armory with soldiers loitering and armoring up, they all turn to look at you in confusion...",
                navyBadge,
                navyBackstaff);

        public static Room phantomRoom =
            new Room(
                "Phantom's Graveyard \n You walk into a gloomy graveyard, fog covers your sight and you hear shrieking in the distance... ",
                phantomDust,
                phantomCloak);

        public static Room bossRoom =
            new Room(
                "Pirate Captain Room \n You walk into a huge cavern with a huge pirate ship on a large lake spanning the room. And a large gold chest within the middle of the ship",
                captainHook,
                goldenGlass);
        
        public string description { get; private set; }

        public string GetDescription()
        {
            return description;
        } // Encapsulate room description 
    }

    public class Game_Map
    {
        private readonly int height;
        private readonly char[,] map;
        private readonly int width;

        public Game_Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            map = new char[width, height];

            for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
                map[x, y] = '.';

            SetMapChar(13, 0, '\u2693'); // Displays start of map

            // Map Paths

            SetMapChar(12, 0, '\u2199'); // SW           
            SetMapChar(13, 1, '\u2193'); // S
            SetMapChar(11, 1, '\u2199'); // SW
            SetMapChar(13, 2, '\u2193'); // S
            SetMapChar(11, 9, '\u2199'); // SW
            SetMapChar(10, 9, '\u2190'); // W
            SetMapChar(12, 5, '\u2193'); // S
            SetMapChar(12, 6, '\u2193'); // S
            SetMapChar(9, 9, '\u2190'); // W
            SetMapChar(8, 9, '\u2190'); // W
            SetMapChar(7, 9, '\u2190'); // W
            SetMapChar(5, 9, '\u2190'); // W
            SetMapChar(4, 9, '\u2190'); // W
            SetMapChar(3, 9, '\u2190'); // W
            SetMapChar(2, 9, '\u2190'); // W
            SetMapChar(8, 2, '\u2190'); // W
            SetMapChar(7, 2, '\u2190'); // W
            SetMapChar(4, 3, '\u2199'); // SW
            SetMapChar(3, 4, '\u2199'); // SW
            SetMapChar(1, 6, '\u2193'); // S
            SetMapChar(1, 7, '\u2193'); // S

            // Room Icons

            SetMapChar(10, 1, 'S'); // Displays Spiders room
            SetMapChar(10, 2, 'S');
            SetMapChar(9, 1, 'S');
            SetMapChar(9, 2, 'S');
            SetMapChar(13, 3, 'H'); // Displays Hornets room
            SetMapChar(13, 4, 'H');
            SetMapChar(12, 3, 'H');
            SetMapChar(12, 4, 'H');
            SetMapChar(12, 7, 'U'); // Displays Undead pirates room
            SetMapChar(12, 8, 'U');
            SetMapChar(13, 7, 'U');
            SetMapChar(13, 8, 'U');
            SetMapChar(6, 9, 'P'); // Displays Phantoms room
            SetMapChar(5, 9, 'P');
            SetMapChar(6, 8, 'P');
            SetMapChar(5, 8, 'P');
            SetMapChar(6, 2, 'C'); // Displays Crab infested room
            SetMapChar(5, 2, 'C');
            SetMapChar(6, 1, 'C');
            SetMapChar(5, 1, 'C');
            SetMapChar(2, 4, 'N'); // Undead Navy soldier room
            SetMapChar(1, 4, 'N');
            SetMapChar(2, 5, 'N');
            SetMapChar(1, 5, 'N');
            SetMapChar(0, 9, 'B'); // Displays final boss battle (End of Map)
            SetMapChar(1, 9, 'B');
            SetMapChar(0, 8, 'B');
            SetMapChar(1, 8, 'B');
        }

        private void SetMapChar(int x, int y, char character)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
                map[x, y] = character;
            else
                Console.WriteLine("Invalid Character");
        }

        public void DisplayMap()
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++) Console.Write(map[x, y] + " ");
                Console.WriteLine();
            }

            Console.WriteLine("enter to continue");
            Console.Read();
        }
    }
}