using System;


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