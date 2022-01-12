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
        private EnemyScript enemyScript;
        private int shooterId;
        private void Start()
        {
            //strzelaj¹ce (wystrzeliwuj¹ pocisk przed siebie co 4-7 sekund)
            reloadTime = Random.Range(4, 7);
            enemyScript = GetComponent<EnemyScript>();
            shooterId = enemyScript.cID;
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
                SpawnBullet(shooterId);
            }
        }
        private void SpawnBullet(int id)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBullet>().ShooterId = id;
        }
    }
}