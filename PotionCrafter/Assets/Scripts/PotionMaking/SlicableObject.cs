using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableObject : MonoBehaviour
{
    private void OnMouseExit()
    {
        if (Input.GetMouseButton(0))
        {
            print("test123");
        }
        

    }
}
