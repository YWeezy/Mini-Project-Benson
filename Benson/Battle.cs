class Battle
{
    public static bool fighting = true;
    public static new Monster monster_battle;
    public static Player player_battle;
    public Battle(Monster monster, Player player){
        monster_battle = monster;
        player_battle = player;
    }

    public void battleroom(){
        while (monster_battle.Health > 0 && fighting ){
            int turn = 0;
            string input = Console.ReadLine().ToUpper();
            if (input == "Q"){
                fighting = false;
            }
            //Als turn even is is de player aan de beurt 
            if ((turn % 2) == 0) {
                monster_battle.Health = monster_battle.Health - player_battle.Damage;
            }
            else{
                player_battle.HP = player_battle.HP - monster_battle.Damage;
            }
        }
    }
}