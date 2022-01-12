using UnityEngine;
namespace JJ.STG.Player
{
    public class PlayerMovementController : MonoBehaviour
    {        
        [SerializeField]
        private float playerSpeed;
        private float xLeft = -9.5f;
        private float xRight = 9.5f;
        bool movingLeft;
        bool movingRight;
        void Start()
        {                    
            movingLeft = false;
            movingRight = false;
        }  
        void Update()
        {

            if (movingLeft)
            {
                MoveLeft();
            }
            else if (movingRight)
            {
                MoveRight();
            }

        }

        public void StartMovingLeft()
        {
            movingLeft = true;
        }

        public void StopMovingLeft()
        {
            movingLeft = false;
        }

        public void StartMovingRight()
        {
            movingRight = true;
        }

        public void StopMovingRight()
        {
            movingRight = false;
        }

        void MoveLeft()
        {
            if (transform.position.x >= xLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
            }
        }

        void MoveRight()
        {            
            if (transform.position.x <= xRight)
            {
                transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
            }
        } 
    }
}