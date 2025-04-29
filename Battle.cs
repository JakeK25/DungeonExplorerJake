using System;

namespace DungeonExplorer
{
    public class BattleManager
    {
        private IDamageable player;
        private IDamageable enemy;

        public BattleManager(IDamageable player, IDamageable enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("Battle Has Begun!");

            Console.WriteLine("Player's Health: {player.health}");
            Console.WriteLine("Creature's Health: {enemy.health}");

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

                // Enemy's Turn
                Console.WriteLine("\nEnemy's Turn to strike! Be cautious!");
                // Enemy attacks player
                player.TakeDamage(((Creature)enemy).AttackDamage);
            
                // Check if player is dead
                if (!player.IsAlive())
                {
                    Console.WriteLine("You have died. Better luck next time...");
                    break;
                }

                // Wait for player to press Enter before the next turn
                Console.WriteLine("\nPress Enter to continue to the next round...");
                Console.ReadLine();
            }

            // Battle ended, prompt the player to continue or end the game
            Console.WriteLine("\nBattle ended. Press Enter to return to the game.");
            Console.ReadLine();
        }
    }
}

