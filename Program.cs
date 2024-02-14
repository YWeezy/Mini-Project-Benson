class Program
{
    static void Main()
    {
        World.InitializeGame();
        Console.WriteLine("Game World Initialized");

        Location startingLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Console.WriteLine($"Welcome to {startingLocation.Name}.");
        Console.WriteLine(startingLocation.Description);

        MoveToLocation(World.LOCATION_ID_TOWN_SQUARE);

        Location newLocation = World.LocationByID(World.LOCATION_ID_TOWN_SQUARE);
        Console.WriteLine($"You are now in {newLocation.Name}.");
        Console.WriteLine(townSquare.Description);

        DisplayAvaibleQuests(newLocation);


        Console.Readline();
    }
    static void MoveToLocation(int locationID)
    {
        Location newLocation = World,LocationByID(locationId)
        Console.Writeline($"Moving to {newLocation.name}......");
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
}