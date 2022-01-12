using JJ.STG.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]    
    public class EnemyScript : MonoBehaviour
    {       
        private DamageProcessor damageProcessor;
        [SerializeField]
        private FirstLine line;        
        [SerializeField]
        private float speedIncrementationOnKill;//this can be set to different value on each prefab - i.e tanks have +0.5, shooters +1
        [SerializeField]
        private float shootIncreaseOnKill;//like above both 0.5f
        private GameObject loader;
        private GameLevelLoader loaderScript;
        public int MyLine { get; set; }        
        private GameObject bangContainer;
        private AudioSource banger;
        [SerializeField]
        private AudioClip bang;
        public int cID { get; set; }        
        private void Start()
        {
            bangContainer = GameObject.FindGameObjectWithTag("banger");
            banger = bangContainer.GetComponent<AudioSource>();
            damageProcessor = GameObject.FindGameObjectWithTag("DmgProcessor").GetComponent<DamageProcessor>();
            line = GameObject.FindGameObjectWithTag("FirstLine").GetComponent<FirstLine>();
            loader = GameObject.FindGameObjectWithTag("Loader");
            loaderScript = loader.GetComponent<GameLevelLoader>();
        }
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Bottom")
            {
                loaderScript.ColidedWithBottom = true;
            }
            else if(col.gameObject.tag == "PlayerBullet")
            {
                line.MovementSpeed = line.MovementSpeed + speedIncrementationOnKill;                
                damageProcessor.enemiesInCollumnDic[cID]--;
                KillShotSpeedIcrementation.IncreaseRateOfFire(shootIncreaseOnKill);
                ScoreLogic.AddScore();
                Destroy(this.gameObject);                
            }
            else if(col.gameObject.tag == "Player")
            {
                bool destroyed = false;
                if(destroyed == false)
                {
                    destroyed = true;
                    damageProcessor.CurrentCollisonId = cID;
                    StartCoroutine("SkipFramesCol");
                }                
            }
        }        
        IEnumerator SkipFramesCol()
        {
            yield return new WaitForSeconds(0.01f);           
            ScoreLogic.RemoveScore(damageProcessor.CurrentDamage);
            damageProcessor.enemiesInCollumnDic[cID]--;
            banger.PlayOneShot(bang);
            Destroy(this.gameObject);
            yield break;
        }
        private void OnDestroy()
        {
            List<GameObject> temp = damageProcessor.LinesOfEnemies[MyLine];
            temp.RemoveAt(temp.Count - 1);
            damageProcessor.LinesOfEnemies[MyLine] = temp;
        }        
    }
}