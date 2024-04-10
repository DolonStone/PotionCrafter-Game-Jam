using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Vector3 mouseFrameMovement = Vector3.zero;
    private Vector3 lastMousePos = Vector3.zero;
    private int posBuffer = 0;
    public GameObject thingToFollowPos;
    void Update()
    {
        mouseFrameMovement = Input.mousePosition - lastMousePos;
        if(posBuffer%10 == 0)
        {
            lastMousePos = Input.mousePosition;

        }
        posBuffer += 1;
        if (thingToFollowPos != null)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            thingToFollowPos.transform.position = new Vector3(cursorPos.x,cursorPos.y,3);
            if (mouseFrameMovement.magnitude >= 25 && Input.GetMouseButton(0))
            {
                thingToFollowPos.SetActive(true);
            }
            else
            {
                thingToFollowPos.SetActive(false);
            }
        }

    }
}
