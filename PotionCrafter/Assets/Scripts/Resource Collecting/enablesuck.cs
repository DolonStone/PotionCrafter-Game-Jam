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
    public float attackdelaytime;
    public float timesincelast;
    public bool attackdelay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {



        }
        if (Input.GetMouseButtonDown(0))
        {
            sucker.Play();
            if (attackdelay)
            {
                return;
            }

            hooverenabled = true;
            attackdelay = true;
            StartCoroutine(Delayhoover());
            StartCoroutine(Delayattack());
        }

        else if (Input.GetMouseButtonUp(0))
        {
            sucker.Stop();
            hooverenabled = false;
            timesincelast= 0f;
        }
        
    }
    private IEnumerator Delayhoover()
    {
        yield return new WaitForSeconds(delay);
        
        hooverenabled = false;
    }
    private IEnumerator Delayattack()
    {
        yield return new WaitForSeconds(attackdelaytime);
        attackdelay = false;
    }

}
