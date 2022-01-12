using System.Collections.Generic;
namespace JJ.STG.Main
{
    [System.Serializable]
    public class GameData
    {
        public int gamesPlayed;
        public int[] topTen;
       public GameData(int timesPlayed, List<int> scoreList)
        {
            gamesPlayed = timesPlayed;
            scoreList.Sort();
            scoreList.Reverse();
            topTen = new int[10];
            if (scoreList.Count < 10)
            {
                for (int i = 0; i < scoreList.Count; i++)
                {
                    int inter = scoreList[i];
                    topTen[i] = inter;
                }
            }
            else if (scoreList.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (scoreList[i] >= 0)
                    {
                        int inter = scoreList[i];
                        topTen[i] = inter;
                    }
                }
            }            
        }        
    }
}

