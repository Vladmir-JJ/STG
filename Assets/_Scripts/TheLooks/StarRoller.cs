using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Looks
{

}
public class StarRoller : MonoBehaviour
{
    private MeshRenderer mr;
    Material mat;
    [SerializeField]
    private float minTreshold;
    [SerializeField]
    private float maxTreshold;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;        
    }
    void Update()
    {       
        Vector2 offset = mat.mainTextureOffset;
        offset.x += (Random.Range(minTreshold, maxTreshold) * Time.deltaTime);
        offset.y += (Random.Range(minTreshold, maxTreshold) * Time.deltaTime);
        mat.mainTextureOffset = offset;
    }
}
