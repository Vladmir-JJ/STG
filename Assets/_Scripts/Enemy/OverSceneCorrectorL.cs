using UnityEngine;
namespace JJ.STG.Enemy
{
    public class OverSceneCorrectorL : MonoBehaviour
    {
        [SerializeField]
        private GameObject firstLine;
        private FirstLine firstLineScript;
        private void Start()
        {
            firstLineScript = firstLine.GetComponent<FirstLine>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            firstLineScript.MovingLeft = false;
            firstLine.transform.Translate(Vector3.right * Time.deltaTime * firstLineScript.MovementSpeed);
        }
    }
}