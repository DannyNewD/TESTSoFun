using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class EventManager : MonoBehaviour
{
    [Space]
    [Header("UI Element")]
    [SerializeField] Text SphereText;
    [SerializeField] Text WallText;

    int sphere;
    int wall;

    List<SphereElement> listSphere = new List<SphereElement>();
    int idTwoElement;

    public void InstEvent(ref Action<string> action) 
    {
        action += GetEvent;
    }


   
    public void InstEvent(ref Action<SphereElement, int> action)
    {
        action += RePaintEvent;
    }

   

    public void RePaintEvent(SphereElement sphereElement, int _idTwoElement) //Id you can also not transfer. this is for the test
    {
        switch (listSphere.Count) 
        {
            case 0:
                listSphere.Add(sphereElement);
                idTwoElement = _idTwoElement;
                break;
            case 1:
                if (sphereElement.id == idTwoElement && _idTwoElement == listSphere[0].id) //It's for the test. Can be removed (it will still work)
                {
                    listSphere.Add(sphereElement);
                    RePrint(listSphere);
                }
                else { Debug.Log("Error two collor!!!"); }
                listSphere.Clear();
                break;
        }     
    }
    public void RePrint(List<SphereElement> sphereElements) 
    {
        Color32 col0 = sphereElements[0].corectColor;
        Color32 col1 = sphereElements[1].corectColor;

        sphereElements[0].gameObject.GetComponent<Renderer>().material.DOColor(col1, 0.3f);
        sphereElements[1].gameObject.GetComponent<Renderer>().material.DOColor(col0, 0.3f);
      
        sphereElements[1].corectColor = col0;
        sphereElements[0].corectColor = col1;
    }

    public void GetEvent(string name) 
    {
        if (name == "Wall") 
        {
            wall++;
            WallText.text = "Зіткнень зі стінкою: " + wall;

        }
        if (name == "Sphere")
        {
            sphere++;
            SphereText.text = "Зіткнень між кулями: " + sphere / 2;
        }
    }
}
