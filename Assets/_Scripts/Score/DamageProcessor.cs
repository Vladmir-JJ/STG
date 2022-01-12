using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JJ.STG.Difficulty;
using JJ.STG.Enemy;
namespace JJ.STG.Main
{
    public class DamageProcessor : MonoBehaviour
    {
        public bool EasyMode = true;
        public bool CollumnMode = true;
        public int EnemiesInLine { get; set; }
        public int EnemiesInCollumn { get; set; }
        public List<List<GameObject>> LinesOfEnemies{ get; set; }
        private bool delayed = false;
        private int lowestRow = 0;
        public List<GameObject> LowestRowList { get; set; }
        public int CurrentDamage { get; set; }
        public int CurrentCollisonId { get; set; }
        public Dictionary<int, int> enemiesInCollumnDic = new Dictionary<int, int>();
        private bool wasDictionarySet = false;
        public int EnemiesInHitCollumn { get; set; }
        private EnemyScript[] enemies;
        public List<EnemyScript> listOfEnemies = new List<EnemyScript>();
        private void Awake()
        {
            LinesOfEnemies = new List<List<GameObject>>();
            delayed = false;
        }
        private void Start()
        {
            wasDictionarySet = false;            
        }
        public void TriggerCoroutine()
        {
            StartCoroutine("UpdateDelay");
        }
        void Update()
        {
            EasyMode = StaticGlobalDifficulty.isEasy;
            CollumnMode = StaticGlobalDifficulty.isCountingCollumns;
            if (delayed == true)
            {
                ProcessRows();                        
                LowestRowList = LinesOfEnemies[lowestRow];
                DamageRequest();                
            }
        }     
        private void SetupCollumnDictionary(List<GameObject> line)
        {
            enemies = (EnemyScript[])GameObject.FindObjectsOfType(typeof(EnemyScript));           
            wasDictionarySet = true;
            foreach(EnemyScript enemyScript in listOfEnemies)
            {
                var id = enemyScript.cID;
                enemiesInCollumnDic.Add(id, 0);
                CurrentCollisonId = id; //this is only to set initial value of this prop to something valid in dictionary
            }    
            foreach(EnemyScript enemy in enemies)
            {
                enemiesInCollumnDic[enemy.cID]++;
            }            
        }
        private void ProcessRows()
        {
            for (int i = 0; i < LinesOfEnemies.Count; i++)
            {
                List<GameObject> currentLine = LinesOfEnemies[i];
                if (wasDictionarySet == false)
                {
                    wasDictionarySet = true;
                    SetupCollumnDictionary(currentLine);
                }
                else if (lowestRow == i && currentLine.Count == 0)
                {
                    if (lowestRow != LinesOfEnemies.Count - 1)
                    {
                        lowestRow++;
                    }
                }
            }
        }
        private void DamageRequest()
        {
            if (CollumnMode == true)
            {
                CurrentDamage = Damage(enemiesInCollumnDic[CurrentCollisonId], EasyMode, EnemiesInCollumn);
            }
            else if (CollumnMode == false)
            {
                CurrentDamage = Damage(LowestRowList.Count, EasyMode, EnemiesInLine);
            }

            if (LowestRowList.Count == 0)
            {
                delayed = false;
            }
        }
        public static int Damage(int easyModeInput, bool easyMode, int hardModeInput)
        {
            if(easyMode == true)
            {
                var dmg = easyModeInput * 2;                
                return dmg;                
            }
            else
            {
                var dmg = hardModeInput * 2;
                return dmg;
            }              
        }
        IEnumerator UpdateDelay()
        {
            yield return new WaitForSeconds(1.1f);
            delayed = true;
            yield break;
        }
    }
}