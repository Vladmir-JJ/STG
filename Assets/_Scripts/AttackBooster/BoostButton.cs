using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JJ.STG.Player;
namespace JJ.STG.Feature
{
    public class BoostButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;
        private PlayerShooterController playerShooter;
        [SerializeField]
        float boosterMultiplier = 2f;
        [SerializeField]
        float boostDuration = 5f;
        private Button boost;
        [SerializeField]
        private Slider fillBar;
        void Start()
        {
            boost = GetComponent<Button>();
            boost.onClick.AddListener(Boost);
            boost.interactable = false;
            playerShooter = player.GetComponent<PlayerShooterController>();
        }
        void Boost()
        {
            StartCoroutine("BoostAttackSpeed");
            boost.interactable = false;
            fillBar.value = 0;
        }
        IEnumerator BoostAttackSpeed()
        {
            //dwukrotne przyspieszenie czêstotliwoœci wystrza³u naszego statku przez 5 sekund
            playerShooter.ReloadTime = playerShooter.ReloadTime / boosterMultiplier;
            yield return new WaitForSeconds(boostDuration);
            playerShooter.RestoreNormalReload();
            yield break;
        }
    }
}