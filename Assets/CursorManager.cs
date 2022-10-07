using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    [Space]
    [Header("UI Element")]
    [SerializeField] GameObject TextLKM;
    [SerializeField] GameObject TextEsc;
    [SerializeField] GameObject Cursor;
 
    void Start()
    {
        Screen.lockCursor = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.SetActive(false);
            TextLKM.SetActive(true);
            TextEsc.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            Cursor.SetActive(true);
            TextLKM.SetActive(false);
            TextEsc.SetActive(true);
        }
    }



    private void OnEnable()
    {
        Screen.lockCursor = true;
    }

    private void OnDisable()
    {
        Screen.lockCursor = false;
    }
}
