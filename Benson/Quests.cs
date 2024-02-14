using System;
using System.Collections.Generic;

public class Quest
{
    public int ID { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsCompleted { get; set; }
    public List<int> LocationIds { get; set; }
    
    
    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
        IsCompleted = false;
        LocationIds = new List<int>();
    }
    public bool IsAvailableInLocation(int locationId)
    {
        return LocationIds.Contains(locationId);
    }
}

public static class Quests
{   
    public static List<Quest> GetInitialQuests()
    { 
        List<Quest> initialQuest = new List<Quest>
        {
            new Quest(1, "Welcome", "Start you journey by exploring the town.") { LocationIds = {World.LOCATION_ID_HOME}},
            new Quest(2, "Explore the streets", "Dance battle on the streets.") { LocationIds = {World.LOCATION_ID_TOWN_SQUARE}}
        };  
        return initialQuest;
    }
}
