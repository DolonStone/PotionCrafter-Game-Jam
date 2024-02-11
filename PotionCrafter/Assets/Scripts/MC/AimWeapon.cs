using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimWeapon : MonoBehaviour
{
    public Transform aimtransform;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseposition - aimtransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        aimtransform.eulerAngles = new Vector3(0, 0, angle);
        
    }
}
