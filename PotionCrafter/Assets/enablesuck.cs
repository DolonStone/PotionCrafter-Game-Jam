using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablesuck : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem sucker;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            sucker.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sucker.Stop();
        }
        
    }

}
