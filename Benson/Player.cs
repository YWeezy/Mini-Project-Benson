using System;
using System.Collections.Generic;

public class Player
{
    public int HP { get; set; }
    public int Damage { get; set; }
    public List<List<string>> Inventory { get; private set; }

    public Player(int hp, int damage)
    {
        HP = hp;
        Damage = damage;
        Inventory = new List<List<string>>()
        {
            new List<string>(), // Weapons
            new List<string>(), // Potions
            new List<string>()  // Extra
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
            Utils.Print("Invalid category index.", 70);
        }
    }

    public void ShowInventory()
    {
        Utils.Print("Inventory:", 70);
        for (int i = 0; i < Inventory.Count; i++)
        {
            Utils.Print($"Category {i}:", 70);
            foreach (string item in Inventory[i])
            {
                Utils.Print(item, 70);
            }
        }
    }
}
