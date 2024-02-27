using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static Player player = new Player();
    static void Main()
    {
        World.PopulateWeapons();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateLocations();
        
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.BackgroundColor = ConsoleColor.Black;

        GameLoop();

        // Print("Game World Initialized\n", 60);
        // DisplayAscii();
        // Console.WriteLine("Type 'Start' to begin the game or type 'Quit' twice to exit the game.");
        // if (Console.ReadLine().ToUpper() == "START")
        // {
        //     Console.Clear();
        //     Location startingLocation = World.LocationByID(World.LOCATION_ID_HOME);
        //     Print($"Welcome {startingLocation.Name}.", 60);
        //     Print(startingLocation.Description, 50);
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

        //         Location newLocation = World.LocationByID(World.LOCATION_ID_TOWN_SQUARE);
        //         Print($"You are now in {newLocation.Name}.", 50);
        //         Print(newLocation.Description, 60);

        //         DisplayAvailableQuests(newLocation);

        //     }
        //         else if (Console.ReadLine().ToUpper() == "QUIT")
        //         {
        //             Print("Goodbye", 60);
        // }
        //         else
        // {
        //     Print("Invalid command.", 70);
        // }



    }
    static void GameLoop()
    {
        Location currentLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Print($"Welcome {currentLocation.Name}.", 60);
        Print(currentLocation.Description, 50);

        while (true)
        {
            if (currentLocation.ActiveMonsters){
                Print("\nWhat would you like to do? (Move/Quit/Fight)\n", 40);
            }else{
                Print("\nWhat would you like to do? (Move/Quit)\n", 40);
            }
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "QUIT")
            {
                Print("Goodbye", 60);
                break;
            }
            else if (userInput == "MOVE")
            {
                currentLocation = MoveToNewLocation(currentLocation);
                DisplayAvailableQuests(currentLocation);
            }
            else if (userInput == "FIGHT" && currentLocation.ActiveMonsters)
            {
                
                Battle Fight = new Battle(currentLocation.MonsterLivingHere, player);
                Fight.battleroom();
                
            }
            else
            {
                Print("Invalid command!", 70);
            }
        }
    }
    static Location MoveToNewLocation(Location currentLocation)
    {
        Console.WriteLine("Where would you like to move? (Type 'North', 'East', 'South', or 'West')");
        Maplocation(currentLocation.ID, true);
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
                break;
        }

        if (newLocation != null)
        {
            Print($"You moved to {newLocation.Name}.", 50);
            Print(newLocation.Description, 60);
            return newLocation;
        }
        else
        {
            Print("There is no path in that direction.", 70);
            return currentLocation;
        }
    }

    static void Maplocation(int current_location_ID, bool show){
        if (show){
            switch (current_location_ID)
        {
            case 1:
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("--|---");
                Console.WriteLine("  +");
                break;
            case 2:
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("--+---");
                Console.WriteLine("  |");
                break;
            case 3:
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("--|+--" );
                Console.WriteLine("  |" );
                break;
            case 4:
                Console.WriteLine("  |" );
                Console.WriteLine("  +" );
                Console.WriteLine("--|---" );
                Console.WriteLine("  |" );
                break;
            case 5:
                Console.WriteLine("  +" );
                Console.WriteLine("  |" );
                Console.WriteLine("--|---" );
                Console.WriteLine("  |" );
                break;
            case 6:
                Console.WriteLine("  |" );
                Console.WriteLine("  |" );
                Console.WriteLine("-+|---" );
                Console.WriteLine("  |" );
                break;
            case 7:
                Console.WriteLine("  |" );
                Console.WriteLine("  |" );
                Console.WriteLine("+-|---" );
                Console.WriteLine("  |" );
                break;

            case 8:
                Console.WriteLine("  |" );
                Console.WriteLine("  |" );
                Console.WriteLine("--|-+-" );
                Console.WriteLine("  |" );
                break;
            case 9:
                Console.WriteLine("  |" );
                Console.WriteLine("  |" );
                Console.WriteLine("--|--+" );
                Console.WriteLine("  |");
                break;
            
            default:
                Console.WriteLine("No Location");
                return;
        }
        }
        
    }

    static void MoveToLocation(int locationID)
    {
        Location newLocation = World.LocationByID(locationID);
        Console.WriteLine($"Moving to {newLocation.Name}......");
    }
    static void DisplayAvailableQuests(Location location)
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
  ███    ███   ███    ███ ███▀▀▀██▄   ███    ███ ███    ███ ███▀▀▀██▄   ▀█  ███    ███
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
