using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereElement : MonoBehaviour
{
    [Space]
    [Header("Conlig")]
    [SerializeField] float powerImpuls;

    private void OnMouseDown()
    {     
        Impuls();
    }

    private void Impuls() 
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * powerImpuls, ForceMode.Impulse);
    }
}
