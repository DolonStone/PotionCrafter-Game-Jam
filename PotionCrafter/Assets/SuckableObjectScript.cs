using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckableObjectScript : MonoBehaviour
{
    public float suckabletime;
    public bool beingsucked;
    public float suckedtime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (beingsucked == true)
        {
            suckedtime += 0.01f;

        }

        if (suckedtime > suckabletime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<enablesuck>().hooverenabled == true)
        {
            beingsucked = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        beingsucked = false;
    }
}
