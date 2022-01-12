using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace JJ.STG.Feature
{
    public class ProgressBar : MonoBehaviour
    {
        private Slider slider;
        private float fillSpeed = 1f;
        private float targetProgress = 40;
        private bool delay;
        [SerializeField]
        private GameObject boosterButton;
        private Button booster;
        private void Start()
        {
            booster = boosterButton.GetComponent<Button>();
            delay = false;
            slider = GetComponent<Slider>();
            StartCoroutine("Delay");
        }
        private void Update()
        {
            if(delay == true)
            {
                if (slider.value < targetProgress)
                {
                    slider.value += fillSpeed * Time.deltaTime;
                    booster.interactable = false;
                }
                else
                {
                    booster.interactable = true;
                }
            }            
        }    
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1.2f);
            delay = true;
            yield break;
        }
    }
}

