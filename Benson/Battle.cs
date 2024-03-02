using System;

//battles class
public class Battle
{
    public void StartBattle(Monster monster, Weapon weapon, Player player)
    {
        Utils.Print($"You encounter a {monster.Name}!", 50);

        while (true)
        {
            Utils.Print("\n> What would you like to do? (Attack/Run)\n> ", 40);
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "RUN")
            {
                if (AttemptEscape())
                {
                    Utils.Print("You managed to escape!", 50);
                    return;
                }
                else
                {
                    Utils.Print("You failed to escape!", 50);
                }
            }
            else if (userInput == "ATTACK")
            {
                int playerDamage = player.Damage + weapon.Damage;
                int monsterDamage = monster.Damage;

                // Player attacks first
                monster.Health -= playerDamage;
                Utils.Print($"You dealt {playerDamage} damage to the {monster.Name}!", 50);

                if (monster.Health <= 0)
                {
                    Utils.Print($"You defeated the {monster.Name}!", 50);
                    return;
                }

                // Monster attacks
                player.HP -= monsterDamage;
                Utils.Print($"The {monster.Name} dealt {monsterDamage} damage to you!", 50);

                if (player.HP <= 0)
                {
                    Utils.Print($"You were defeated by the {monster.Name}!", 50);
                    return;
                }
            }
            else
            {
                Utils.Print("Invalid command!", 50);
            }
        }
    }

    private bool AttemptEscape()
    {
        Random random = new Random();
        return random.Next(0, 2) == 0; // 50% chance of success
    }
}
