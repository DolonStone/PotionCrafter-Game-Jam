using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordercomplete : MonoBehaviour
{
    bool orderfinished = false;
    public Sprite order_tick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orderfinished = potiontodoimagechange.orderfinished;
        if (orderfinished == true)
        {
            GetComponent<SpriteRenderer>().sprite = order_tick;
        }


    }
}
