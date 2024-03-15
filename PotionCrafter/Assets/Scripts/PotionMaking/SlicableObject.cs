using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableObject : MonoBehaviour
{
    public GameObject singlesliced;
    private void OnMouseExit()
    {
        if (Input.GetMouseButton(0))
        {

            Instantiate(singlesliced,transform.position,transform.rotation);
            
            Destroy(gameObject);
        }
    }
}
