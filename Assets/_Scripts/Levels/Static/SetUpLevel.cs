using JJ.STG.Main;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Enemy
{
    public static class SetUpLevel
    {        
        public static void SetUpLines(int levelID, GameObject line, FirstLine lineScript)
        {
            int a = 0;
            DamageProcessor damageProcessor = GameObject.FindGameObjectWithTag("DmgProcessor").GetComponent<DamageProcessor>();
            damageProcessor.TriggerCoroutine();
            ScoreCounter scoreCounter = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<ScoreCounter>();
            scoreCounter.Score = 0;
            var startPosY = Presets.StartPosY[levelID];
            line.transform.position = new Vector3(line.transform.position.x, startPosY, line.transform.position.z);
            var lineSpawns = Presets.poolOfSpawns[7]; //possible upgrade to randomize number of enemies per each line
            damageProcessor.EnemiesInLine = lineSpawns.Count;            
            var linesQuantity = Presets.NumberOfLinesDic[startPosY];
            damageProcessor.EnemiesInCollumn = linesQuantity;            
            for (int i = 0; i < (linesQuantity - 1); i++)
                {                
                    foreach (int spawn in lineSpawns)
                    {
                    lineScript.SpawnTankEnemy(spawn, startPosY, i);
                    }
                startPosY += 2;
                damageProcessor.LinesOfEnemies.Add(lineScript.TempSpawnList);                
                lineScript.TempSpawnList = new List<GameObject>();
                a = i+1;
                }                   
                foreach (int spawn in lineSpawns)
                {
                    lineScript.SpawnShooterEnemy(spawn, startPosY, a);
                }
            damageProcessor.LinesOfEnemies.Add(lineScript.TempSpawnList);
            foreach(GameObject enemy in lineScript.TempSpawnList)
            {
                EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
                damageProcessor.listOfEnemies.Add(enemyScript);
            }
            lineScript.TempSpawnList = new List<GameObject>();
        }
    }
}