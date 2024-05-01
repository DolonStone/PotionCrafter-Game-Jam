using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtons : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame

    public void MoveLeft()
    {
        if (cam.transform.position.x >= -8)
        {
            cam.transform.position = new Vector3(cam.transform.position.x - 22.13f, cam.transform.position.y, cam.transform.position.z);
        }
        
    }
    public void MoveRight() 
    {
        if (cam.transform.position.x <= 44)
        {
            cam.transform.position = new Vector3(cam.transform.position.x + 22.13f, cam.transform.position.y, cam.transform.position.z);
        }
    }
}
