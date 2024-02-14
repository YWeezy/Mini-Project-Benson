class Program
{
    static void Main()
    {
        World.PopulateWeapons();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateLocations();

        Print("Game World Initialized\n", 60);
        Console.WriteLine("Type 'Start' to begin the game or type 'Quit' twice to exit the game.");
        if (Console.ReadLine().ToUpper() == "START")
        {
            Location startingLocation = World.LocationByID(World.LOCATION_ID_HOME);
            Print($"Welcome {startingLocation.Name}.", 60);
            Print(startingLocation.Description, 50);
            Print("Do you want to move to the townsquare? (Yes/No)", 60);

            if (Console.ReadLine().ToUpper() == "YES")
            {
                MoveToLocation(World.LOCATION_ID_TOWN_SQUARE);
            }
            else
            {
                Print("just say yes! What's wrong with you?",50);
                Console.ReadLine();
            }
            Location newLocation = World.LocationByID(World.LOCATION_ID_TOWN_SQUARE);
            Print($"You are now in {newLocation.Name}.", 50);
            Print(newLocation.Description, 60);

            DisplayAvaibleQuests(newLocation);

        }
        else if (Console.ReadLine().ToUpper() == "QUIT")
        {
            Print("Goodbye", 60);
        }
        else
        {
            Print("Invalid command.",70);
        }



    }
    static void MoveToLocation(int locationID)
    {
        Location newLocation = World.LocationByID(locationID);
        Console.WriteLine($"Moving to {newLocation.Name}......");
    }
    static void DisplayAvaibleQuests(Location location)
    {
        Console.WriteLine($"Quests available in {location.Name}");
        foreach (Quest quest in World.Quests)
        {
            if (quest.IsAvailableInLocation(location.ID))
            {
                Console.WriteLine($"- {quest.Name}: {quest.Description}");
            }
        }
    }
    public static void Print(string text, int speed) // making speed a higher number will slow the text more. 
    {
        foreach (char c in text)
        {
            Console.Write(c);
            System.Threading.Thread.Sleep(speed);
        }
    }
}