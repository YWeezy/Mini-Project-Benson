using System;

public static class Utils
{
    public static void Print(string text, int speed)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            System.Threading.Thread.Sleep(speed);
        }
    }

    public static void Maplocation(int current_location_ID, string current_location_name, bool show)
    {
        Console.WriteLine($"+ Current location: {current_location_name}\n");
        Console.WriteLine("Possibilities:");
        if (show)
        {
            switch (current_location_ID)
            {
                case 1:
                    Console.WriteLine("> North: Town Square\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("--|---");
                    Console.WriteLine("  +");
                    break;
                case 2:
                    Console.WriteLine("> North: Alchemist's hut");
                    Console.WriteLine("> East: Guard post");
                    Console.WriteLine("> South: Home");
                    Console.WriteLine("> West: Farmhouse\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("--+---");
                    Console.WriteLine("  |");
                    break;
                case 3:
                    Console.WriteLine("> East: Bridge");
                    Console.WriteLine("> West: Town Square\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("--|+--");
                    Console.WriteLine("  |");
                    break;
                case 4:
                    Console.WriteLine("> North: Alchemist's garden");
                    Console.WriteLine("> South: Town Square\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  +");
                    Console.WriteLine("--|---");
                    Console.WriteLine("  |");
                    break;
                case 5:
                    Console.WriteLine("> South: Alchemist's hut\n");
                    Console.WriteLine("  +");
                    Console.WriteLine("  |");
                    Console.WriteLine("--|---");
                    Console.WriteLine("  |");
                    break;
                case 6:
                    Console.WriteLine("> East: Town Square");
                    Console.WriteLine("> West: Farmer's field\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("-+|---");
                    Console.WriteLine("  |");
                    break;
                case 7:
                    Console.WriteLine("> East: Farmhouse\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("+-|---");
                    Console.WriteLine("  |");
                    break;

                case 8:
                    Console.WriteLine("> East: Forest");
                    Console.WriteLine("> West: Guard post\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("--|-+-");
                    Console.WriteLine("  |");
                    break;
                case 9:
                    Console.WriteLine("> West: Bridge\n");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("--|--+");
                    Console.WriteLine("  |");
                    break;

                default:
                    Console.WriteLine("No Location");
                    return;
            }
        }
    }
}
