using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potiontodoimagechange : MonoBehaviour
{
    public Sprite sp1;
    public Sprite sp2;
    public Sprite sp3;
    public Sprite sp4;
    public static float RandPotion_order = 0f;
    public int i =0;
    // Start is called before the first frame update
    void Start()
    {
        //RandPotion_order = Random.Range(0, 3);
        random_order();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void random_order()
    {
        for (i = 0; i <= 15; ++i)
        {
            RandPotion_order = Random.Range(0, 3);
            switch (RandPotion_order)
            {
                case 0:
                    GetComponent<SpriteRenderer>().sprite = sp1;
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().sprite = sp2;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = sp3;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = sp4;
                    break;
                default:
                    Debug.Log("ERROR: end of switch case (to do list)");
                    break;

            }
        }
    }


}


