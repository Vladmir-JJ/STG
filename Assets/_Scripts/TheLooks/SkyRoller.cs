using UnityEngine;
namespace JJ.STG.Looks
{
    public class SkyRoller : MonoBehaviour
    {  
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -19f, 5), Time.deltaTime);
        }
    }
}