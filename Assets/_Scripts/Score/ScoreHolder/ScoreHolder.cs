using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Main
{
    public static class ScoreHolder
    {
        public static List<int> savedScore = new List<int>();
        public static int gamesPlayed;

        public static void UpdateMenu(MenuScoreDisplay scoreDispl)
        {
            //MenuScoreDisplay scoreDispl = GameObject.FindGameObjectWithTag("MenuScoreList").GetComponent<MenuScoreDisplay>();
            scoreDispl.UpdateBestResoults(savedScore);
        }
    }
}