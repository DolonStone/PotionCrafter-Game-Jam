using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragthepotion : MonoBehaviour
{
    // initialise variables //
    Vector2 difference = Vector2.zero;
    bool givecustomer = false;
    //public static int num = 0;
    float currentcusnum = 0;
    public static float Randnumcus = 0f;
    public static float Randnumpotion = 0f;
    [SerializeField] private Vector3 setPosition;
    public GameObject potion;
    public GameObject textchange;

    void Start()
    {
        textchange = GameObject.FindWithTag("TextChange");
        potion = this.gameObject;
        potion.SetActive(true);
        Randnumpotion = 2;//Random.Range(0, 12);
        Randnumcus = Random.Range(0, 5);
    }
    public void SetPositionFunction()
    {
        potion.SetActive(false);
        //transform.position = setPosition;
        //givecustomer = false;
    }

    private void OnMouseDown() // click on sprite //
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

    }

    private void OnMouseDrag() // drag sprite //
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void OnTriggerEnter2D(Collider2D collision) // potion collides with customer //
    {
        string potionname = textchange.GetComponent<textchange>().potionwanted;
        if (gameObject.name == potionname)
        {
            givecustomer = true;
        }
        else
        {
            givecustomer = false;
        }
    }
    
    void Update()
    { 
        if (Input.GetMouseButtonUp(0))
        {
            //SetPositionFunction();
        }

        if (Input.GetMouseButtonUp(0) & givecustomer == true) // if player has let go of potion and it collides with the customer //
        {
            currentcusnum = Randnumcus;
            int currentcustomer = (int)CustomerSpriteChange.customernum;
            while (currentcusnum == Randnumcus)
            {
                    if (currentcustomer == Randnumcus)
                    {
                        Randnumcus = Random.Range(0, 5);
                    }
            }

            Randnumpotion = Random.Range(0, 12);
            givecustomer = false;
            SetPositionFunction();

            //num++; // havent figured out how to randomise yet so for now customers have an order, this should be temp //

            //SetPositionFunction();

        }
        //else if (Input.GetMouseButtonUp(0) & givecustomer == true & num == 4)
        //{
        //    givecustomer = false;
        //    num = 0;
            
            //SetPositionFunction();
        //}

    }
}

