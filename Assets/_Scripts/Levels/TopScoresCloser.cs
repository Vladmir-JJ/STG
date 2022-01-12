using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace JJ.STG.Main
{
    public class TopScoresCloser : MonoBehaviour
    {
        [SerializeField]
        private Button closeO;
        void Start()
        {
            this.gameObject.SetActive(false);
            Button close = closeO.GetComponent<Button>();
            close.onClick.AddListener(CloseScores);
        }
        private void CloseScores()
        {
            this.gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            DisplayGamesPlayed gamesDisplayedScript = GameObject.FindGameObjectWithTag("gamescount").GetComponent<DisplayGamesPlayed>();
            gamesDisplayedScript.UpdateGamesPlayed();
        }
    }
}