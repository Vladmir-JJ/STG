using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Player
{
    public class PlayerShooterController : MonoBehaviour
    {
        private Transform bulletSpawner;
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private float reloadTime = 2f;
        private float timer = 0f;
        //[SerializeField]
        //private float bulletSpeed = 50f;

        void Start()
        {
            timer = 0;
            bulletSpawner = transform.GetChild(0);
        }
        private void FixedUpdate()
        {
            if (timer < reloadTime)
            {
                timer += Time.deltaTime;
            }
            else if(timer >= reloadTime)
            {
                timer = 0;
                SpawnBullet();
            }
        }
        private void SpawnBullet()
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);
            //bullet.transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
        }
    }
}