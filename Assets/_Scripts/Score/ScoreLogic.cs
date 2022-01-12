using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Main
{
    public static class ScoreLogic
    {        
        public static void AddScore()
        {
            ScoreCounter scoreCounter = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<ScoreCounter>();
            scoreCounter.Score++;
        }
        public static void RemoveScore(int ammount)
        {
            ScoreCounter scoreCounter = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<ScoreCounter>();
            scoreCounter.Score -= ammount;
        }
    }
}