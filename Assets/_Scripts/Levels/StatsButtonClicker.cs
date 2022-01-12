using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace JJ.STG.Main
{
    public class StatsButtonClicker : MonoBehaviour
    {
        [SerializeField]
        private GameObject stats;
       // private GameObject statsButtonO;
        void Start()
        {
            Button statsButton = GetComponent<Button>();
            statsButton.onClick.AddListener(ViewStats);
        }       
        void ViewStats()
        {
            stats.SetActive(true);                      
        }
    }
}