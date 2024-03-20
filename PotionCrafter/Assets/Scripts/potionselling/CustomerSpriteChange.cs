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
    public static int customernum = 0;
    // will make efficient l8r //

    //Random rnd = new Random();

    // Start is called before the first frame update //
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //int num = rnd.Next(0,3);

        customernum = (int)dragthepotion.Randnumcus; // takes the variable from the other file to cnage the sprite //
        switch (customernum)
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
                Debug.Log("ERROR: end of switch case");
                break;
        }
     }
}
