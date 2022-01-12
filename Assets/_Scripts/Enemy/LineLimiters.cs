using UnityEngine;
namespace JJ.STG.Enemy
{
    public class LineLimiters : MonoBehaviour
    {    
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
                bouncerL.transform.position = new Vector3(lX, (transform.position.y - 1), transform.position.z);
                bouncerR.transform.position = new Vector3(rX, (transform.position.y - 1), transform.position.z);
            }
            else 
            { 
                Destroy(bouncerR);
                Destroy(bouncerL);
            }
        }
    }
}