using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablesuck : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hooverenabled;
    public ParticleSystem sucker;
    public float suckfactor;
    public float delay;
    public float timesincelast;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            
            if (timesincelast < delay)
            {
                hooverenabled = true;

            }
            else
            {
                hooverenabled = false;
            }

            timesincelast += 1f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            sucker.Play();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            sucker.Stop();
            hooverenabled = false;
            timesincelast= 0f;
        }
        
    }

}
