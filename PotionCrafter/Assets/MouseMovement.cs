using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Vector3 mouseFrameMovement = Vector3.zero;
    private Vector3 lastMousePos = Vector3.zero;
    private int posBuffer = 0;
    void Update()
    {
        mouseFrameMovement = Input.mousePosition - lastMousePos;
        if(posBuffer%10 == 0)
        {
            lastMousePos = Input.mousePosition;

        }
        posBuffer += 1;
    }
}
