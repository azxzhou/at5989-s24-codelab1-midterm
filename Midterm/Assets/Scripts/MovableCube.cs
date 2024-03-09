using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.IO;
using UnityEngine;
using Input = UnityEngine.Input;

public class MovableCube : MonoBehaviour
{
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 result = Input.mousePosition; 
        //pulls mouse position

        result.z = Camera.main.WorldToScreenPoint(transform.position).z;
        //where is spot on screen, prevents depth change in 3d

        result = Camera.main.ScreenToWorldPoint(result);
        //where is screen spot in world

        return result;
    }

}
