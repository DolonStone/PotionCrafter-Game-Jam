using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 offset;
    public Camera cam;
    public Transform target;
    private Vector3 targetPos;
    private Vector3 screenMiddle;


    void Start()
    {
        rb.centerOfMass = offset;

    }
    private void Update()
    {
        /*
        transform.LookAt(target.position);
        transform.Rotate(Vector3.left * 90);
        transform.Rotate(Vector3.down * 90);
        */
        
    }



}

