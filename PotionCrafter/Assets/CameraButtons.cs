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
    void Update()
    {
        
    }
    public void MoveLeft()
    {
        cam.transform.position = new Vector3(cam.transform.position.x - 22.13f, cam.transform.position.y, cam.transform.position.z);
    }
    public void MoveRight() 
    {
        cam.transform.position = new Vector3(cam.transform.position.x + 22.13f, cam.transform.position.y, cam.transform.position.z);
    }
}
