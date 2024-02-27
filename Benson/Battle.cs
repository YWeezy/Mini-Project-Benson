public class Battle
{
    public void StartBattle(Monster monster, Weapon weapon, Player player)
    {
        int turn = 0;
        do
        {
            Console.WriteLine($"You started a Quest. The moster is{monster.Name}");
            Console.WriteLine("Do you want to attack? (Y/N)");
            string choice = Console.ReadLine().Trim().ToUpper();
            if (choice == "Y")
            {
                if (turn % 2 == 0)
                {
                    monster.Health -= weapon.Damage;
                }

                else
                {
                    player.HP -= monster.Damage;
                }
            }
            else
            {
                break;
            }
            Console.WriteLine(turn % 2 == 0 ? $"The moster did {weapon.Damage} damage. The moster has {monster.Health} HP" : $"You did {monster.Damage} damage. You have {monster.Health} HP");

        } while (monster.Health <= 0 || player.HP <= 0);
    }

}