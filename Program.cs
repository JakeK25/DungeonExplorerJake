namespace DungeonExplorer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Testing.RunTests();
            Game.GameStart();
            Game.StoryOpening();
            Game.Maingameloop();
        }
    }
}
