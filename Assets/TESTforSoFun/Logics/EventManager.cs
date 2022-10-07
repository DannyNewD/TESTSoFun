using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [Space]
    [Header("UI Element")]
    [SerializeField] Text SphereText;
    [SerializeField] Text WallText;

    int sphere;
    int wall;

    

    public void InstEvent(ref Action<string> action) 
    {
        action += GetEvent;
    }


    public void GetEvent(string name) 
    {
        if (name == "Wall") 
        {
            wall++;
            WallText.text = "ǳ������ � ������: " + wall;

        }
        if (name == "Sphere")
        {
            sphere++;
            SphereText.text = "ǳ������ �� ������: " + sphere / 2;
        }
    }
}
