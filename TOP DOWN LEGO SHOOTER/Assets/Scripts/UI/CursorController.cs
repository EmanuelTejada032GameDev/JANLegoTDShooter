using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{

    private void Awake()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        transform.position = Input.mousePosition;
    }

    
}
