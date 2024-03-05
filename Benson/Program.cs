using System;
using System.Diagnostics.Contracts;
using System.Linq;

class Program
{
    static Player player;
    static Location currentLocation;
    static bool inBattle = false;

    static void Main()
    {
        InitializeGame();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.BackgroundColor = ConsoleColor.Black;
        GameLoop();
    }

    static void InitializeGame()
    {
        World.PopulateWeapons();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateLocations();
        player = new Player(100, 10);
        currentLocation = World.LocationByID(World.LOCATION_ID_HOME);
    }

    static void GameLoop()
    {
        Utils.Print($"Welcome to {currentLocation.Name}. ", 60);
        Utils.Print(currentLocation.Description, 50);

        while (true)
        {
            if (inBattle)
            {
                StartBattle();
                inBattle = false;
                continue;
            }

            Utils.Print("\n> What would you like to do? (Move/Inventory/Quit", 40);
            if (QuestAvailableAtLocation(currentLocation))
            {
                Utils.Print("/Accept Quest", 40);
            }
            Utils.Print(")", 40);
            Utils.Print("\n> ", 40);
            
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "QUIT")
            {
                Utils.Print("Goodbye", 60);
                break;
            }
            else if (userInput == "MOVE")
            {
                currentLocation = MoveToNewLocation(currentLocation);
                DisplayAvailableQuests(currentLocation);
            }
            else if (userInput == "ACCEPT QUEST")
            {
                AcceptQuest(currentLocation);
            }
            else if (userInput == "INVENTORY")
            {
                player.ShowInventory();
            }
            else
            {
                Utils.Print("Invalid command!", 70);
            }
        }
    }

    static Location MoveToNewLocation(Location currentLocation)
    {
        Utils.Print("> Where would you like to move? (North/East/South/West)\n\n", 40);
        Utils.Maplocation(currentLocation.ID, currentLocation.Name, true);
        string direction = Console.ReadLine().ToUpper();

        Location newLocation = null;

        switch (direction)
        {
            case "NORTH":
                newLocation = currentLocation.LocationToNorth;
                break;
            case "EAST":
                newLocation = currentLocation.LocationToEast;
                break;
            case "SOUTH":
                newLocation = currentLocation.LocationToSouth;
                break;
            case "WEST":
                newLocation = currentLocation.LocationToWest;
                break;
            default:
                Utils.Print("Invalid direction.", 70);
                break;
        }

        if (newLocation != null)
        {
            Utils.Print($"You moved to {newLocation.Name}. ", 50);
            Utils.Print(newLocation.Description, 60);
            return newLocation;
        }
        else
        {
            Utils.Print("There is no path in that direction.", 70);
            return currentLocation;
        }
    }

    static void DisplayAvailableQuests(Location location)
    {
        bool questsAvailable = false;

        foreach (Quest quest in World.Quests)
        {
            if (!quest.IsCompleted && quest.IsAvailableInLocation(location.ID))
            {
                if (!questsAvailable)
                {
                    Utils.Print($"\n\nQuests available in {location.Name}", 50);
                    questsAvailable = true;
                    Utils.Print($"\n- {quest.Name}: {quest.Description}", 50);
                }
            }
        }
    }

    static void AcceptQuest(Location location)
    {
        foreach (Quest quest in World.Quests)
        {
            if (!quest.IsCompleted && quest.IsAvailableInLocation(location.ID))
            {
                Utils.Print($"You accepted the quest: {quest.Name}.", 50);
                Utils.Print("Prepare for battle!", 50);
                inBattle = true;
                return;
            }
            else if (quest.IsCompleted && quest.IsAvailableInLocation(location.ID))
            {
                Utils.Print("You've already completed this quest.", 50);
                return;
            }
        }
    }

    static void StartBattle()
    {
        Monster monster = currentLocation.MonsterLivingHere;
        Weapon weapon = World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD); // Temporary weapon for now
        Battle battle = new Battle();
        battle.StartBattle(monster, weapon, player);
        
        // Check if the player won the battle
        if (player.HP > 0)
        {
            // Player wins, give a random item
            Random random = new Random();
            int itemType = random.Next(0, 2); // 0 for potion, 1 for weapon

            if (itemType == 0)
            {
                // Add a health potion to the player's inventory
                player.AddToInventory("Health Potion", 1);
                Utils.Print("You received a Health Potion as a reward!", 50);
            }
            else
            {
                // Add a random weapon to the player's inventory
                List<Weapon> availableWeapons = World.Weapons;
                Weapon randomWeapon = availableWeapons[random.Next(availableWeapons.Count)];
                player.AddToInventory(randomWeapon.Name, 0); // Adding to weapons category
                Utils.Print($"You received a {randomWeapon.Name} as a reward!", 50);
            }

            // Mark the quest as completed
            foreach (Quest quest in World.Quests)
            {
                if (quest.IsAvailableInLocation(currentLocation.ID))
                {
                    quest.IsCompleted = true;
                    break;
                }
            }
        }
        else
        {
            Utils.Print("You were defeated...", 50);
        }
    }

    static bool QuestAvailableAtLocation(Location location)
    {
        foreach (Quest quest in World.Quests)
        {
            if (!quest.IsCompleted && quest.IsAvailableInLocation(location.ID))
            {
                return true;
            }
        }
        return false;
    }
}
