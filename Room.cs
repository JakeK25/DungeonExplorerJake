using System;

namespace DungeonExplorer
{
    public class Room

    {
        
        public static Room spidersDen =
            new Room(
                "Spider's Den \n You walk into a large cave covered in cobwebs, and you feel a unnerving feeling...");
        
        public static Room hornetsNest =
            new Room(
                "Hornet's Nest \n You walk into a large cave with honeycombed walls, the floor is sticky and you hear a buzzing noise in the distance...");
        
        public static Room crabLair =
            new Room(
                "Crab Infested Lair \n You walk into a cave with a thin layer of water along the floor and a scuttering sound in the distance...");
        
        public static Room pirateCavern =
            new Room(
                "Undead Pirate Cavern \n You walk into a cave scattered with pirates crawling along the floor with flesh missing from their bodies you immediately feel a sense of danger...");
        
        public static Room navyRoom =
            new Room(
                "Navy Soldier's Armory \n You are trespassing in a navy soldier armory with soldiers loitering and armoring up, they all turn to look at you in confusion...");
        
        public static Room phantomRoom =
            new Room(
                "Phantom's Graveyard \n You walk into a gloomy graveyard, fog covers your sight and you hear shrieking in the distance... ");
        
        public static Room bossRoom = 
            new Room(
                "Pirate Captain Room \n You walk into a huge cavern with a huge pirate ship on a large lake spanning the room. And a large gold chest within the middle of the ship");
            
        
        private readonly string description;

        public Room(string description)
        {
            this.description = description;
        }

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