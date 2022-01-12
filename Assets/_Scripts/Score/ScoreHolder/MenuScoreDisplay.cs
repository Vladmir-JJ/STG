using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace JJ.STG.Main
{
    public class MenuScoreDisplay : MonoBehaviour
    {
        private TextMeshProUGUI resultsDisplay;
        public List<int> ListToExport { get; set; }        
        private void OnEnable()
        {
            ScoreHolder.UpdateMenu(this);
        }
        public void UpdateBestResoults(List<int> list)
        {
            resultsDisplay = GetComponent<TextMeshProUGUI>();
            
            if (list.Count>0)
            {
                if (list.Count < 10)
                {
                    resultsDisplay.text = "";
                    list.Sort();
                    list.Reverse();
                    ListToExport = list;                    
                    for (int i = 0; i < list.Count; i++)
                    {
                        resultsDisplay.text += ((i + 1) + ". : " + list[i] + "\n");
                    }
                }
                else if (list.Count >= 10)
                {
                    resultsDisplay.text = "";
                    list.Sort();
                    list.Reverse();
                    ListToExport = list;
                    for (int i = 0; i < 10; i++)
                    {
                        resultsDisplay.text += ((i + 1) + ". : " + list[i] + "\n");
                    }
                }
            }            
        }
    }
}