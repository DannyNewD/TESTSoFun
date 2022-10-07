using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereElement : MonoBehaviour
{
    [Space]
    [Header("Conlig")]
    [SerializeField] float powerImpuls;

    [SerializeField] public Color32 corectColor;

    private void Start()
    {
        powerImpuls = GemeWorldManager.instance.GameConfig.impulsPover;

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
            Debug.Log("Wall");
            this.gameObject.GetComponent<Renderer>().material.DOColor(GemeWorldManager.instance.GameConfig.colors[Random.Range(0, GemeWorldManager.instance.GameConfig.colors.Length)], 0.3f)
                .OnComplete(()=>
                {
                    corectColor = this.gameObject.GetComponent<Renderer>().material.color;
                });
        }

        if(collision.gameObject.tag == "Sphere") 
        {
            Debug.Log("Sphere");
            var col = collision.gameObject.GetComponent<SphereElement>().corectColor;
            this.gameObject.GetComponent<Renderer>().material.DOColor(col, 0.3f)
                .OnComplete(() =>
                {
                    corectColor = col;
                });
        }
    }

    private void Impuls() 
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * powerImpuls, ForceMode.Impulse);
    }
}
