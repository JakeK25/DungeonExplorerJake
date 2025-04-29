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
}