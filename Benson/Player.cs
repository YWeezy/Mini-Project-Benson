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
        Utils.Print("\nInventory:\n", 70);
        for (int i = 0; i < Inventory.Count; i++)
        {

            string categoryName = "";

            switch (i)
            {
                case 0:
                    categoryName = "Weapons";
                    break;

                case 1:
                    categoryName = "Potions";
                    break;

                case 2:
                    categoryName = "Extra";
                    break;
            }

            Utils.Print($"\n{categoryName}:\n", 70);

            if (Inventory[i].Count > 0) {

                foreach (string item in Inventory[i])
                {
                    Utils.Print($"{item}\n", 70);
                }

            } else {
                Utils.Print("None\n", 70);
            }

        }
    }
}
