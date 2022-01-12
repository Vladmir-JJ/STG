using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace JJ.STG.Main
{    public class ScoreCounter : MonoBehaviour
    {
        private TextMeshProUGUI counter;
        public int Score { get; set; }
        void Start()
        {
            Score = 0;
            counter = GetComponent<TextMeshProUGUI>();
        }
        void Update()
        {
            counter.text = Score.ToString();
        }
    }
}