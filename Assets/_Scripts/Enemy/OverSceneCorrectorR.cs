using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Enemy
{
    public class OverSceneCorrectorR : MonoBehaviour
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
            firstLineScript.MovingLeft = true;
            firstLine.transform.Translate(Vector3.left * Time.deltaTime * firstLineScript.MovementSpeed);
        }
    }
}