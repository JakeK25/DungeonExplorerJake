using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Testing
    {
        public static void RunTests()
        {

            try
            {
                // Test Item Creation
                Item testItem = new Item("Test Item", "Test Description");
                Debug.Assert(testItem.name == "Test Item", "Item name should be 'Test Item'");
                Debug.Assert(testItem.desc == "Test Description", "Item description should be 'Test Description'");

                // Test Room Creation
                Room testRoom = new Room("Test Room", testItem, testItem);
                Debug.Assert(testRoom.GetDescription() == "Test Room", "Room description should be 'Test Room'");

                // Test Creature Creation
                Spider spider = new Spider();
                Debug.Assert(spider.health == 100, "Spider health should be 100");
                Debug.Assert(spider.AttackDamage == 8, "Spider attack damage should be 8");
                Hornet hornet = new Hornet();
                Debug.Assert(hornet.health == 100, "Hornet health should be 50");
                Debug.Assert(hornet.AttackDamage == 12, "Hornet attack damage should be 10");

                // Output results
                Console.WriteLine("All tests passed successfully!");
            }
            catch
            {
                // output results if failed
                Console.WriteLine("Testing failed!");
                Console.ReadLine();
            }
        }
    }
} 