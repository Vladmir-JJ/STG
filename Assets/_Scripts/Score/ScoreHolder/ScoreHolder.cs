using System.Collections.Generic;
namespace JJ.STG.Main
{
    public static class ScoreHolder
    {
        public static List<int> savedScore = new List<int>();
        public static int gamesPlayed;

        public static void UpdateMenu(MenuScoreDisplay scoreDispl)
        {            
            scoreDispl.UpdateBestResoults(savedScore);
        }
    }
}