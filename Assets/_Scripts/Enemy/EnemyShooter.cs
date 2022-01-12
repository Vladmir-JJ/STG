using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Enemy
{
    public class EnemyShooter : MonoBehaviour
    {
        private float timer;
        private float reloadTime;
        [SerializeField]
        private float minAllowedShotDelay; //1.5f?
        public float CutReloadTime { get; set; }
        [SerializeField]
        private GameObject bulletSpawner;
        [SerializeField]
        private GameObject bulletPrefab;
        private void Start()
        {
            //strzelaj¹ce (wystrzeliwuj¹ pocisk przed siebie co 4-7 sekund
            reloadTime = Random.Range(4, 7);
        }
        private void FixedUpdate()
        {
            if (timer < reloadTime)
            {
                timer += Time.deltaTime;
            }
            else if (timer >= reloadTime)
            {
                timer = 0;
                reloadTime = Random.Range(4, 7) - CutReloadTime;//Next random shot after 4-7sec minus kill shot speed
                if (reloadTime < minAllowedShotDelay)
                {
                    reloadTime = minAllowedShotDelay;
                }                    
                SpawnBullet();
            }
        }
        private void SpawnBullet()
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.transform.position, Quaternion.identity);
        }
    }
}

