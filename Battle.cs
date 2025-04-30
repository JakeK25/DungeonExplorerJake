using System;

namespace DungeonExplorer
{
    public class BattleManager
    {
        private Creature player;
        public Creature enemy { get; private set; }



        public BattleManager(Creature _player, Creature _enemy)
        {
            this.player = _player;
            this.enemy = _enemy;
        }
        
        public void StartBattle()
        {
            if (enemy.IsAlive() == false)
            {
                Console.WriteLine("enemy already dead");
                return;
            }

            Console.Clear();
            Console.WriteLine("Battle Has Begun!");
            
            Console.ReadLine();
            
            Console.WriteLine($"Player's Health: {player.health}");
            Console.WriteLine($"Creature's Health: {enemy.health}");

            // Loop until either player or enemy is dead
            while (player.IsAlive() && enemy.IsAlive())
            {
                // Player's Turn
                Console.WriteLine("\nPlayer's Turn to strike!");
                // Player attacks enemy
                enemy.TakeDamage(((Player)player).AttackDamage);
            
                // Check if enemy is dead
                if (!enemy.IsAlive())
                {
                    Console.WriteLine("Congrats! You killed the enemy!");
                    break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                
                // Enemy's Turn
                Console.WriteLine("\nEnemy's Turn to strike! Be cautious!");
                // Enemy attacks player
                player.TakeDamage(((Creature)enemy).AttackDamage);
            
                // Check if player is dead
                if (!player.IsAlive())
                {
                    Console.WriteLine("You have died. Better luck next time...");
                    Console.WriteLine("Press any key to exit game...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                // Wait for player to press Enter before the next turn
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }

            // Battle ended, prompt the player to continue or end the game
            Console.WriteLine("\nBattle ended. Press Enter to return to the game.");
            Console.ReadLine();
        }
    }
}

