namespace Plan_B
{
    public class GameData
    {
        //This function allow to modify the direction from the ball
        public static bool GameStarted = false;
        public static int dirX = 10, dirY = -dirX, lifes = 3, score = 0;

        public static void initializeGame()
        {
            GameStarted = false;
            lifes = 3;
            score = 0;
        }
    }
}