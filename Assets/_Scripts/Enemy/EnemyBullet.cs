using JJ.STG.Main;
using System.Collections;
using UnityEngine;
namespace JJ.STG.Enemy
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletSpeed = 50f;
        public int ShooterId { get; set; }
        void Update()
        {            
            transform.Translate(Vector3.down * Time.deltaTime * bulletSpeed);           
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                DamageProcessor damageProcessor = GameObject.FindGameObjectWithTag("DmgProcessor").GetComponent<DamageProcessor>();
                damageProcessor.CurrentCollisonId = ShooterId;
                StartCoroutine("SkipFrames");               
            }
            else if (collision.gameObject.tag == "Bottom")
            {
                Destroy(this.gameObject);
            }
        }
        IEnumerator SkipFrames()
        {
            yield return new WaitForSeconds(0.01f);            
            DamageProcessor damageProcessor = GameObject.FindGameObjectWithTag("DmgProcessor").GetComponent<DamageProcessor>();            
            ScoreLogic.RemoveScore(damageProcessor.CurrentDamage);
            Destroy(this.gameObject);
            yield break;
        }
    }
}