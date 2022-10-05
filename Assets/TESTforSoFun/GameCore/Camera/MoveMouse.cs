using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour
{
    public float SenX = 5, SensY = 10; 
    float moveY, moveX;
    public bool RootX = true, 
    RootY = true;
    MoveMouse MyPawnBody; 

    private void Start()
    {
        MyPawnBody = this;
        Screen.lockCursor = true;
    } 
    private void Update()
    {       
        if (RootY) moveY -= Input.GetAxis("Mouse Y") * SensY;            
        if (RootX) moveX += Input.GetAxis("Mouse X") * SenX;            
        MyPawnBody.transform.rotation = Quaternion.Euler(moveY, moveX, 0);
    }

   /* public void OnGUI()
    {
        GUILayout.Label(string.Format("Center screen X: {0} Y: {1}", Screen.width / 2, Screen.height / 2));
        GUILayout.Label(string.Format("Mouse Positiion: {0} ", Input.mousePosition));
    }*/
}
