using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class SphereElement : MonoBehaviour
{
    [Space]
    [Header("Conlig")]
    [SerializeField] float powerImpuls;
    [SerializeField] public int id;
    [SerializeField] public Color32 corectColor;
    public event Action<string> EventsCollisions;

    public event Action<SphereElement, int> EventsCollisionsSphere;


    private void Start()
    {
        powerImpuls = GemeWorldManager.instance.GameConfig.impulsPover;

        GemeWorldManager.instance.eventManager.InstEvent(ref EventsCollisions);
        GemeWorldManager.instance.eventManager.InstEvent(ref EventsCollisionsSphere);


        Renderer rend = this.gameObject.GetComponent<Renderer>();
        var material = new Material(Shader.Find("Standard"));
        material.color = Color.white; //  GemeWorldManager.instance.GameConfig.colors[Random.Range(0, GemeWorldManager.instance.GameConfig.colors.Length)];
        corectColor = material.color;
        rend.material = material;
    }

    private void OnMouseDown()
    {     
        Impuls();
    }

  
    private void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.tag == "Wall") 
        {
            EventsCollisions?.Invoke("Wall");
            //   Debug.Log("Wall");
            corectColor = GemeWorldManager.instance.GameConfig.colors[Random.Range(0, GemeWorldManager.instance.GameConfig.colors.Length)];
            this.gameObject.GetComponent<Renderer>().material.DOColor(corectColor, 0.3f);
              
        }


        if (collision.gameObject.tag == "Sphere")
        {
            EventsCollisions?.Invoke("Sphere");
            // Debug.Log("Sphere");

            EventsCollisionsSphere?.Invoke(this, collision.gameObject.GetComponent<SphereElement>().id);
          
        }
    }

    private void Impuls() 
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * powerImpuls, ForceMode.Impulse);
    }
}
