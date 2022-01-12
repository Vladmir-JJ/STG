using TMPro;
using UnityEngine;
namespace JJ.STG.Main
{
    public class DisplayGamesPlayed : MonoBehaviour
    {
        private TextMeshProUGUI gamesPlayed;
        public int gP { get; set; }        
        private void Start()
        {
            gamesPlayed = GetComponent<TextMeshProUGUI>();
            if (ScoreHolder.gamesPlayed >= 0)
            {
                gP = ScoreHolder.gamesPlayed;
                gamesPlayed.text = gP.ToString();                
            }
            else 
            {
                gamesPlayed.text = "0";                
            }
        }
        public void UpdateGamesPlayed()
        {
            gamesPlayed = GetComponent<TextMeshProUGUI>();
            gP = ScoreHolder.gamesPlayed;
            gamesPlayed.text = gP.ToString();            
        }  
    }
}