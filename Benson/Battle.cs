class Battle
{
    public static bool fighting = true;
    public static Monster monster_battle;
    public Battle(Monster monster){
        monster_battle = monster;

    }

    static void battleroom(){
        while (monster_battle.Health < 0 && fighting ){
            int turn = 0;
            //Als turn even is is de player aan de beurt 
            if ((turn % 2) == 0) {
                
            }
            else{

            }
        }
    }
}