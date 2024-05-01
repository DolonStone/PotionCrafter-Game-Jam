using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableObject : MonoBehaviour
{
    public GameObject singlesliced;
    public GameObject slicer;
    public Vector3 knifeSpeed;
    public GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera");
        slicer = GameObject.FindGameObjectWithTag("Slicer");
    }
    private void OnMouseExit()
    {
        if (Input.GetMouseButton(0)&&cam.transform.position.x<-10)
        {
            knifeSpeed = slicer.GetComponent<MouseMovement>().mouseFrameMovement;
            if (knifeSpeed.magnitude >= 25)
            {
                var newObject = Instantiate(singlesliced, transform.position, transform.rotation);
                for(int i = 0; i< 2; i++)
                {
                    newObject.transform.GetChild(i).GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;

                    newObject.transform.GetChild(i).GetComponent<Rigidbody2D>().angularVelocity = GetComponent<Rigidbody2D>().angularVelocity;
                }
                newObject.transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * new Vector3(0f,1.2f,0f);
                Destroy(gameObject);
            }

        }
    }
}
