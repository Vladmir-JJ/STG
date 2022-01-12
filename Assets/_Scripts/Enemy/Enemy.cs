using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JJ.STG.Main;
namespace JJ.STG.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]    
    public class Enemy : MonoBehaviour
    {
        /*[SerializeField]
        private float stepForward = 0.5f;
        private bool recentlyCollided = false;
        private float minX = -10.5f;
        private float maxX = 10.5f;*/
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
                KillShotSpeedIcrementation.IncreaseRateOfFire(shootIncreaseOnKill);
                ScoreLogic.AddScore();
                Destroy(this.gameObject);                
            }
            else if(col.gameObject.tag == "Player")
            {                
                ScoreLogic.RemoveScore(damageProcessor.CurrentDamage);
                banger.PlayOneShot(bang);
                Destroy(this.gameObject);
            }
        }
        private void OnDestroy()
        {
            List<GameObject> temp = damageProcessor.LinesOfEnemies[MyLine];            
            temp.RemoveAt(temp.Count - 1);
            damageProcessor.LinesOfEnemies[MyLine] = temp;
        }
    }
}

