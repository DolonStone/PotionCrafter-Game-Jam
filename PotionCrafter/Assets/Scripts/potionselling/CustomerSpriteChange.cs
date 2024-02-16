using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class CustomerSpriteChange : MonoBehaviour
{
    public Sprite sp1;
    public Sprite sp2;
    public Sprite sp3;
    public Sprite sp4;
    public Sprite sp5;
    // will make efficient l8r //

    int num = 0;
    //Random rnd = new Random();

    // Start is called before the first frame update //
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            num++;
        }
        //int num = rnd.Next(0,3);
        // havent figured out how to randomise yet so for now customers have an order, this should be temp //
        switch (num)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = sp1;
                //num++;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = sp2;
                //num++;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = sp3;
                //num++;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = sp4;
                //num++;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = sp5;
                break;
            default:
                num = 0;
                break;
        }

    }
}
