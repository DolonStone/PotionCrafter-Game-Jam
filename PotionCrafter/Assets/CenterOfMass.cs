using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 offset;
    private int angle = 0;
    
    void Start()
    {
        rb.centerOfMass = offset;

    }
    private void FixedUpdate()
    {
        /*
        Vector3 euler = transform.eulerAngles;
        if (euler.z > 180)
        {
            euler.z = euler.z - 360;
        }
        euler.z = Mathf.Clamp(euler.z, -25, 25);
        transform.eulerAngles = euler;
        */
        
    }
    


}

