public class Player
{
    public int HP = 100;
    public int Damage = 2;
    public List<List<string>> Inventory;

    public Player()
    {
        Inventory = new List<List<string>>()
        {
            new(), // Weapons
            new(), // Potions
            new()  // Extra
        };
    }

    public void AddToInventory(string item, int categoryIndex)
    {
        if (categoryIndex >= 0 && categoryIndex < Inventory.Count)
        {
            Inventory[categoryIndex].Add(item);
        }
        else
        {
            Console.WriteLine("Invalid category index.");
        }
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventory:");
        for (int i = 0; i < Inventory.Count; i++)
        {
            Console.WriteLine($"Category {i}:");
            foreach (string item in Inventory[i])
            {
                Console.WriteLine(item);
            }
        }
    }
}