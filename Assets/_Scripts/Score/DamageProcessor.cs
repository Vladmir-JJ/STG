using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Main
{
    public class DamageProcessor : MonoBehaviour
    {
        public bool EasyMode = true;
        public int EnemiesInLine { get; set; }
        public List<List<GameObject>> LinesOfEnemies{ get; set; }
        private bool delayed = false;
        private int lowestRow = 0;
        public List<GameObject> LowestRowList { get; set; }
        public int CurrentDamage { get; set; }

        private void Awake()
        {
            LinesOfEnemies = new List<List<GameObject>>();
            delayed = false;
        }
        public void TriggerCoroutine()
        {
            StartCoroutine("UpdateDelay");
        }
        void Update()
        {            
            if(delayed == true)
            {               
                for (int i = 0; i < LinesOfEnemies.Count; i++)
                {                    
                    List<GameObject> currentLine = LinesOfEnemies[i];
                    if (currentLine.Count > 0)
                    {
                       
                    }
                    else if (lowestRow == i && currentLine.Count == 0)
                    {
                        if(lowestRow != LinesOfEnemies.Count -1)
                        {
                            lowestRow++;
                        }                        
                    }
                }                
                LowestRowList = LinesOfEnemies[lowestRow];
                CurrentDamage = Damage(LowestRowList.Count, EasyMode, EnemiesInLine);                
                if (LowestRowList.Count == 0)
                {
                    delayed = false;
                }
            }               
        }
        IEnumerator UpdateDelay()
        {
            yield return new WaitForSeconds(1.1f);
            delayed = true;
            yield break;
        }
        public static int Damage(int enemiesInRow, bool easyMode, int enemiesInLine)
        {
            if(easyMode == true)
            {
                var dmg = enemiesInRow * 2;
                return dmg;
            }
            else
            {
                var dmg = enemiesInLine * 2;
                return dmg;
            }    
        }
    }
}