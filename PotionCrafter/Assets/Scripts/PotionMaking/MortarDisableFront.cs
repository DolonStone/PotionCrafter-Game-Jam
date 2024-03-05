using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarDisableFront : MonoBehaviour
{
    public SpriteRenderer frontbowl;

    public int itemsWithin = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (itemsWithin == 0)
        {
            frontbowl.enabled = true;
        }
        else
        {
            frontbowl.enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemsWithin += 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        itemsWithin -= 1;
    }
    


}
