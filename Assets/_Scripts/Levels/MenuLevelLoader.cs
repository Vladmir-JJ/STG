using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace JJ.STG.Main
{
    public class MenuLevelLoader : MonoBehaviour
    {
        [SerializeField]
        private Button playButtonO;
        [SerializeField]
        private Animator fader;
        public float fadeTime = 1f;
        private int levelID = 1;
        [SerializeField]
        private GameObject gamesPlayedDisplay;
        private DisplayGamesPlayed displayGamesScript;
        [SerializeField]
        private GameObject musicPlayer;
        [SerializeField]
        private AudioClip audioBreak;
        private AudioSource audioSource;
        private void Awake()
        {
            GameData data = SaveSystem.LoadData();
            if(data != null)
            {
                ScoreHolder.gamesPlayed = data.gamesPlayed;
                ScoreHolder.savedScore.Clear();
                foreach(int score in data.topTen)
                {
                    ScoreHolder.savedScore.Add(score);
                    ScoreHolder.savedScore.Sort();
                    ScoreHolder.savedScore.Reverse();
                }
            }
        }
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            Button playButton = playButtonO.GetComponent<Button>();
            playButton.onClick.AddListener(ClickPlay);
            displayGamesScript = gamesPlayedDisplay.GetComponent<DisplayGamesPlayed>();
            musicPlayer.SetActive(true);
        }
        void ClickPlay()
        {            
            StartCoroutine("Fade");
            ScoreHolder.gamesPlayed++;
            musicPlayer.SetActive(false);
            audioSource.PlayOneShot(audioBreak);
            //displayGamesScript.UpdateGamesPlayed();            
        }
        IEnumerator Fade()
        {
            fader.SetTrigger("Start");
            yield return new WaitForSeconds(fadeTime);
            SceneLoader.LoadScene(levelID);
            yield break;
        }
        
    }
}