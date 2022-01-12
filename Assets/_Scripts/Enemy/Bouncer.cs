using UnityEngine;
namespace JJ.STG.Enemy
{
    public class Bouncer : MonoBehaviour
    {        
        public GameObject firstLine;
        private FirstLine line;
        [SerializeField]
        private float stepForward = 0.5f;
        void Start()
        {
            firstLine = GameObject.FindGameObjectWithTag("FirstLine");
            line = firstLine.GetComponent<FirstLine>();            
        }
        private void OnCollisionEnter(Collision col)
        {            
            //"Przeciwnicy cyklicznie poruszaj� si� w lewo (do kraw�dzi mapy), prawo (do kraw�dzi mapy), kawa�ek w d�."
            //so left col = bounce back, right col = bounce + drop
            if (col.gameObject.tag == "Bouncer")
            {                
                line.MovingLeft = !line.MovingLeft;                
            }
            else if(col.gameObject.tag == "BouncerDrop")
            {
                line.MovingLeft = !line.MovingLeft;
                firstLine.transform.position = new Vector3(firstLine.transform.position.x, firstLine.transform.position.y - stepForward, firstLine.transform.position.z);
            }
        }       
    }
}

