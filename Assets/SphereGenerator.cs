using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [Space]
    [Header("Element")]
    [SerializeField] GameObject prifabSphere;
    

    public void GenerSphers() 
    {
        for (int i = 0; i < GemeWorldManager.instance.GameConfig.numperSphers; i++) 
        {
            GameObject g = prifabSphere;
            g.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(0f, 1f), Random.Range(-4f, 4f));
            Instantiate(prifabSphere, this.gameObject.transform);        
        }
        //logic gener
    }

    public void ClinerSphersContener()
    {
        foreach(Transform child in this.gameObject.transform) 
        {
            Destroy(child.gameObject);
        }
    }
}
