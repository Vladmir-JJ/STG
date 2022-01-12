using UnityEngine;
namespace JJ.STG.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletSpeed = 50f;        
        void Update()
        {
            transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
        }
    }
}