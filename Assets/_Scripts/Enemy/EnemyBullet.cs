using JJ.STG.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Enemy
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletSpeed = 50f;        
        void Update()
        {
            
            transform.Translate(Vector3.down * Time.deltaTime * bulletSpeed);           
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                DamageProcessor damageProcessor = GameObject.FindGameObjectWithTag("DmgProcessor").GetComponent<DamageProcessor>();
                ScoreLogic.RemoveScore(damageProcessor.CurrentDamage);
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.tag == "Bottom")
            {
                Destroy(this.gameObject);
            }
        }       
    }
}