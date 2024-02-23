using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragthepotion : MonoBehaviour
{
    // initialise variables //
    Vector2 difference = Vector2.zero;
    bool givecustomer = false;
    public static int num = 0;


    [SerializeField] private Vector3 setPosition;

    public void SetPositionFunction()
    {
        transform.position = setPosition;
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
        givecustomer = true;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0) & givecustomer == true & num < 4) // if player has let go of potion and it collides with the customer //
        {
            num++; // havent figured out how to randomise yet so for now customers have an order, this should be temp //
            givecustomer = false;
            //potionncusinteraction.SetPositionFunction();
            SetPositionFunction();

        }
        else if (Input.GetMouseButtonUp(0) & givecustomer == true & num == 4)
        {
            num = 0;
            givecustomer = false;
            SetPositionFunction();
        }

    }
}

