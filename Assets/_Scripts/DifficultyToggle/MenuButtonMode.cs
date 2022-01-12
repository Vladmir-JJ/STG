using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace JJ.STG.Difficulty
{
    public class MenuButtonMode : MonoBehaviour
    {
        private Button button;
        private bool collumn;
        [SerializeField]
        private TextMeshProUGUI displayMode;
        private void Start()
        {
            collumn = true;
            ViewDisplay(collumn);
            StaticGlobalDifficulty.isCountingCollumns = collumn;
            button = GetComponent<Button>();
            button.onClick.AddListener(ToggleMode);
        }
        void ToggleMode()
        {
            collumn = !collumn;
            StaticGlobalDifficulty.isCountingCollumns = collumn;
            ViewDisplay(collumn);
        }
        void ViewDisplay(bool isCollumn)
        {
            if (isCollumn)
            {
                displayMode.text = "Counts collumns \n (lower damage)";
            }
            else
                displayMode.text = "Counts rows \n (higher damage)";
        }
    }
}