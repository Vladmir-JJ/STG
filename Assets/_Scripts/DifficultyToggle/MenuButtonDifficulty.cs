using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace JJ.STG.Difficulty
{
    public class MenuButtonDifficulty : MonoBehaviour
    {
        private Button button;
        private bool easy;
        [SerializeField]
        private TextMeshProUGUI displayDifficulty;
        private void Start()
        {
            easy = true;
            ViewDisplay(easy);
            StaticGlobalDifficulty.isEasy = easy;
            button = GetComponent<Button>();
            button.onClick.AddListener(ToggleDifficulty);
        }
        void ToggleDifficulty()
        {
            easy = !easy;
            StaticGlobalDifficulty.isEasy = easy;
            ViewDisplay(easy);
        }
        void ViewDisplay(bool isEasy)
        {
            if(isEasy)
            {
                displayDifficulty.text = "Difficulty NORMAL";
            }
            else
                displayDifficulty.text = "Difficulty HARD";
        }
    }
}