using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace JJ.STG.Enemy
{
    public class FirstLine : MonoBehaviour
    {        
        public float MovementSpeed { get; set; }
        public bool MovingLeft { get; set; }
        [SerializeField]
        private GameObject tankPrefab;
        public GameObject TankPrefab { get; private set; }   
        [SerializeField]
        private GameObject shooterPrefab;
        public GameObject ShooterPrefab { get; private set; }
        private int levelID;
        [SerializeField]
        private float initialSpeed = 5f;
        public List<GameObject> TempSpawnList { get; set; }        
        void Start()
        {
            TempSpawnList = new List<GameObject>();
            levelID = SceneManager.GetActiveScene().buildIndex;            
            ShooterPrefab = shooterPrefab;
            TankPrefab = tankPrefab;
            MovementSpeed = initialSpeed;
            MovingLeft = true;
            StartCoroutine("WaitForFade");           
        }
        void Update()
        {            
            MoveLine(MovingLeft);
        }
        void MoveLine(bool isLeft)
        {
            if(isLeft == true)
            {
                transform.Translate(Vector3.left * Time.deltaTime * MovementSpeed);
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * MovementSpeed);
            }
        }
        public void SpawnTankEnemy(int x, int y, int ID)
        {
            GameObject Enemy = Instantiate(TankPrefab, new Vector3(x,y,0), Quaternion.identity);
            Enemy.transform.SetParent(this.transform.GetChild(0));
            Enemy enemyScript = Enemy.GetComponent<Enemy>();
            enemyScript.MyLine = ID;
            TempSpawnList.Add(Enemy);            
        }
        public void SpawnShooterEnemy(int x, int y, int ID)
        {
            GameObject Enemy = Instantiate(ShooterPrefab, new Vector3(x, y, 0), Quaternion.identity);
            Enemy.transform.SetParent(this.transform.GetChild(0));
            Enemy enemyScript = Enemy.GetComponent<Enemy>();
            enemyScript.MyLine = ID;
            TempSpawnList.Add(Enemy);
        }
        IEnumerator WaitForFade()
        {
            yield return new WaitForSeconds(1f);
            SetUpLevel.SetUpLines(levelID, this.gameObject, this);            
            yield break;
        }
    }
}