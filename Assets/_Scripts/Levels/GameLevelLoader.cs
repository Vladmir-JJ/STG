using JJ.STG.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace JJ.STG.Main
{
    public class GameLevelLoader : MonoBehaviour
    {        
        [SerializeField]
        private Animator fader;
        public float fadeTime = 1f;
        private int menulID = 0;
        private ScoreCounter scoreCounter;
        [SerializeField]
        private GameObject gameOver;
        [SerializeField]
        private GameObject youWin;
        public bool ColidedWithBottom { get; set; }
        [SerializeField]
        private GameObject steeringButtons;
        [SerializeField]
        private GameObject gameTheater;
        [SerializeField]
        private GameObject gameDisplay;
        [SerializeField]
        private GameObject menuButton;
        private Transform enemyContainer;
        private bool delayTick = false;
        [SerializeField]
        private TextMeshProUGUI bestResults;
        [SerializeField]
        private GameObject bestResGO;
        [SerializeField]
        private GameObject musicPlayer;
        [SerializeField]
        private AudioClip audioBreak;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            enemyContainer = GameObject.FindGameObjectWithTag("FirstLine").transform.GetChild(0);
            scoreCounter = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<ScoreCounter>();
            Button menu = menuButton.GetComponent<Button>();
            menu.onClick.AddListener(BackToMenu);
            ColidedWithBottom = false;
            gameOver.SetActive(false);
            menuButton.SetActive(false);
            youWin.SetActive(false);
            bestResGO.SetActive(false);
            StartCoroutine("InicializeDelay");
        }
        private void Update()
        {
            if (scoreCounter != null)
            {
                if (scoreCounter.Score < 0 || ColidedWithBottom == true)
                {
                    GameOver();
                    /*gameTheater.SetActive(false);
                    steeringButtons.SetActive(false);
                    gameDisplay.SetActive(false);
                    gameOver.SetActive(true);
                    menuButton.SetActive(true);*/
                }
                else if(enemyContainer.childCount == 0 && delayTick == true)
                {
                    GameWon();
                }
            }            
        }
        void BackToMenu()
        {
            StartCoroutine("FadeToMenu");
        }
        IEnumerator FadeToMenu()
        {
            yield return new WaitForSeconds(0.5f);
            fader.SetTrigger("Start");
            yield return new WaitForSeconds(fadeTime);
            ColidedWithBottom = false;
            gameTheater.SetActive(true);
            steeringButtons.SetActive(true);
            gameDisplay.SetActive(true);
            menuButton.SetActive(false);
            gameOver.SetActive(false);
            bestResGO.SetActive(false);
            delayTick = false;
            SceneLoader.LoadScene(menulID);
            yield break;
        }
        IEnumerator InicializeDelay()
        {
            yield return new WaitForSeconds(1.5f);
            delayTick = true;
            yield break;
        }
        void GameOver()
        {
            musicPlayer.SetActive(false);
            audioSource.PlayOneShot(audioBreak);
            gameTheater.SetActive(false);
            steeringButtons.SetActive(false);
            gameDisplay.SetActive(false);
            gameOver.SetActive(true);
            menuButton.SetActive(true);
            youWin.SetActive(false);
            scoreCounter.Score = 0;
            delayTick = false;
            bestResGO.SetActive(false);
            SaveSystem.SaveGame(ScoreHolder.gamesPlayed, ScoreHolder.savedScore);            
        }
        void GameWon()
        {
            musicPlayer.SetActive(false);
            audioSource.PlayOneShot(audioBreak);
            gameTheater.SetActive(false);
            steeringButtons.SetActive(false);
            gameDisplay.SetActive(false);
            gameOver.SetActive(false);
            menuButton.SetActive(true);
            youWin.SetActive(true);
            delayTick = false;
            bestResGO.SetActive(true);
            var youWasDisplayed = false;
            ScoreHolder.savedScore.Add(scoreCounter.Score);
            SaveSystem.SaveGame(ScoreHolder.gamesPlayed, ScoreHolder.savedScore);
            //ScoreHolder.UpdateMenu();
            if (ScoreHolder.savedScore.Count < 10)
            {
                ScoreHolder.savedScore.Sort();
                ScoreHolder.savedScore.Reverse();
                foreach (int score in ScoreHolder.savedScore)
                {
                    if(score == scoreCounter.Score)
                    {
                        if (youWasDisplayed == false)
                        {
                            bestResults.text += (score + "< -- YOU!" + "\n");
                            youWasDisplayed = true;
                        }
                        else if (youWasDisplayed == true)
                        {
                            bestResults.text += (score + "\n");
                        }
                    }
                    else
                    {
                        bestResults.text += (score + "\n");
                    }
                }
            }
            else if (ScoreHolder.savedScore.Count >= 10)
            {
                ScoreHolder.savedScore.Sort();
                ScoreHolder.savedScore.Reverse();
                for (int i = 0; i < 10; i++)
                {
                    if (ScoreHolder.savedScore[i] == scoreCounter.Score)
                    {
                        if (youWasDisplayed == false)
                        {
                            bestResults.text += (ScoreHolder.savedScore[i] + "< -- YOU!" + "\n");
                            youWasDisplayed = true;
                        }
                        else if (youWasDisplayed == true)
                        {
                            bestResults.text += (ScoreHolder.savedScore[i] + "\n");
                        }
                    }
                    else
                    {
                        bestResults.text += (ScoreHolder.savedScore[i] + "\n");
                    }
                }
            }            
        }
    }
}