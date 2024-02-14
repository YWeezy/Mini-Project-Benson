using System;

public class Quest
{
    public int ID { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsCompleted { get; set; }
    
    
    public Quest(int id, string name, string description){
        ID = id;
        Name = name;
        Description = description;
        IsCompleted = false;
    }
}

public static class Quests
{
    public static class StoryQuests
    {
        public static List<Quest> GetInitialQuests()
        { 
            List<Quest> initialQuest = new List<Quest>
            {
                new Quest(1, "Welcome", "Start you journey by exploring the town.")
                new Quest(2, "Explore the streets", "Dance battle on the streets.")
            };

            return initialQuests;
        }
    }
}
