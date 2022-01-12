using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JJ.STG.Main
{

    public class MenuScoreDisplay : MonoBehaviour
    {
        private TextMeshProUGUI resultsDisplay;
        public List<int> ListToExport { get; set; }
        private void Start()
        {
            //resultsDisplay = GetComponent<TextMeshProUGUI>();
            //Debug.Log(resultsDisplay);
        }
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
                    /*foreach (int score in list)
                    {
                        resultsDisplay.text += (score + "\n");
                    }*/
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
            /*if (list.Count < 10)
            {
                list.Sort();
                list.Reverse();
                *//*foreach (int score in list)
                {                
                        resultsDisplay.text += (score + "\n");
                }*//*
                for (int i = 0; i < list.Count; i++)
                {
                    resultsDisplay.text += ((i + 1) + ". : " + list[i] + "\n");
                }
            }
            else if (list.Count >= 10)
            {
                list.Sort();
                list.Reverse();
                for (int i = 0; i < 10; i++)
                {
                    resultsDisplay.text += ((i + 1) + ". : " + list[i] + "\n");
                }
            }*/
        }
    }
}