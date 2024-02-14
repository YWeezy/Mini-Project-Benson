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
        Console.WriteLine(newLocation.Description);

        DisplayAvaibleQuests(newLocation);


        Console.ReadLine();
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
            if (Quest.IsAvailableInLocation(location.ID))
            {
                Console.WriteLine($"- {quest.Name}: {quest.Description}");
            }
        }
    }
}