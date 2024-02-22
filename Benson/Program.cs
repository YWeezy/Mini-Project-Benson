using System;

class Program
{
    static void Main()
    {
        World.PopulateWeapons();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateLocations();

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.BackgroundColor = ConsoleColor.Black;

        Print("Game World Initialized\n", 60);
        DisplayAscii();
        Console.WriteLine("Type 'Start' to begin the game or type 'Quit' twice to exit the game.");
        if (Console.ReadLine().ToUpper() == "START")
        {
            Console.Clear();
            Location startingLocation = World.LocationByID(World.LOCATION_ID_HOME);
            Print($"Welcome {startingLocation.Name}.", 60);
            Print(startingLocation.Description, 50);
            // Print("Do you want to move to the townsquare? (Yes/No\n)", 60);

            // if (Console.ReadLine().ToUpper() == "YES")
            // {
            //     MoveToLocation(World.LOCATION_ID_TOWN_SQUARE);

            // }
            // else
            // {
            //     Print("just say yes! What's wrong with you?", 50);
            //     Console.ReadLine();
            // }
            static void GameLoop()
            {
                Location currentLocation = World.LocationByID(World.LOCATION_ID_HOME);
                Print($"Welcome {currentLocation.Name}.", 60);
                Print(currentLocation.Description, 50);

                while (true)
                {
                    Print("\nWhat would you like to do? (Move/Quit)\n", 40);
                    string userInput = Console.ReadLine().ToUpper();

                    if (userInput == "QUIT")
                    {
                        Print("Goodbye", 60);
                        break;
                    }
                    else if (userInput == "MOVE")
                    {
                        MoveToNewLocation(currentLocation);
                    }
                    else
                    {
                        Print("Invalid command!", 70);
                    }
                }
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
            Print("Invalid command.", 70);
        }



    }
    static void MoveToNewLocation(Location currentLocation)
    {
        Console.WriteLine("Where would you like to move? (Type 'North', 'East', 'South', or 'West')");
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
                Print("Invalid direction.", 70);
                return;
        }

        if (newLocation != null)
        {
            currentLocation = newLocation;
            Print($"You moved to {currentLocation.Name}.", 50);
            Print(currentLocation.Description, 60);
        }
        else
        {
            Print("There is no path in that direction.", 70);
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
    public static void DisplayAscii()
    {
        string asciiART = @"

 ▄█     █▄     ▄████████  ▄█        ▄████████  ▄██████▄    ▄▄▄▄███▄▄▄▄      ▄████████
███     ███   ███    ███ ███       ███    ███ ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███
███     ███   ███    █▀  ███       ███    █▀  ███    ███ ███   ███   ███   ███    █▀ 
███     ███  ▄███▄▄▄     ███       ███        ███    ███ ███   ███   ███  ▄███▄▄▄    
███     ███ ▀▀███▀▀▀     ███       ███        ███    ███ ███   ███   ███ ▀▀███▀▀▀    
███     ███   ███    █▄  ███       ███    █▄  ███    ███ ███   ███   ███   ███    █▄ 
███ ▄█▄ ███   ███    ███ ███▌    ▄ ███    ███ ███    ███ ███   ███   ███   ███    ███
 ▀███▀███▀    ██████████ █████▄▄██ ████████▀   ▀██████▀   ▀█   ███   █▀    ██████████
                                                                                   
    ███      ▄██████▄ 
▀█████████▄ ███    ███
   ▀███▀▀██ ███    ███
    ███   ▀ ███    ███
    ███     ███    ███
    ███     ███    ███
    ███     ███    ███
   ▄████▀    ▀██████▀ 
                                                                                
▀█████████▄     ▄████████ ███▄▄▄▄      ▄████████  ▄██████▄  ███▄▄▄▄    ███ ▄████████
  ███    ███   ███    ███ ███▀▀▀██▄   ███    ███ ███    ███ ███▀▀▀██▄  █▀  ███    ███
  ███    ███   ███    █▀  ███   ███   ███    █▀  ███    ███ ███   ███      ███    █▀ 
 ▄███▄▄▄██▀   ▄███▄▄▄     ███   ███   ███        ███    ███ ███   ███      ███       
▀▀███▀▀▀██▄  ▀▀███▀▀▀     ███   ███ ▀███████████ ███    ███ ███   ███      ▀███████████
  ███    ██▄   ███    █▄  ███   ███          ███ ███    ███ ███   ███               ███
  ███    ███   ███    ███ ███   ███    ▄█    ███ ███    ███ ███   ███         ▄█    ███
▄█████████▀    ██████████  ▀█   █▀   ▄████████▀   ▀██████▀   ▀█   █▀        ▄████████▀ 
                                                        
████████▄  ███    █▄  ███▄▄▄▄      ▄██████▄     ▄████████  ▄██████▄  ███▄▄▄▄      
███   ▀███ ███    ███ ███▀▀▀██▄   ███    ███   ███    ███ ███    ███ ███▀▀▀██▄    
███    ███ ███    ███ ███   ███   ███    █▀    ███    █▀  ███    ███ ███   ███    
███    ███ ███    ███ ███   ███  ▄███         ▄███▄▄▄     ███    ███ ███   ███    
███    ███ ███    ███ ███   ███ ▀▀███ ████▄  ▀▀███▀▀▀     ███    ███ ███   ███    
███    ███ ███    ███ ███   ███   ███    ███   ███    █▄  ███    ███ ███   ███    
███   ▄███ ███    ███ ███   ███   ███    ███   ███    ███ ███    ███ ███   ███    
████████▀  ████████▀   ▀█   █▀    ████████▀    ██████████  ▀██████▀   ▀█   █▀     
";
        Print(asciiART, 2);
    }
}
