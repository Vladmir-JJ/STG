using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Enemy
{
    public class LineLimiters : MonoBehaviour
    {
        //private List<Transform> children;
        //private int childrenCount;
        public int ChildrenCount { get; set; }
        private int recentCount;
        private float minX;
        private float maxX;
        [SerializeField]
        private GameObject bouncerPrefab;
        [SerializeField]
        private GameObject bouncerContainer;
        private GameObject bouncerL;
        private GameObject bouncerR;

        void Start()
        {
            ChildrenCount = transform.GetChild(0).childCount;
            recentCount = ChildrenCount;
            //minX = Mathf.NegativeInfinity;
            // = Mathf.Infinity;
            bouncerL = Instantiate(bouncerPrefab, transform.position, Quaternion.identity);
            bouncerR = Instantiate(bouncerPrefab, transform.position, Quaternion.identity);
            bouncerL.transform.SetParent(bouncerContainer.transform);
            bouncerR.transform.SetParent(bouncerContainer.transform);
            foreach (Transform child in transform.GetChild(0))
            {
                minX = Mathf.NegativeInfinity;
                maxX = Mathf.Infinity;
                if (child.position.x > minX)
                {
                    minX = child.position.x;
                }
                if (child.position.x < maxX)
                {
                    maxX = child.position.x;
                }
            }
            ChangePosition(minX, maxX);
        }
        void Update()
        {
            ChildrenCount = transform.GetChild(0).childCount;

            if (recentCount != ChildrenCount)
            {
                minX = Mathf.NegativeInfinity;
                maxX = Mathf.Infinity;
                recentCount = ChildrenCount;                
                foreach (Transform child in transform.GetChild(0))
                {
                    if (child.position.x > minX)
                    {
                        minX = child.position.x;
                    }
                    if (child.position.x < maxX)
                    {
                        maxX = child.position.x;
                    }
                }                
                ChangePosition(minX, maxX);                
            }            
        }
        void ChangePosition(float rX, float lX)
        {
            if (rX != Mathf.Infinity && rX != Mathf.NegativeInfinity && lX != Mathf.Infinity && lX != Mathf.NegativeInfinity)//NEW
            {
                //Debug.Log(rX + " " + lX);
                bouncerL.transform.position = new Vector3(lX, (transform.position.y - 1), transform.position.z);
                //Debug.Log("Bouncer L position " + bouncerL.transform.position.x + " should be " + lX);
                bouncerR.transform.position = new Vector3(rX, (transform.position.y - 1), transform.position.z);
                //Debug.Log("Bouncer R position " + bouncerR.transform.position.x + " should be " + rX);
            }
            else 
            { 
                Destroy(bouncerR);
                Destroy(bouncerL);
            }
        }
    }
}
